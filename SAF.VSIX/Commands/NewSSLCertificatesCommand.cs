namespace SAF.VSIX.Commands
{
    using System;
    using Microsoft.VisualStudio.Shell;
    using SAF.PowerShell.Tasks;

    internal sealed class NewSSLCertificatesCommand : BaseCommand
    {
        public override int CommandId => PackageIds.NewSSLCertificatesCommandId;
        public override string JsonConfiguration => JsonConfigurationNames.SitecoreSSLConfiguration;

        public override BasePowerShellTask PowerShellTask 
            => new NewSSLCertificatesPowerShellTask(OutputWindowService.WriteLine);

        public NewSSLCertificatesCommand(Package package) : base(package)
        { }
    }
}
