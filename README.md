# Movieapi
Webapi for consume movies data from model db

## Setup

if you are working with mac, you need the version of VS for mac

1. Visual Studio for Mac version 8.4 or later
2. .NET Core 3.1 SDK or later (important)
https://dotnet.microsoft.com/download/dotnet-core/3.1

## Dependences

Command CLI or terminal in path project

````
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.InMemory
````

## Scaffold a controller

````
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet tool install --global dotnet-aspnet-codegenerator
dotnet aspnet-codegenerator controller -name FilmsItemsController -async -api -m FilmsItem -dc FilmsContext -outDir Controllers
````

## Create movie

#### https://{your url api}/api/FilmsItems

````
{
  "id": 3,
  "name": "The Witnesses",
  "year": 2019
}
````
