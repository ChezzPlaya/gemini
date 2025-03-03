using System;
using System.ComponentModel.Composition;
using Caliburn.Micro;
using Gemini.Framework.Services;
using Gemini.Modules.Shell.Commands;

namespace Gemini.Framework.Results
{
	public class OpenDocumentResult : OpenResultBase<IDocument>
	{
		private readonly IDocument _editor;
		private readonly Type _editorType;
		private readonly string _path;

#pragma warning disable 649
        [Import]
		private readonly IShell _shell;
#pragma warning restore 649

        public OpenDocumentResult(IDocument editor) => _editor = editor;

        public OpenDocumentResult(string path) => _path = path;

        public OpenDocumentResult(Type editorType) => _editorType = editorType;

        public override void Execute(CoroutineExecutionContext context)
		{
			var editor = _editor ??
				(string.IsNullOrEmpty(_path)
					? (IDocument)IoC.GetInstance(_editorType, null)
					:  GetEditor(_path));

			if (editor == null)
			{
				OnCompleted(null, true);
				return;
			}

            _setData?.Invoke(editor);

            _onConfigure?.Invoke(editor);

            editor.Deactivated += (s, e) =>
			{
                if (e.WasClosed)
                {
                    _onShutDown?.Invoke(editor);
                }

                return System.Threading.Tasks.Task.CompletedTask;
            };

			_shell
                .OpenDocumentAsync(editor)
                .ContinueWith(t =>
                {
                    OnCompleted(null, false);
                });
		}

        private static IDocument GetEditor(string path) => OpenFileCommandHandler.GetEditor(path).Result;
    }
}
