namespace SAF.VSIX.Commands
{
    using Microsoft.VisualStudio.Shell;
    using SAF.PowerShell.Commands;

    internal class InstallSitecoreCommand : BaseCommand
    {
        protected override int CommandId => PackageIds.InstallSitecoreCommandId;
        protected override string JsonConfiguration => JsonConfigurationNames.SitecoreInstallConfiguration;
        protected override SAFPowerShellCommand SAFPowerShellCommand => new InstallSitecore();

        public InstallSitecoreCommand(Package package) : base(package)
        { }
    }
}
