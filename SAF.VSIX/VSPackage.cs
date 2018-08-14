namespace SAF.VSIX
{
    using System;
    using System.Runtime.InteropServices;
    using Microsoft.VisualStudio;
    using Microsoft.VisualStudio.Shell;
    using SAF.VSIX.Commands;

    [PackageRegistration(UseManagedResourcesOnly = true)]
    [InstalledProductRegistration("#110", "#112", Vsix.Version, IconResourceID = 400)]
    [ProvideMenuResource("Menus.ctmenu", 1)]
    [Guid(PackageGuids.SAFCommandsPackageString)]
    [ProvideAutoLoad(VSConstants.UICONTEXT.CSharpProject_string, PackageAutoLoadFlags.BackgroundLoad)]
    public sealed class VSPackage : Package
    {
        protected override void Initialize()
        {
            new NewSSLCertificatesCommand(this);
            new ImportSSLCertificatesCommand(this);
            new InstallSolrCommand(this);
            new UninstallSolrCommand(this);
            new InstallSitecoreCommand(this);
            new UninstallSitecoreCommand(this);
            base.Initialize();
        }
    }
}
