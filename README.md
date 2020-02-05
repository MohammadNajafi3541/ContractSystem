# ContractSystem

## About This Project

This project includes an example of a restful Api in .net core. The Service is linked to the Mongodb database through the MongoDB.Driver library. 
In this project the logics are separated into layers and used to dependency injection.
It also for testing used of xUnit testing

## About xUnit.net

[<img align="right" width="100px" src="https://dotnetfoundation.org/img/logo_big.svg" />](https://dotnetfoundation.org/projects?searchquery=xunit&type=project)

xUnit.net is a free, open source, community-focused unit testing tool for the .NET Framework. Written by the original inventor of NUnit v2, xUnit.net is the latest technology for unit testing C#, F#, VB.NET and other .NET languages. xUnit.net works with ReSharper, CodeRush, TestDriven.NET and Xamarin. It is part of the [.NET Foundation](https://www.dotnetfoundation.org/), and operates under their [code of conduct](http://www.dotnetfoundation.org/code-of-conduct). It is licensed under [Apache 2](https://opensource.org/licenses/Apache-2.0) (an OSI approved license).

An Example of [Net Core 2.0](https://github.com/dotnet/core) WebApi tested using [xUnit 2.2.0](https://github.com/xunit/xunit)

For installation instructions see the ASP.NET Core [README.md](https://github.com/aspnet/Home)

### Installation
    Please install mongodb (https://docs.mongodb.com/manual/installation/). 
    Set the database ConnectionString in ContractSystem.Endpoint.Core>appsettings.json file.
    for testing please Set the database ConnectionString in ContractSystem.DAL.MongoDb.Tests>ContractServiceTest.

### Restore
    dotnet restore
  
### Test
    dotnet test

run this command in project root or in Visual Studio package manager
