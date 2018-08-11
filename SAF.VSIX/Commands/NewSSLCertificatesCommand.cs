namespace SAF.VSIX.Commands
{
    using System;
    using Microsoft.VisualStudio.Shell;
    using SAF.PowerShell.Commands;

    internal sealed class NewSSLCertificatesCommand : BaseCommand
    {
        public override int CommandId => PackageIds.NewSSLCertificatesCommandId;
        public override string JsonConfiguration => JsonConfigurationNames.SitecoreSSLConfiguration;

        public NewSSLCertificatesCommand(Package package) : base(package)
        { }

        protected override void Execute(object sender, EventArgs e)
        {
            var command = new NewSSLCertificatesPowerShellCommand(OutputWindowService.WriteLine);
            command.Run();
        }
    }
}
