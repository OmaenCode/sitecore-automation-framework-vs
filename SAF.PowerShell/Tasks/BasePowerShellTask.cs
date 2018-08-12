namespace SAF.PowerShell.Tasks
{
    public abstract class BasePowerShellTask
    {
        private string _finalScript;

        protected abstract string Script { get; }

        protected BasePowerShellTask(string jsonConfigurationAbsolutePath)
        {
            Initialize(jsonConfigurationAbsolutePath);
        }

        public string GetScript()
        {
            return _finalScript += Script;
        }

        private void Initialize(string jsonConfigurationAbsolutePath)
        {
            _finalScript = @"Write-Output ""YEAHHH!!!""";
        }
    }
}
