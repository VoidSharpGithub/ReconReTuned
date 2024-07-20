$sourceFolder = "App\bin\Release\net8.0-windows"
$outputFile = "Files.wxs"

Get-ChildItem -Path $sourceFolder -Recurse -File | ForEach-Object {
    $fileId = [System.IO.Path]::GetFileNameWithoutExtension($_.Name)
    $sourcePath = $_.FullName.Replace("C:\Users\jamie.head\source\repos\ReconReTuned\", "..\")
    $line = "<File Source=""$sourcePath"" />"
    Add-Content -Path $outputFile -Value $line
}