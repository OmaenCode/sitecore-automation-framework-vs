namespace SAF.PowerShell.Providers
{
    using SAF.PowerShell.Commands;
    using SAF.PowerShell.Services;
    using System;
    using System.Management.Automation;
    using System.Threading.Tasks;

    public class PowerShellProvider
    {
        public event EventHandler<PowerShellEventArgs> StreamUpdated;

        private readonly ScriptsService _scriptsService;

        public PowerShellProvider()
        {
            _scriptsService = new ScriptsService();
        }


        public async Task RunTaskAsync(SAFPowerShellCommand command, string contextDirectory)
        {
            if (string.IsNullOrWhiteSpace(command?.Name) || string.IsNullOrWhiteSpace(contextDirectory))
                return;

            using (PowerShell ps = PowerShell.Create())
            {
                // Ensure 64-bit PowerShell
                ps.AddScript(
                    $@"& ""$env:WINDIR\sysnative\windowspowershell\v1.0\powershell.exe"" -NonInteractive -NoProfile -File ""{_scriptsService.Wrapper}"" -ContextDirectory {contextDirectory} -SAFCommand {command.Name}");

                ps.Streams.Progress.DataAdded += (sender, args) => 
                {
                    PSDataCollection<ProgressRecord> progress = (PSDataCollection<ProgressRecord>)sender;
                    OnStreamUpdated($"PROGRESS: {progress[args.Index].PercentComplete}% complete");
                };

                ps.Streams.Error.DataAdded += (sender, args) =>
                {
                    ErrorRecord error = ((PSDataCollection<ErrorRecord>)sender)[args.Index];
                    OnStreamUpdated($"ERROR: {error}");
                };

                ps.Streams.Warning.DataAdded += (sender, args) =>
                {
                    WarningRecord warning = ((PSDataCollection<WarningRecord>)sender)[args.Index];
                    OnStreamUpdated($"WARNING: {warning}");
                };

                var regularOutput = new PSDataCollection<PSObject>();
                regularOutput.DataAdded += (sender, args) =>
                {
                    PSObject output = ((PSDataCollection<PSObject>)sender)[args.Index];
                    OnStreamUpdated($"{output}");
                };

                try
                {
                    await Task<PSDataCollection<PSObject>>.Factory.FromAsync(
                        ps.BeginInvoke<PSObject, PSObject>(null, regularOutput), ps.EndInvoke);
                }
                catch (Exception ex)
                {
                    OnStreamUpdated($"EXCEPTION: {ex.Message}");
                }
            }
        }

        protected virtual void OnStreamUpdated(string message)
            => StreamUpdated?.Invoke(this, new PowerShellEventArgs { Message = message });
    }

    public class PowerShellEventArgs : EventArgs
    {
        public string Message { get; set; }
    }
}
