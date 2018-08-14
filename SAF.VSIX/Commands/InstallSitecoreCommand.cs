namespace SAF.VSIX.Commands
{
    using Microsoft.VisualStudio.Shell;
    using SAF.PowerShell.Tasks;

    internal class InstallSitecoreCommand : BaseCommand
    {
        protected override int CommandId => PackageIds.InstallSitecoreCommandId;
        protected override string JsonConfiguration => JsonConfigurationNames.SitecoreInstallConfiguration;

        protected override BasePowerShellTask PowerShellTask
            => new InstallSitecorePowerShellTask(DirectoryOfSelectedItem);

        public InstallSitecoreCommand(Package package) : base(package)
        { }
    }
}
