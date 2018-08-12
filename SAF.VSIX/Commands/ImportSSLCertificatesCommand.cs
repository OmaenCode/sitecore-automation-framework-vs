namespace SAF.VSIX.Commands
{
    using System;
    using Microsoft.VisualStudio.Shell;
    using SAF.PowerShell.Tasks;

    internal sealed class ImportSSLCertificatesCommand : BaseCommand
    {
        public override int CommandId => PackageIds.ImportSSLCertificatesCommandId;
        public override string JsonConfiguration => JsonConfigurationNames.SitecoreSSLConfiguration;

        public override BasePowerShellTask PowerShellTask => throw new NotImplementedException();

        public ImportSSLCertificatesCommand(Package package) : base(package)
        { }
    }
}
