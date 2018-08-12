namespace SAF.PowerShell.Tasks
{
    using System.Management.Automation;
    using System;

    public abstract class BasePowerShellTask
    {
        protected abstract string Script { get; }

        public event EventHandler<PowerShellEventArgs> StreamUpdated;

        public void Run()
        {
            if (string.IsNullOrWhiteSpace(Script))
                return;

            using (PowerShell PowerShellInstance = PowerShell.Create())
            {
                PowerShellInstance.AddScript(Script);

                PowerShellInstance.Streams.Error.DataAdded += (sender, args) =>
                {
                    ErrorRecord error = ((PSDataCollection<ErrorRecord>)sender)[args.Index];
                    OnStreamUpdated($"ERROR: {error}");
                };

                PowerShellInstance.Streams.Warning.DataAdded += (sender, args) =>
                {
                    WarningRecord warning = ((PSDataCollection<WarningRecord>)sender)[args.Index];
                    OnStreamUpdated($"WARNING: {warning}");
                };

                var result = new PSDataCollection<PSObject>();
                result.DataAdded += (sender, args) =>
                {
                    PSObject output = ((PSDataCollection<PSObject>)sender)[args.Index];
                    OnStreamUpdated($"{output}");
                };

                try
                {
                    PowerShellInstance.Invoke(null, result);
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
