# Data Model

## Initial Entities

The initial data model includes:

- UserAccount,
- Employee,
- Customer,
- Branch,
- Vehicle,
- VehicleCategory,
- VehicleCase,
- Reservation,
- Rental,
- Payment,
- OutstandingBalance,
- AuditLog.

## UserAccount

UserAccount represents an account used to authenticate a person in the system.

A user account has exactly one role:

- Administrator,
- Employee,
- Customer.

Administrator is not a separate entity. An administrator is a user account with the Administrator role.

UserAccount does not store the full business data of an employee or customer.

## Employee

Employee represents a rental company employee.

Each employee:

- has exactly one UserAccount,
- has exactly one role,
- is assigned to exactly one Branch.

## Customer

Customer represents a rental company customer.

A customer can exist without a UserAccount.

A customer may later activate a UserAccount to access their reservations and rental history.

A Customer can have zero or one UserAccount.

## Branch

Branch represents a physical rental company location.

A branch stores:

- name,
- city,
- address,
- phone number,
- email address,
- active status,
- opening hours.

Opening hours are stored separately for each day of the week.

The system uses branch opening hours to validate planned vehicle pickup and return times.
