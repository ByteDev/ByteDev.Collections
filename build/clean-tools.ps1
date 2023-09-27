# Clean the Cake tools directory
$items = Get-ChildItem .\tools

foreach ($item in $items)
{ 
	if($item.Name -ne "nuget.exe")
	{
		Remove-Item $item.FullName -recurse
	}	
}

Write-Output "Tools folder cleaned."