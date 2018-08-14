namespace SAF.PowerShell.Tasks
{
    public class UninstallSolrPowerShellTask : BasePowerShellTask
    {
        public UninstallSolrPowerShellTask(string contextDirectory) 
            : base(contextDirectory)
        { }

        protected override string Script => "Uninstall-Solr";
    }
}
