namespace SAF.VSIX.Commands
{
    using EnvDTE;
    using EnvDTE80;
    using Microsoft.VisualStudio.Shell;
    using SAF.PowerShell.Tasks;
    using SAF.VSIX.Services;
    using System;
    using System.ComponentModel.Design;

    internal abstract class BaseCommand
    {
        public abstract int CommandId { get; }
        public abstract string JsonConfiguration { get; }
        public abstract BasePowerShellTask PowerShellTask { get; }
        protected IServiceProvider ServiceProvider { get; }
        protected SolutionExplorerService SolutionExplorerService { get; }
        protected OutputWindowService OutputWindowService { get; }

        protected BaseCommand(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
            SolutionExplorerService = new SolutionExplorerService();
            OutputWindowService = new OutputWindowService();
            RegisterCommand();
        }

        protected virtual void SetVisibility(object sender, EventArgs e)
        {
            var dte = ServiceProvider.GetService(typeof(DTE));
            if (dte == null || !(dte is DTE2 dte2) || !(sender is OleMenuCommand cmd))
                return;

            var visibilityService = new CommandVisibilityService(SolutionExplorerService);
            cmd.Visible = visibilityService.ShouldBeVisible(dte2, JsonConfiguration);
        }

        protected virtual void Execute(object sender, EventArgs e)
        {
            PowerShellTask.Run();
        }

        private void RegisterCommand()
        {
            if (ServiceProvider.GetService((typeof(IMenuCommandService))) is OleMenuCommandService commandService)
            {
                var menuCommandID = new CommandID(PackageGuids.SAFSubmenuCmdSet, CommandId);
                var menuItem = new OleMenuCommand(Execute, null, SetVisibility, menuCommandID);
                commandService.AddCommand(menuItem);
            }
        }
    }
}
