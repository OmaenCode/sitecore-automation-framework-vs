namespace SAF.PowerShell.Services
{
    using System;
    using System.IO;

    public class ScriptsService
    {
        private readonly string _scriptsDirectory;

        public ScriptsService()
        {
            var codebase = typeof(ScriptsService).Assembly.CodeBase;
            var assemblyUri = new Uri(codebase, UriKind.Absolute);
            var rootDir = Path.GetDirectoryName(assemblyUri.LocalPath);
            _scriptsDirectory = Path.Combine(rootDir, "Scripts");
        }


        public string Wrapper => Path.Combine(_scriptsDirectory, "Wrapper.ps1");
    }
}
