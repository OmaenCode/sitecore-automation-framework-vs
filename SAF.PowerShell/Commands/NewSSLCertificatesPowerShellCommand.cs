using SAF.PowerShell.Providers;
using System;

namespace SAF.PowerShell.Commands
{
    public class NewSSLCertificatesPowerShellCommand : BasePowerShellCommand
    {
        public NewSSLCertificatesPowerShellCommand(EventHandler<PowerShellEventArgs> StreamUpdated) 
            : base(StreamUpdated)
        { }

        protected override string Script => "E:\\Temp.ps1";
    }
}
