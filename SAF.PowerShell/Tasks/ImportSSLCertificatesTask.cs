namespace SAF.PowerShell.Tasks
{
    public class ImportSSLCertificatesTask : BasePowerShellTask
    {
        public ImportSSLCertificatesTask(string contextDirectory) 
            : base(contextDirectory)
        { }

        protected override string Script => "Import-SSLCerts";
    }
}
