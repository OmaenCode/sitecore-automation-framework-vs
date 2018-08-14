namespace SAF.VSIX.Commands
{
    using Microsoft.VisualStudio.Shell;
    using SAF.PowerShell.Tasks;

    internal class InstallSolrCommand : BaseCommand
    {
        protected override int CommandId => PackageIds.InstallSolrCommandId;
        protected override string JsonConfiguration => JsonConfigurationNames.SitecoreSolrConfiguration;

        protected override BasePowerShellTask PowerShellTask
            => new InstallSolrPowerShellTask(DirectoryOfSelectedItem);

        public InstallSolrCommand(Package package) : base(package)
        { }
    }
}
