using Microsoft.Win32;

namespace Gemini.Framework.Results
{
	public static class Show
	{
        public static ShowCommonDialogResult CommonDialog(CommonDialog commonDialog) => new ShowCommonDialogResult(commonDialog);

        public static ShowToolResult<TTool> Tool<TTool>()
            where TTool : ITool => new ShowToolResult<TTool>();

        public static ShowToolResult<TTool> Tool<TTool>(TTool tool)
            where TTool : ITool => new ShowToolResult<TTool>(tool);

        public static OpenDocumentResult Document(IDocument document) => new OpenDocumentResult(document);

        public static OpenDocumentResult Document(string path) => new OpenDocumentResult(path);

        public static OpenDocumentResult Document<T>()
                where T : IDocument => new OpenDocumentResult(typeof(T));

        public static ShowWindowResult<TWindow> Window<TWindow>()
                where TWindow : IWindow => new ShowWindowResult<TWindow>();

        public static ShowWindowResult<TWindow> Window<TWindow>(TWindow window)
            where TWindow : IWindow => new ShowWindowResult<TWindow>(window);

        public static ShowDialogResult<TWindow> Dialog<TWindow>()
                where TWindow : IWindow => new ShowDialogResult<TWindow>();

        public static ShowDialogResult<TWindow> Dialog<TWindow>(TWindow window)
            where TWindow : IWindow => new ShowDialogResult<TWindow>(window);
    }
}