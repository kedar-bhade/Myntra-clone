# Myntra Clone Skeleton

This repository contains a simple demonstration of how a Myntra style application could be structured using a C# backend and a React frontend. It is still far from a production ready clone, but the project can be run locally with common tooling.

## Backend (C# / ASP.NET Core)

* Located in the `backend` directory.
* Uses Entity Framework Core with an SQLite database (`myntra.db`).
* Exposes product endpoints and a very small in‑memory cart service.

Run the backend with:

```bash
cd backend
dotnet run
```

## Frontend (React)

The frontend lives in the `frontend` folder and is a small Create React App project. It fetches data from the backend and allows adding items to a cart.

Install dependencies and start the dev server with:

```bash
cd frontend
npm install
npm start
```

## Images / Logo

The `frontend/public` folder contains a placeholder `logo.png` file. Replace it with your own logo image. Product images referenced in `DataSeeder` should also be added under `frontend/public/images` or updated to point to your own image hosting.

## Disclaimer

Creating a full-featured Myntra clone is a large project involving extensive backend logic, payment processing, user management, authentication, responsive UI, and much more. This repository only demonstrates the very basics and is not production ready.
