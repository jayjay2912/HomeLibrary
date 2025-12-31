# Home Library

Home Library project. This is a simple, static website that lists our books.

### Visiting

The site is accessible at https://thankful-ground-0bfa2ce03.3.azurestaticapps.net/

### Technologies

#### UI

Node v22.x, Angular, PrimeNg, Tailwind

#### API

.Net 9, Azure Function

### Running

To run the application locally you will need to be setup to run an Azure Static Web App for [local development](https://learn.microsoft.com/en-us/azure/static-web-apps/local-development).
Once ready, run `swa start` to start it. The application will then be accessible on http://localhost:4280

### Hosting

Both the `ui` and `api` applications are built and deployed to an Azure Static Web App.

### Environments & Deployment

There is a single hosting environment. Deployments can be triggered manually for any branch, and they are triggered automatically for any merges into `master`.
