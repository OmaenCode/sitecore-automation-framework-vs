namespace SAF.VSIX.Commands
{
    using Microsoft.VisualStudio.Shell;
    using SAF.PowerShell.Commands;

    internal sealed class NewSSLCertificatesCommand : BaseCommand
    {
        protected override int CommandId => PackageIds.NewSSLCertificatesCommandId;
        protected override string JsonConfiguration => JsonConfigurationNames.SitecoreSSLConfiguration;
        protected override SAFPowerShellCommand SAFPowerShellCommand => new NewSSLCertificates();

        public NewSSLCertificatesCommand(Package package) : base(package)
        { }
    }
}
