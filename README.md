# asp_project
API for rent company and basic MVC

Steps to make DB and connect it to project.

Create new empty DB in your SQL Menagmet Studio

Connect to it in Server Explorer

Get connection string Connection -> Properties -> Connection string and copy it to this line in DataAcces project -> AIContext

optionsBuilder.UseSqlServer(@"YOUR CONNECTION STRING");

Open console from Tools -> NuGet Package Menager -> Packet Manager Console

Set default project for Packet Menager Console to DataAccess and startup project to DataAccess

Type add-migration "Some text about your migration"

After migration type update-database

If it goes well, application is ready to go

If you want to use API, just make startup project in VS19 to API
