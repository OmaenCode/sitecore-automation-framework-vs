namespace SAF.VSIX.Commands
{
    using Microsoft.VisualStudio.Shell;
    using SAF.PowerShell.Commands;

    internal class UninstallSitecoreCommand : BaseCommand
    {
        protected override int CommandId => PackageIds.UninstallSitecoreCommandId;
        protected override string JsonConfiguration => JsonConfigurationNames.SitecoreInstallConfiguration;
        protected override SAFPowerShellCommand SAFPowerShellCommand => new UninstallSitecore();

        public UninstallSitecoreCommand(Package package) : base(package)
        { }
    }
}
