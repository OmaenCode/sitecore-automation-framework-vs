namespace SAF.PowerShell.Tasks
{
    public class InstallSolrPowerShellTask : BasePowerShellTask
    {
        public InstallSolrPowerShellTask(string contextDirectory) 
            : base(contextDirectory)
        { }

        protected override string Script => "Install-Solr";
    }
}
