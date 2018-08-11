namespace SAF.PowerShell.Commands
{
    using SAF.PowerShell.Providers;
    using System;

    public abstract class BasePowerShellCommand
    {
        private readonly PowerShellProvider _powerShellProvider;

        protected abstract string Script { get; }

        protected BasePowerShellCommand(EventHandler<PowerShellEventArgs> StreamUpdated)
        {
            _powerShellProvider = new PowerShellProvider();
            if (StreamUpdated != null)
                _powerShellProvider.StreamUpdated += StreamUpdated;
        }

        public void Run() => _powerShellProvider.RunScript(Script);
    }
}
