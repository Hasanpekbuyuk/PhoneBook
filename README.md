# PhoneBookApi

A simple ASP.NET Core Web API (targeting .NET 8) that manages a phone book using Entity Framework Core with PostgreSQL.

## Project structure

- `PhoneBookApi/`
  - `Controllers/EntityController.cs` - API endpoints to list, add, delete, and search contacts.
  - `Data/AppDbContext.cs` - EF Core database context.
  - `Models/Person.cs` - Contact model mapped to `Contacts` table.
  - `Program.cs` - Application startup and configuration.
  - `appsettings.json` - Configuration including the PostgreSQL connection string.

## Requirements

- .NET 8 SDK
- PostgreSQL database (connection string configured in `appsettings.json`)

## Configuration

Configure the PostgreSQL connection string in `PhoneBookApi/appsettings.json` under `ConnectionStrings:DefaultConnection`.

Example:

```
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Port=5432;Database=phonebook;User Id=postgres;Password=yourpassword;"
}
```

The `Person` model maps to a database table named `Contacts` with columns: `id`, `name`, `surname`, `age`, `email`, `phone_number`.

## Endpoints

Base route: `/api/entity`

- `GET /api/entity/list` - Returns all contacts.
- `POST /api/entity/add` - Adds a new contact. Expects a JSON payload matching the `Person` model. Example:

```
{
  "name": "John",
  "surname": "Doe",
  "age": 30,
  "email": "john.doe@example.com",
  "phoneNumber": "+1234567890"
}
```

- `DELETE /api/entity/delete/{name}` - Deletes the first contact with the given `name`.
- `GET /api/entity/search/{name}` - Searches contacts by `name` or `phone_number` containing the given value.

## Running the project

1. Restore and build:

```
dotnet restore
dotnet build
```

2. Update database (create `Contacts` table) using EF Core migrations or manually create the table in PostgreSQL. A simple SQL example:

```sql
CREATE TABLE "Contacts" (
  "id" serial PRIMARY KEY,
  "name" text NOT NULL,
  "surname" text NOT NULL,
  "age" integer NOT NULL,
  "email" text NOT NULL,
  "phone_number" text NOT NULL
);
```

3. Run the API:

```
dotnet run --project PhoneBookApi/PhoneBookApi.csproj
```

4. When in Development, Swagger UI is available at `https://localhost:{port}/swagger`.

