namespace SAF.PowerShell.Tasks
{
    using SAF.PowerShell.Providers;
    using System;

    public abstract class BasePowerShellTask
    {
        private readonly PowerShellProvider _powerShellProvider;

        protected abstract string Script { get; }

        protected BasePowerShellTask(EventHandler<PowerShellEventArgs> StreamUpdated)
        {
            _powerShellProvider = new PowerShellProvider();
            if (StreamUpdated != null)
                _powerShellProvider.StreamUpdated += StreamUpdated;
        }

        public void Run() => _powerShellProvider.RunScript(Script);
    }
}
