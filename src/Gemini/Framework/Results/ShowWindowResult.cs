using System;
using System.ComponentModel.Composition;
using Caliburn.Micro;

namespace Gemini.Framework.Results
{
    public class ShowWindowResult<TWindow> : OpenResultBase<TWindow>
        where TWindow : IWindow
    {
        private readonly Func<TWindow> _windowLocator = () => IoC.Get<TWindow>();

        [Import]
        public IWindowManager WindowManager { get; set; }

        public ShowWindowResult()
        {
        }

        public ShowWindowResult(TWindow window) => _windowLocator = () => window;

        public override void Execute(CoroutineExecutionContext context)
        {
            var window = _windowLocator();

            _setData?.Invoke(window);

            _onConfigure?.Invoke(window);

            window.Deactivated += (s, e) =>
            {
                if (e.WasClosed)
                {
                    _onShutDown?.Invoke(window);

                    OnCompleted(null, false);
                }

                return System.Threading.Tasks.Task.CompletedTask;
            };

            WindowManager.ShowWindowAsync(window);
        }
    }
}
