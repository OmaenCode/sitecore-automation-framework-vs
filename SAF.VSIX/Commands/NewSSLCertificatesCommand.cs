namespace SAF.VSIX.Commands
{
    using System;
    using Microsoft.VisualStudio.Shell;
    using SAF.PowerShell.Tasks;

    internal sealed class NewSSLCertificatesCommand : BaseCommand
    {
        protected override int CommandId => PackageIds.NewSSLCertificatesCommandId;
        protected override string JsonConfiguration => JsonConfigurationNames.SitecoreSSLConfiguration;

        protected override BasePowerShellTask PowerShellTask => new NewSSLCertificatesPowerShellTask();

        public NewSSLCertificatesCommand(Package package) : base(package)
        { }
    }
}
