namespace SAF.VSIX.Commands
{
    using Microsoft.VisualStudio.Shell;
    using SAF.PowerShell.Commands;

    internal class UninstallSolrCommand : BaseCommand
    {
        protected override int CommandId => PackageIds.UninstallSolrCommandId;
        protected override string JsonConfiguration => JsonConfigurationNames.SitecoreSolrConfiguration;
        protected override SAFPowerShellCommand SAFPowerShellCommand => new UninstallSolr();

        public UninstallSolrCommand(Package package) : base(package)
        { }
    }
}
