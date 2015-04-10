$snapin = Get-PSSnapin | Where-Object {$_.Name -eq 'Microsoft.SharePoint.Powershell'}
if ($snapin -eq $null) {
    Write-Host   $(Get-Date -format "dd_MM_yyyy_HH_mm_ss") '- Loading SharePoint Powershell Snapin'
	Write-Host
	Add-PSSnapin "Microsoft.SharePoint.Powershell"
}

# Plugin your values here
$siteUrl = "http://spdev/sites/sp2013b2";
$adminAccountForSite = "corp\spadmin";

$site = Get-SPSite $siteUrl -ErrorAction SilentlyContinue;

if($site)
{
    Write-Host "Deleting Existing Site Collection";
    Remove-SPSite -Identity $site.Url -Confirm:$false;
}

Write-Host "Creating New Site Collection";
$newSite = New-SPSite -OwnerAlias $adminAccountForSite -Template STS#0 -Url $siteUrl

Write-Host "Activating Publishing Site Level Feature";
Enable-SPFeature -Identity f6924d36-2fa8-4f0b-b16d-06b7250180fa -Url $siteUrl

Write-Host "Activating Publishing Web Level Feature";
Enable-SPFeature -Identity 22a9ef51-737b-4ff2-9346-694633fe4416 -Url $siteUrl

Write-Host "Activating MasterPage Feature";
Enable-SPFeature -Identity SP2013MasterPage -Url $siteUrl

Write-Host "Activating CT Feature";
Enable-SPFeature -Identity SP2013ContentTypes -Url $siteUrl

Write-Host "Perform Manual Activation of List Feature";
#Enable-SPFeature -Identity SP2013ListInstances -Url $siteUrl

Write-Host "Activating Page Feature";
Enable-SPFeature -Identity SP2013PageLayouts -Url $siteUrl

Write-Host "Perform Manual Activation of CT Bindings Feature";
#Enable-SPFeature -Identity SP2013ContentTypeBindings -Url $siteUrl

Write-Host "Activating Web Parts Feature";
Enable-SPFeature -Identity SP2013WebParts -Url $siteUrl