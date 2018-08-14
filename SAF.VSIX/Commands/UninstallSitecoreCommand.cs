namespace SAF.VSIX.Commands
{
    using Microsoft.VisualStudio.Shell;
    using SAF.PowerShell.Tasks;

    internal class UninstallSitecoreCommand : BaseCommand
    {
        protected override int CommandId => PackageIds.UninstallSitecoreCommandId;
        protected override string JsonConfiguration => JsonConfigurationNames.SitecoreInstallConfiguration;

        protected override BasePowerShellTask PowerShellTask
            => new UninstallSitecorePowerShellTask(DirectoryOfSelectedItem);

        public UninstallSitecoreCommand(Package package) : base(package)
        { }
    }
}
