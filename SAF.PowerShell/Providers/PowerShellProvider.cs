namespace SAF.PowerShell.Providers
{
    using SAF.PowerShell.Tasks;
    using System;
    using System.Management.Automation;
    using System.Threading.Tasks;

    public class PowerShellProvider
    {
        public event EventHandler<PowerShellEventArgs> StreamUpdated;

        public async Task RunTaskAsync(BasePowerShellTask task)
        {
            if (task == null)
                return;

            var script = task.GetScript();
            if (string.IsNullOrWhiteSpace(script))
                return;

            if (string.IsNullOrWhiteSpace(script))
                return;

            using (PowerShell ps = PowerShell.Create())
            {
                ps.AddScript(script);

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
