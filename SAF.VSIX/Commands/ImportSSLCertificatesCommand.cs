﻿namespace SAF.VSIX.Commands
{
    using Microsoft.VisualStudio.Shell;
    using SAF.PowerShell.Tasks;

    internal sealed class ImportSSLCertificatesCommand : BaseCommand
    {
        protected override int CommandId => PackageIds.ImportSSLCertificatesCommandId;
        protected override string JsonConfiguration => JsonConfigurationNames.SitecoreSSLConfiguration;

        protected override BasePowerShellTask PowerShellTask 
            => new ImportSSLCertificatesTask(DirectoryOfSelectedItem);

        public ImportSSLCertificatesCommand(Package package) : base(package)
        { }
    }
}
