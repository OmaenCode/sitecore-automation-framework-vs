namespace SAF.PowerShell.Tasks
{
    using SAF.PowerShell.Providers;
    using System;

    public class NewSSLCertificatesPowerShellTask : BasePowerShellTask
    {
        public NewSSLCertificatesPowerShellTask(EventHandler<PowerShellEventArgs> StreamUpdated) 
            : base(StreamUpdated)
        { }

        protected override string Script => "E:\\Temp.ps1";
    }
}
