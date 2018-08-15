Param(
	[string]$ContextDirectory,
	[string]$SAFCommand
)

$modulePaths = @(
    "D:\Projects\saf\SAF\Sitecore.Automation.Framework.psm1",
    "C:\Projects\saf\SAF\Sitecore.Automation.Framework.psm1"
)

$importedFromLocalSource = $false

foreach ($path in $modulePaths) {
    if (Test-Path $path) {
        Import-Module -Name $path -Force
        $importedFromLocalSource = $true
        break
    }
}

if (!$importedFromLocalSource) {
    if (Get-Module -ListAvailable -Name Sitecore.Automation.Framework) {
        Update-Module -Name Sitecore.Automation.Framework
    }
    else {
        Install-Module -Name Sitecore.Automation.Framework
    }

    Get-Module -Name Sitecore.Automation.Framework | Remove-Module
    Import-Module -Name Sitecore.Automation.Framework
}

Set-Location -Path $ContextDirectory
Invoke-Expression $SAFCommand

