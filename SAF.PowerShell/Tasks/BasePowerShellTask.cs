namespace SAF.PowerShell.Tasks
{
    public abstract class BasePowerShellTask
    {
        private string _script;

        protected abstract string Script { get; }

        protected BasePowerShellTask()
        {
            Initialize();
        }

        public string GetScript()
        {
            return _script += Script;
        }

        private void Initialize()
        {
            _script = @"Write-Output ""YEAHHH!!!""";
        }
    }
}
