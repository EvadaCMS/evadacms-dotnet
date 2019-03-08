# Evada CMS .NET SDK

[![Build Status](https://dev.azure.com/32technologies/Evada/_apis/build/status/evadacms-dotnet?branchName=master)](https://dev.azure.com/32technologies/Evada/_build/latest?definitionId=8?branchName=master)

## Installation via NuGet (Visual Studio)
```powershell
PM> Install-Package EvadaCms
```

## Installation via Nuget (command line)
```console
dotnet add package EvadaCms
```

## Usage

### Delivery API

Use the Evada client to pull items and assets from the Evada Delivery API. Replace the containerId parameter in the constructor of the EvadaClient class your container ID. Your container ID can be
found in the Evada Portal.

``` csharp
var httpClient = new HttpClient();
var client = new EvadaClient(
  httpClient,
  token: "MY_DELIVERY_API_TOKEN",_
  containerId: "3db9a865-34bd-402d-9540-c510867f8b56",
  defaultLanguageCode: "en-US");

  var result = await client.Items.GetAsync(new QueryParameter[] 
  {
      new DepthParameter(1)
  });
  
  foreach (var item in result.Items)
  {
      Console.WriteLine(item.System.Name);
  }
```

