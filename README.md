# Home Library

Home Library project. This is a simple, static website that lists our books.

### Visiting

The site is accessible at https://thankful-ground-0bfa2ce03.3.azurestaticapps.net/

### Technologies

#### UI

Node v22.x, Angular v21.x, PrimeNg v21.x, Tailwind

#### API

.Net 9, Azure Function

### Running

To run the application locally you will need to be setup to run an Azure Static Web App for [local development](https://learn.microsoft.com/en-us/azure/static-web-apps/local-development).
Once ready, run `swa start` to start it. The application will then be accessible on http://localhost:4280

### Hosting

Both the `ui` and `api` applications are built and deployed to an Azure Static Web App.

### Environments & Deployment

There is a single hosting environment. Deployments can be triggered manually for any branch, and they are triggered automatically for any merges into `master`.

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

