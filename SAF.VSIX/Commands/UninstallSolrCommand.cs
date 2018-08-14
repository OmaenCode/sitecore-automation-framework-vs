namespace SAF.VSIX.Commands
{
    using Microsoft.VisualStudio.Shell;
    using SAF.PowerShell.Tasks;

    internal class UninstallSolrCommand : BaseCommand
    {
        protected override int CommandId => PackageIds.UninstallSolrCommandId;
        protected override string JsonConfiguration => JsonConfigurationNames.SitecoreSolrConfiguration;

        protected override BasePowerShellTask PowerShellTask
            => new UninstallSolrPowerShellTask(DirectoryOfSelectedItem);

        public UninstallSolrCommand(Package package) : base(package)
        { }
    }
}
