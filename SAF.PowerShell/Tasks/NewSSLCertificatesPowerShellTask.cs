namespace SAF.PowerShell.Tasks
{
    public class NewSSLCertificatesPowerShellTask : BasePowerShellTask
    {
        public NewSSLCertificatesPowerShellTask(string contextDirectory) 
            : base(contextDirectory)
        { }

        protected override string Script => "New-SSLCerts";
    }
}
