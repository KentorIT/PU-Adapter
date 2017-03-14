param (
	[string]$version = "auto"
)

$ErrorActionPreference = "Stop"

$status = (git status)
$clean = $status| select-string "working tree clean"

if ("$clean" -eq "")
{
  echo "Working copy is not clean. Cannot proceed."
  exit
}

$master = $status | select-string "On branch master"

if ("$master" -eq "")
{
  echo "Releases are only allowed from the master branch."
  exit
}

pushd ..
If (Test-Path PU-Adapter\bin\Release){
	del PU-Adapter\bin\Release\*.dll
}

function Increment-PatchNumber
{
	$assemblyVersionPattern = '^\[assembly: AssemblyVersion\("([0-9]+(\.([0-9]+|\*)){1,3})"\)'  
	$rawVersionNumberGroup = get-content VersionInfo.cs| select-string -pattern $assemblyVersionPattern | % { $_.Matches }

	$rawVersionNumber = $rawVersionNumberGroup.Groups[1].Value  
	$versionParts = $rawVersionNumber.Split('.')  
	$versionParts[2] = ([int]$versionParts[2]) + 1  
	$updatedAssemblyVersion = "{0}.{1}.{2}" -f $versionParts[0], $versionParts[1], $versionParts[2]

	return $updatedAssemblyVersion
}

function Set-Version($newVersion)
{
	$versionPattern = "[0-9]+(\.([0-9]+|\*)){1,3}"
	(get-content VersionInfo.cs) | % { 
		% { $_ -replace $versionPattern, $newVersion }
	} | set-content VersionInfo.cs	
}

if("$version" -eq "auto")
{
	$version = Increment-PatchNumber
}

Set-Version($version)

echo "Version updated to $version, commiting and tagging..."

git commit -a -m "Updated version number to $version for release."
git tag v$version

echo "Creating nuspec files..."

$releaseNotes = "<releaseNotes>`n $((get-content nuget\ReleaseNotes.txt) -join "`n`")`n    </releaseNotes>"
function Create-Nuspec($projectName)
{
    (gc nuget\$projectName.nuspec) | 
		% { $_ -replace "<releaseNotes />", $releaseNotes } |
		set-content $projectName\$projectName.nuspec
}

Create-Nuspec("PU-Adapter")
echo "Checking if nuget exists"
If((Test-Path -Path $pwd\nuget\nuget.exe) -eq $false) {
	"nuget.exe does not exist"
	$webclient = New-Object System.Net.WebClient
	$url = "https://dist.nuget.org/win-x86-commandline/latest/nuget.exe"
	$file = "$pwd\nuget\nuget.exe"
	$webclient.DownloadFile($url,$file)
	"nuget.exe downloaded"
}

echo "Building package..."

.\nuget\nuget.exe pack -build -outputdirectory nuget PU-Adapter\PU-Adapter.csproj

$version = Increment-PatchNumber
Set-Version($version)

echo "Version updated to $version for development, committing..."

git commit -a -m "Updated version number to $version for development."

popd
