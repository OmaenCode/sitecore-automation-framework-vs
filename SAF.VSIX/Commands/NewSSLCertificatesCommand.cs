namespace SAF.VSIX.Commands
{
    using Microsoft.VisualStudio.Shell;
    using SAF.PowerShell.Tasks;

    internal sealed class NewSSLCertificatesCommand : BaseCommand
    {
        protected override int CommandId => PackageIds.NewSSLCertificatesCommandId;
        protected override string JsonConfiguration => JsonConfigurationNames.SitecoreSSLConfiguration;

        protected override BasePowerShellTask PowerShellTask 
            => new NewSSLCertificatesPowerShellTask(DirectoryOfSelectedItem);

        public NewSSLCertificatesCommand(Package package) : base(package)
        { }
    }
}
