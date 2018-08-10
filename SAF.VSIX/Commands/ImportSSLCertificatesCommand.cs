namespace SAF.VSIX.Commands
{
    using System;
    using System.Globalization;
    using Microsoft.VisualStudio.Shell;
    using Microsoft.VisualStudio.Shell.Interop;

    internal sealed class ImportSSLCertificatesCommand : BaseCommand
    {
        public override int CommandId => PackageIds.ImportSSLCertificatesCommandId;
        public override string JsonConfiguration => JsonConfigurationNames.SitecoreSSLConfiguration;

        public ImportSSLCertificatesCommand(Package package) : base(package)
        { }

        protected override void Execute(object sender, EventArgs e)
        {
            ThreadHelper.ThrowIfNotOnUIThread();
            string message = string.Format(CultureInfo.CurrentCulture, 
                "Inside {0}.MenuItemCallback()", 
                GetType().FullName);
            string title = "ImportSSLCertificatesCommand";

            VsShellUtilities.ShowMessageBox(
                ServiceProvider,
                message,
                title,
                OLEMSGICON.OLEMSGICON_INFO,
                OLEMSGBUTTON.OLEMSGBUTTON_OK,
                OLEMSGDEFBUTTON.OLEMSGDEFBUTTON_FIRST);
        }
    }
}
