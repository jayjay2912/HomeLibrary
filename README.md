# HomeLibrary.Web

Home Library project

## Running

Use the [Static Web Apps CLI](https://learn.microsoft.com/en-us/azure/static-web-apps/static-web-apps-cli-install).

From the root repository directory:
```shell
swa start
```

## UI

The UI is an Anglar application hosted in a Static Web App.

## API

The API is a managed Azure Function behind the Static Web App.

### Database

1. Create an AzureSQL database server and database called `home-library-db`.
2. Login with the server admin user, and create a new user called `home-library`.
3. Allow the user to access the database (see SQL below).
4. Create the database structure (see SQL below).

User permission:
```sql
CREATE USER "home-library" FOR LOGIN "home-library" WITH DEFAULT_SCHEMA = dbo;
GO

ALTER ROLE db_owner ADD MEMBER [home-library];
GO
```

DDL:
```sql
CREATE TABLE dbo.Books (
	Id int IDENTITY(1,1) NOT NULL,
	Title varchar(256) NOT NULL,
	Author varchar(256) NOT NULL,
	ShelfLocation varchar(16) NULL,
	IsReadByJay bit DEFAULT 0 NOT NULL,
	IsReadByGemma bit DEFAULT 0 NULL
);
```
