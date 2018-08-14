namespace SAF.PowerShell.Tasks
{
    public class ImportSSLCertificatesPowerShellTask : BasePowerShellTask
    {
        public ImportSSLCertificatesPowerShellTask(string contextDirectory) 
            : base(contextDirectory)
        { }

        protected override string Script => "Import-SSLCerts";
    }
}
