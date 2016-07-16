<#
    .SYNOPSIS
    Builds the solution
#>
param
(
    # Swan project file
    [Parameter(Mandatory = $true)]
    [string]
    [ValidateScript({ Test-Path $_ })]
    $ProjectFilePath,

    # Output folder
    [Parameter(Mandatory = $true)]
    [string]
    $OutputPath
)

process
{
    $src = Join-Path $PSScriptRoot "../src/Swan.Cli"
    $cli = Join-Path $src "project.json"
    try
    {
        pushd $src
        dotnet restore $cli
        dotnet run -p $cli generate -o $OutputPath -p $ProjectFilePath
    }
    catch [System.Exception]
    {
        
    }
    finally
    {
        popd
    }

    if (-not($?))
    {
        exit
    }

    pushd $OutputPath
    try
    {
    $outputProject = Join-Path $OutputPath "project.json"
    dotnet restore $outputProject
    dotnet build $outputProject
    dotnet ef -p $outputProject migrations add Initial
    dotnet ef -p $outputProject database update
    dotnet run -p $outputProject
    }
    catch [System.Exception]
    {

    }
    finally
    {
        popd
    }

}