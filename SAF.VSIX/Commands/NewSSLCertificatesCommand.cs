using System;
using System.ComponentModel.Design;
using System.Globalization;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Task = System.Threading.Tasks.Task;

namespace SAF.VSIX.Commands
{
    internal sealed class NewSSLCertificatesCommand
    {
        public const int CommandId = PackageIds.NewSSLCertificatesCommandId;
        public static readonly Guid CommandSet = new Guid(PackageGuids.SAFSubmenuCmdSetString);
        public static NewSSLCertificatesCommand Instance { get; private set; }

        private readonly AsyncPackage _package;
        private Microsoft.VisualStudio.Shell.IAsyncServiceProvider ServiceProvider => _package;

        public static async Task InitializeAsync(AsyncPackage package)
        {
            await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync();

            OleMenuCommandService commandService = 
                await package.GetServiceAsync((typeof(IMenuCommandService))) as OleMenuCommandService;

            Instance = new NewSSLCertificatesCommand(package, commandService);
        }

        private NewSSLCertificatesCommand(AsyncPackage package, OleMenuCommandService commandService)
        {
            _package = package ?? throw new ArgumentNullException(nameof(package));
            commandService = commandService ?? throw new ArgumentNullException(nameof(commandService));

            var menuCommandID = new CommandID(CommandSet, CommandId);
            var menuItem = new OleMenuCommand(ExecuteCallback, null, BeforeQueryStatusCallback, menuCommandID);
            commandService.AddCommand(menuItem);
        }

        private void ExecuteCallback(object sender, EventArgs e)
        {
            ThreadHelper.ThrowIfNotOnUIThread();
            string message = string.Format(CultureInfo.CurrentCulture, 
                "Inside {0}.MenuItemCallback()", 
                GetType().FullName);
            string title = "NewSSLCertificatesCommand";

            VsShellUtilities.ShowMessageBox(
                _package,
                message,
                title,
                OLEMSGICON.OLEMSGICON_INFO,
                OLEMSGBUTTON.OLEMSGBUTTON_OK,
                OLEMSGDEFBUTTON.OLEMSGDEFBUTTON_FIRST);
        }

        private void BeforeQueryStatusCallback(object sender, EventArgs e)
        {
            var cmd = (OleMenuCommand)sender;
            cmd.Visible = false;
        }
    }
}
