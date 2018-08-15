namespace SAF.VSIX.Commands
{
    using Microsoft.VisualStudio.Shell;
    using SAF.PowerShell.Commands;

    internal class InstallSolrCommand : BaseCommand
    {
        protected override int CommandId => PackageIds.InstallSolrCommandId;
        protected override string JsonConfiguration => JsonConfigurationNames.SitecoreSolrConfiguration;
        protected override SAFPowerShellCommand SAFPowerShellCommand  => new InstallSolr();

        public InstallSolrCommand(Package package) : base(package)
        { }
    }
}
