namespace SAF.VSIX.Services
{
    using EnvDTE;
    using EnvDTE80;
    using Microsoft.VisualStudio.Shell;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    internal class SolutionExplorerService
    {
        public string GetDirectoryOfSelectedItem(DTE2 dte)
        {
            ThreadHelper.ThrowIfNotOnUIThread();

            var selectedItems = GetSelectedItems(dte);
            if (selectedItems.Count != 1)
                return string.Empty;
           
            return Path.GetDirectoryName(selectedItems[0].FileNames[1]);
        }

        public List<ProjectItem> GetSelectedItems(DTE2 dte)
        {
            ThreadHelper.ThrowIfNotOnUIThread();

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
