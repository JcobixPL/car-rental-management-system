# Car Rental Management System

Car Rental Management System (CRMS) is a backend application designed for a car rental company operating multiple branches in different cities.

The system is intended to support the complete rental workflow, including vehicle management, reservations, vehicle handover, active rentals, returns, payments, and vehicle availability.

## Project Status

The project is currently in the early development stage.

The initial solution structure and business documentation have been prepared. Application features, database integration, authentication, and API endpoints will be implemented incrementally.

## Main Goals

The system is designed to support:

* management of rental branches and employees,
* customer profiles and user accounts,
* vehicle registration and fleet management,
* vehicle category reservations,
* assignment of specific vehicles before pickup,
* vehicle availability calculations,
* vehicle handover and return processes,
* vehicle issues, maintenance, and inspections,
* rental payments and outstanding balances,
* audit logging of important business operations.

## Technology Stack

Planned technologies:

* .NET 10
* ASP.NET Core Web API
* Entity Framework Core
* PostgreSQL
* JWT Bearer Authentication
* Scalar API Documentation
* OpenAPI
* xUnit

## Architecture

The solution follows a layered architecture with clear separation of responsibilities.

```text
src/
├── CarRentalManagementSystem.Api
├── CarRentalManagementSystem.Application
├── CarRentalManagementSystem.Domain
└── CarRentalManagementSystem.Infrastructure
```

### Project Responsibilities

* `CarRentalManagementSystem.Api`
  Provides HTTP endpoints, authentication configuration, middleware, and API documentation.

* `CarRentalManagementSystem.Application`
  Contains application use cases, service abstractions, DTOs, and repository interfaces.

* `CarRentalManagementSystem.Domain`
  Contains domain entities, enums, value objects, business rules, and domain exceptions.

* `CarRentalManagementSystem.Infrastructure`
  Contains Entity Framework Core, PostgreSQL integration, repository implementations, and external service implementations.

## Project Dependencies

```text
Api → Application
Api → Infrastructure
Application → Domain
Infrastructure → Application
Infrastructure → Domain
Domain → no dependencies
```

## MVP Scope

The first version of the system will focus on the core operational rental process:

* branch and employee management,
* vehicle management,
* vehicle availability,
* vehicle cases,
* reservation management,
* vehicle handover,
* active rentals,
* vehicle return,
* rental completion.

## Documentation

Detailed business and technical documentation is available in the `docs` directory:

* [Product Vision](docs/product-vision.md)
* [MVP Scope](docs/mvp-scope.md)
* [System Modules](docs/modules.md)
* [Data Model](docs/data-model.md)
* [Business Rules](docs/business-rules.md)
* [Roles and Permissions](docs/roles-and-permissions.md)
* [Reservation and Rental Lifecycle](docs/reservation-and-rental-lifecycle.md)
* [Vehicle Cases](docs/vehicle-cases.md)
* [Vehicle Handover and Return](docs/vehicle-handover-and-return.md)

## Running the Project

Requirements:

* .NET 10 SDK

From the repository root, run:

```bash
dotnet restore
dotnet build CarRentalManagementSystem.slnx
dotnet run --project src/CarRentalManagementSystem.Api
```

Database configuration and additional environment setup instructions will be added after PostgreSQL integration is implemented.

## License

This project is developed as a portfolio project.
