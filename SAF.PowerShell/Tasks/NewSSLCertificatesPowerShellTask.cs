namespace SAF.PowerShell.Tasks
{
    public class NewSSLCertificatesPowerShellTask : BasePowerShellTask
    {
        public NewSSLCertificatesPowerShellTask(string jsonConfigurationAbsolutePath) 
            : base(jsonConfigurationAbsolutePath)
        { }

        protected override string Script => "";
    }
}
