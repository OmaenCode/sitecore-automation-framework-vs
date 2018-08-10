namespace SAF.VSIX.Services
{
    using EnvDTE80;
    using Microsoft.VisualStudio.Shell;
    using System;
    using System.IO;

    internal class CommandVisibilityService
    {
        private readonly SolutionExplorerService _solutionExplorerService;

        public CommandVisibilityService(SolutionExplorerService solutionExplorerService)
        {
            _solutionExplorerService = solutionExplorerService;
        }

        public bool ShouldBeVisible(DTE2 dte, string jsonName)
        {
            ThreadHelper.ThrowIfNotOnUIThread();

            if (dte == null || string.IsNullOrWhiteSpace(jsonName))
                return false;

            var selectedItems = _solutionExplorerService.GetSelectedItems(dte);
            if (selectedItems.Count != 1)
                return false;

            var fileName = Path.GetFileName(selectedItems[0].FileNames[1]);
            return jsonName.Equals(fileName, StringComparison.OrdinalIgnoreCase);
        }
    }
}
