param(
	[string]$project = "Sistema Bancario/Sistema Bancario.csproj",
	[string]$configuration = "Release",
	[string]$output = "publish"
)

dotnet restore
dotnet publish $project -c $configuration -o $output

$zipName = "release-$(Get-Date -Format yyyyMMddHHmmss).zip"
if(Test-Path $zipName) { Remove-Item $zipName }
Compress-Archive -Path "$output/*" -DestinationPath $zipName
Write-Host "Release criado: $zipName"
