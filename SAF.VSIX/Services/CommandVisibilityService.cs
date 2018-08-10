using EnvDTE80;
using Microsoft.VisualStudio.Shell;
using System;
using System.IO;
using System.Threading.Tasks;

namespace SAF.VSIX.Services
{
    internal class CommandVisibilityService
    {
        private readonly SolutionExplorerService _solutionExplorerService;

        public CommandVisibilityService(SolutionExplorerService solutionExplorerService)
        {
            _solutionExplorerService = solutionExplorerService;
        }

        public async Task<bool> ShouldBeVisibleAsync(DTE2 dte, string jsonName)
        {
            await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync();

            if (dte == null || string.IsNullOrWhiteSpace(jsonName))
                return false;

            var selectedItems = await _solutionExplorerService.GetSelectedItemsAsync(dte);
            if (selectedItems.Count != 1)
                return false;

            var fileName = Path.GetFileName(selectedItems[0].FileNames[1]);
            return jsonName.Equals(fileName, StringComparison.OrdinalIgnoreCase);
        }
    }
}
