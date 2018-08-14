namespace SAF.PowerShell.Tasks
{
    public class UninstallSitecorePowerShellTask : BasePowerShellTask
    {
        public UninstallSitecorePowerShellTask(string contextDirectory)
            : base(contextDirectory)
        { }

        protected override string Script => "Uninstall-Sitecore";
    }
}
