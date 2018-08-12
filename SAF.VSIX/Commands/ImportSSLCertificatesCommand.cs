namespace SAF.VSIX.Commands
{
    using System;
    using Microsoft.VisualStudio.Shell;

    internal sealed class ImportSSLCertificatesCommand : BaseCommand
    {
        public override int CommandId => PackageIds.ImportSSLCertificatesCommandId;
        public override string JsonConfiguration => JsonConfigurationNames.SitecoreSSLConfiguration;

        public ImportSSLCertificatesCommand(Package package) : base(package)
        { }

        protected override void Execute(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
