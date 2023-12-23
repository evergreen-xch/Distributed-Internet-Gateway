$name = "Distributed-Internet-Gateway"
$src = "src"
$outputRoot = "./publish"

if ([System.Environment]::OSVersion.Platform -eq "Win32NT") {
    if (!(Test-Path -Path $outputRoot)) {
        & ./publish.ps1
    }

    # build the msi - win-x64 only
    dotnet build ./$src/Installer/Windows/MsiInstaller.wixproj -c Release -r win-x64 --output $outputRoot
    Move-Item -Path $outputRoot/en-us/Decentralized-Internet-Gateway.msi -Destination $outputRoot/$name-win-x64.msi
}