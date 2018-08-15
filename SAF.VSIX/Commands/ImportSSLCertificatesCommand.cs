namespace SAF.VSIX.Commands
{
    using Microsoft.VisualStudio.Shell;
    using SAF.PowerShell.Commands;

    internal sealed class ImportSSLCertificatesCommand : BaseCommand
    {
        protected override int CommandId => PackageIds.ImportSSLCertificatesCommandId;
        protected override string JsonConfiguration => JsonConfigurationNames.SitecoreSSLConfiguration;
        protected override SAFPowerShellCommand SAFPowerShellCommand => new ImportSSLCertificates();

        public ImportSSLCertificatesCommand(Package package) : base(package)
        { }
    }
}
