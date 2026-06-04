# Data Model

## Initial Entities

The initial data model includes:

* UserAccount,
* Employee,
* Customer,
* Branch,
* Vehicle,
* VehicleCategory,
* VehicleCase,
* Reservation,
* Rental,
* Payment,
* OutstandingBalance,
* AuditLog.

## UserAccount

UserAccount represents an account used to authenticate a person in the system.

A user account has exactly one role:

* Administrator,
* Employee,
* Customer.

Administrator is not a separate entity. An administrator is a user account with the Administrator role.

UserAccount does not store the full business data of an employee or customer.

## Employee

Employee represents a rental company employee.

Each employee:

* has exactly one UserAccount,
* has exactly one role,
* is assigned to exactly one Branch.

## Customer

Customer represents a rental company customer.

A customer can exist without a UserAccount.

A customer may later activate a UserAccount to access their reservations and rental history.

A Customer can have zero or one UserAccount.

## Branch

Branch represents a physical rental company location.

A branch stores:

* name,
* city,
* address,
* phone number,
* email address,
* active status,
* opening hours.

Opening hours are stored separately for each day of the week.

The system uses branch opening hours to determine whether an additional out-of-hours service fee applies to a planned vehicle pickup or return.

Branch opening hours are configured independently for each branch.

Each day of the week can have its own opening and closing time.

A branch can be marked as closed on a selected day.

## Branch Opening Hours Exceptions

Each branch can define exceptions to its standard opening hours for specific calendar dates.

An exception can:

* mark the branch as closed,
* define shortened opening hours,
* define extended opening hours.

Branch opening hours exceptions are configured independently for each branch.

When validating pickup and return times, a date-specific exception takes priority over the standard weekly opening hours.


## VehicleCategory

VehicleCategory represents a reservation category rather than a specific vehicle model.

A vehicle category stores:

- code,
- name,
- transmission type,
- description,
- active status.

Vehicle category codes can include values such as A, A+, B, B+, C, C+, D, D+, E, F, M, M+, R, R+, SUV, SUV+, Pickup and Pickup+.

Transmission type is stored separately from the category code.

Vehicle categories do not use an upgrade hierarchy.

An employee can assign any available vehicle from any category to a reservation.

The customer always pays the price of the originally reserved category, regardless of the category of the assigned vehicle.

## Vehicle Category Pricing

Vehicle rental prices are not stored directly in VehicleCategory.

Pricing is stored in a separate VehicleCategoryPrice entity.

A vehicle category can have multiple pricing records over time.

A pricing record stores:

- vehicle category,
- daily price,
- minimum daily price,
- daily discount percentage,
- validity start date,
- optional validity end date,
- active status.

When a reservation is created, the system uses the currently applicable pricing record.

The calculated reservation price is stored as a price snapshot and is not changed by later pricing updates.

Vehicle category pricing is shared across the entire rental company.

Branches do not define separate prices for the same vehicle category.
