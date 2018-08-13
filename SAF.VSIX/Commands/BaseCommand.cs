namespace SAF.VSIX.Commands
{
    using EnvDTE;
    using EnvDTE80;
    using Microsoft.VisualStudio.Shell;
    using SAF.PowerShell.Providers;
    using SAF.PowerShell.Tasks;
    using SAF.VSIX.Services;
    using System;
    using System.ComponentModel.Design;

    internal abstract class BaseCommand
    {
        protected abstract int CommandId { get; }
        protected abstract string JsonConfiguration { get; }
        protected abstract BasePowerShellTask PowerShellTask { get; }
        protected string DirectoryOfSelectedItem
        {
            get
            {
                var dte = _serviceProvider.GetService(typeof(DTE));
                if (dte == null || !(dte is DTE2 dte2))
                    return string.Empty;

                return _solutionExplorerService.GetDirectoryOfSelectedItem(dte2);
            }
        }

        private IServiceProvider _serviceProvider { get; }
        private SolutionExplorerService _solutionExplorerService { get; }
        private OutputWindowService _outputWindowService { get; }
        private PowerShellProvider _powerShellProvider { get; }

        protected BaseCommand(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
            _solutionExplorerService = new SolutionExplorerService();
            _outputWindowService = new OutputWindowService();
            _powerShellProvider = new PowerShellProvider();
            RegisterCommand();
        }

        protected virtual void SetVisibility(object sender, EventArgs e)
        {
            var dte = _serviceProvider.GetService(typeof(DTE));
            if (dte == null || !(dte is DTE2 dte2) || !(sender is OleMenuCommand cmd))
                return;

            var visibilityService = new CommandVisibilityService(_solutionExplorerService);
            cmd.Visible = visibilityService.ShouldBeVisible(dte2, JsonConfiguration);
        }

        protected virtual async void Execute(object sender, EventArgs e)
        {
            _powerShellProvider.StreamUpdated -= _outputWindowService.WriteLineAsync;
            _powerShellProvider.StreamUpdated += _outputWindowService.WriteLineAsync;
            await _powerShellProvider.RunTaskAsync(PowerShellTask);
        }

        private void RegisterCommand()
        {
            if (_serviceProvider.GetService((typeof(IMenuCommandService))) is OleMenuCommandService commandService)
            {
                var menuCommandID = new CommandID(PackageGuids.SAFSubmenuCmdSet, CommandId);
                var menuItem = new OleMenuCommand(Execute, null, SetVisibility, menuCommandID);
                commandService.AddCommand(menuItem);
            }
        }
    }
}
