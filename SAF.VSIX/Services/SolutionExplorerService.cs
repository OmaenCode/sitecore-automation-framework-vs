using EnvDTE;
using EnvDTE80;
using Microsoft.VisualStudio.Shell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAF.VSIX.Services
{
    internal class SolutionExplorerService
    {
        public async Task<List<ProjectItem>> GetSelectedItemsAsync(DTE2 dte)
        {
            await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync();

            var result = new List<ProjectItem>();

            if (dte == null)
                return result;

            var selectedItems = dte.ToolWindows.SolutionExplorer.SelectedItems;
            if (selectedItems == null || !(selectedItems is Array selectedItemsArr))
                return result;

            foreach (var item in selectedItemsArr.Cast<UIHierarchyItem>())
                if (item.Object is ProjectItem projectItem)
                    result.Add(projectItem);

            return result;
        }
    }
}
