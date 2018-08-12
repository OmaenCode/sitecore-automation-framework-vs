namespace SAF.VSIX.Services
{
    using Microsoft.VisualStudio.Shell;
    using Microsoft.VisualStudio.Shell.Interop;
    using SAF.PowerShell.Providers;
    using System;

    /// <summary>
    /// TODO: Investigate UI warning. It throws exception if suggested fix is applied.
    /// </summary>
    internal class OutputWindowService
    {
        private const string WindowTitle = "SAF - Output";
        private const string WindowGuid = "0F44E2D1-F5FA-4d2d-AB30-22BE8ECD9789";

        private IVsOutputWindowPane _outputWindow;
        private IVsOutputWindowPane OutputWindow
        {
            get
            {
                if (_outputWindow != null
                    || !(Package.GetGlobalService(typeof(SVsOutputWindow)) is IVsOutputWindow ouputWindow))
                    return _outputWindow;

                Guid windowGuid = new Guid(WindowGuid);
                ouputWindow.CreatePane(ref windowGuid, WindowTitle, 1, 1);
                ouputWindow.GetPane(ref windowGuid, out _outputWindow);
                _outputWindow.Activate();
                return _outputWindow;
            }
        }

        public void WriteLine(object source, PowerShellEventArgs args)
        {
            if (string.IsNullOrWhiteSpace(args?.Message))
                return;

            OutputWindow.OutputString($"{Environment.NewLine}{args.Message}");
        }
    }
}
