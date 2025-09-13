# PropChecker API

Welcome to the PropChecker API, a backend service for managing real estate properties, their sales history, and associated data. This API is built with .NET 7 and MongoDB, following clean architecture principles for maintainability and scalability.

## Table of Contents

- [Architecture & Technology Stack](#architecture--technology-stack)
- [Prerequisites](#prerequisites)
- [Getting Started](#getting-started)
- [API Endpoints](#api-endpoints)
- [Project Structure](#project-structure)
- [Best Practices](#best-practices)

## Features

- **Property Management**: List properties with powerful filtering options.
- **Property History**: Track the sales history (traces) for each property.
- **Optimized Queries**: Efficiently retrieves property data along with its primary image.
- **Configuration-driven**: Easily configure database connections and collection names.

## Architecture & Technology Stack

- **Framework**: .NET 7
- **Database**: MongoDB
- **Architecture**: Layered Architecture (Controllers, Services, Repositories)
- **Language**: C#
- **API Documentation**: Swagger / OpenAPI

The project uses a clean, decoupled architecture:
- **Controllers**: Handle incoming HTTP requests and responses.
- **Services**: Contain the core business logic.
- **Repositories**: Abstract the data access layer, interacting directly with the MongoDB database.

This separation of concerns makes the application modular, easier to test, and maintain.

## Prerequisites

Before you begin, ensure you have the following installed:
- [.NET 7 SDK](https://dotnet.microsoft.com/download/dotnet/7.0)
- [MongoDB](https://www.mongodb.com/try/download/community) (or a cloud instance like MongoDB Atlas)
- A code editor like [Visual Studio](https://visualstudio.microsoft.com/) or [VS Code](https://code.visualstudio.com/).

## Getting Started

Follow these steps to get the project running on your local machine.

### 1. Clone the Repository

```bash
git clone <your-repository-url>
cd PropChecker.Backend
```

### 2. Configure Database Connection

Open the `appsettings.Development.json` file. If it doesn't exist, create it by copying `appsettings.json`. Update the `MongoDb` section with your MongoDB connection string and database name.

```json
{
  "MongoDb": {
    "ConnectionString": "mongodb://localhost:27017",
    "DatabaseName": "PropChecker",
    "Collections": {
      "Properties": "Properties",
      "Owners": "Owners",
      "PropertyImages": "PropertyImages",
      "PropertyTraces": "PropertyTraces"
    }
  }
}
```

### 3. Restore Dependencies and Run

Open a terminal in the project's root directory and run the following commands:

```bash
# Restore NuGet packages
dotnet restore

# Run the application
dotnet run
```

The API will now be running. By default, you can access the Swagger UI for testing at `http://localhost:5083/swagger`.

## API Endpoints

The following are the main endpoints available in the API.

### Property

#### `GET /api/property`

Retrieves a list of properties, optionally filtered by the provided criteria. Each property includes its main image.

**Query Parameters:**
- `name` (string, optional): Filter by property name (case-insensitive).
- `address` (string, optional): Filter by property address (case-insensitive).
- `minPrice` (decimal, optional): Filter by minimum price.
- `maxPrice` (decimal, optional): Filter by maximum price.

**Response:** `200 OK` with a list of properties or `404 Not Found` if no properties match.

### Property Trace

#### `POST /api/propertytraces`

Creates a new sales history record (trace) for a property.

**Request Body:**

```json
{
  "propertyTraceId": "TR003",
  "idProperty": "PROP001",
  "dateSale": "2024-01-10T00:00:00Z",
  "name": "Secondary Market Sale",
  "value": 850000,
  "tax": 42500
}
```

**Response:** `201 Created` with the newly created property trace object.

#### `GET /api/properties/{propertyId}/traces`

Retrieves all history records for a specific property.

**Path Parameter:**
- `propertyId` (string, required): The unique identifier of the property.

**Response:** `200 OK` with a list of property traces.

## Project Structure

```
/
├── Controllers/    # API endpoints
├── Dtos/           # Data Transfer Objects
├── Models/         # Database entities and settings models
├── Repositories/   # Data access logic
├── Services/       # Business logic
└── Program.cs      # Application entry point and service configuration
```

## Best Practices

- **Clean Architecture**: The code is organized into layers, promoting separation of concerns.
- **Dependency Injection**: Services and repositories are registered and injected, making the code testable and loosely coupled.
- **Optimized Queries**: The property listing endpoint uses MongoDB's Aggregation Pipeline (`$lookup`) to efficiently join collections at the database level.
- **Clear Documentation**: API endpoints are documented using XML comments, which integrate with Swagger to provide a rich, interactive API explorer.