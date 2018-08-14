namespace SAF.PowerShell.Tasks
{
    public class InstallSitecorePowerShellTask : BasePowerShellTask
    {
        public InstallSitecorePowerShellTask(string contextDirectory) 
            : base(contextDirectory)
        { }

        protected override string Script => "Install-Sitecore";
    }
}
