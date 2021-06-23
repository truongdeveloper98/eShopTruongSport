# ASP.NET Core 3.1 project from TruongDev
## Technologies
- ASP.NET Core 3.1
- Entity Framework Core 3.1
## Install Tools
- .NET Core SDK 3.1
- Git client
- Visual Studio 2019
- SQL Server 2019
## How to configure and run
- Clone code from Github: git clone https://github.com/truongdeveloper98/eShopTruongSport
- Open solution eShopTruongSport.sln in Visual Studio 2019
- Set startup project is eShopTruongSport.Data
- Change connection string in Appsetting.json in eShopTruongSport.Data project
- Open Tools --> Nuget Package Manager -->  Package Manager Console in Visual Studio
- Run Update-database and Enter.
- After migrate database successful, set Startup Project is eShopTruongSport.WebApp
- Change database connection in appsettings.Development.json in eShopTruongSport.WebApp project.
- Choose profile to run or press F5
## How to contribute
- Fork and create your branch
- Create Pull request to us.
jsdhkjshd