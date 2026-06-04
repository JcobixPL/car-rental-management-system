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

* code,
* name,
* transmission type,
* description,
* active status.

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

* vehicle category,
* daily price,
* minimum daily price,
* daily discount percentage,
* validity start date,
* optional validity end date,
* active status.

When a reservation is created, the system uses the currently applicable pricing record.

The calculated reservation price is stored as a price snapshot and is not changed by later pricing updates.

Vehicle category pricing is shared across the entire rental company.

Branches do not define separate prices for the same vehicle category.

## Vehicle Category Deposit

The standard deposit amount is configured per vehicle category.

Deposit amounts are shared across the entire rental company.

Branches do not define separate deposit amounts for the same vehicle category.

## Vehicle Category Deposit History

The standard deposit amount is stored in a separate VehicleCategoryDeposit entity.

A vehicle category can have multiple deposit records over time.

A deposit record stores:

* vehicle category,
* deposit amount,
* validity start date,
* optional validity end date,
* active status.

The applicable deposit amount is stored as part of the reservation or rental terms so that later configuration changes do not affect existing reservations or rentals.

## Insurance Package History

Insurance packages are stored separately from their historical pricing and configuration.

InsurancePackage stores the permanent identity of a package, including its code, name, description and active status.

InsurancePackageVersion stores the configuration valid during a specific period.

A package version stores:

* insurance package,
* price,
* deposit reduction percentage,
* validity start date,
* optional validity end date,
* active status.

The insurance deductible depends on both the insurance package version and the vehicle category.

Insurance deductible amounts are stored separately for each supported vehicle category and insurance package version combination.

When a customer selects an insurance package, the applicable price, deposit reduction and deductible are stored as part of the reservation or rental terms.

Later changes to insurance pricing or configuration do not affect existing reservations or rentals.

## Insurance Daily Pricing

Insurance packages are priced per rental day.

InsurancePackageVersion stores a daily insurance price rather than a one-time price.

When a customer selects an insurance package, the applicable daily price is stored as a snapshot in the reservation terms.

The customer pays in advance for the insurance covering the planned rental period.

If the rental is extended, additional insurance days are calculated using the stored daily insurance price and are charged after vehicle return.

Insurance refunds for early vehicle return are calculated using the stored daily insurance price snapshot.

The system should distinguish between planned insurance days, used insurance days and refundable unused insurance days.

Rental refunds for early vehicle return are calculated using the stored reservation pricing snapshot.

The system should distinguish between the planned rental period, actual rental period, original rental price and recalculated actual rental price.

## Vehicle

Vehicle represents a specific physical car.

A vehicle stores:

* VIN,
* registration number,
* make,
* model,
* production year,
* vehicle category,
* current branch,
* current mileage,
* fuel type,
* transmission type,
* status,
* next technical inspection date,
* next service mileage,
* next service date.

Transmission type is stored directly in Vehicle even though the vehicle category may also imply a transmission type.

The system should validate that the vehicle transmission type is compatible with the assigned vehicle category.

The number of kilometers remaining until the next service is calculated from the current mileage and next service mileage rather than stored directly.

### Available

The vehicle can be assigned to a reservation.

### Reserved

The vehicle is assigned to a confirmed reservation.

### Rented

The vehicle has been handed over to a customer and is part of an active rental.

### Unavailable

The vehicle is temporarily unavailable, for example because of a blocking vehicle case.

### Withdrawn

The vehicle has been withdrawn from operational use and cannot be assigned to new reservations.

## Vehicle Operational Status

A vehicle has an operational status:

- Active,
- Withdrawn.

### Active

The vehicle is part of the rental fleet and may be available for reservations.

### Withdrawn

The vehicle has been withdrawn from operational use and cannot be assigned to new reservations.

## Vehicle Availability

Vehicle availability is calculated for a specific date and time range.

A vehicle is unavailable during a requested period if:

- the vehicle is withdrawn,
- an open blocking vehicle case overlaps the requested period,
- the vehicle is assigned to another confirmed reservation that overlaps the requested period,
- the vehicle is part of an active rental that overlaps the requested period.

A vehicle can be reserved during one period and available during another period.

Vehicle availability calculations must include the configured preparation buffer between a planned return and the next pickup.

## Vehicle Branch History

Vehicle stores the current branch assignment in CurrentBranchId.

Each change of the vehicle's branch creates a VehicleBranchHistory record.

A vehicle branch history record stores:

- vehicle,
- previous branch,
- new branch,
- employee who performed the change,
- change timestamp,
- optional reason.

The branch history cannot be deleted or modified through ordinary application operations.

## Vehicle Mileage History

Vehicle stores the current mileage in CurrentMileage for efficient access.

Each mileage change creates a VehicleMileageHistory record.

A vehicle mileage history record stores:

- vehicle,
- mileage value,
- recorded timestamp,
- user who recorded the mileage,
- mileage source,
- optional reason.

Mileage source is required and can include:

- VehicleRegistration,
- RentalHandover,
- RentalReturn,
- VehicleCase,
- AdministratorCorrection.

Historical mileage records cannot be deleted or modified through ordinary application operations.

An administrator correction creates a new history record rather than changing an existing record.

## Customer

Customer represents a rental company customer and stores business data rather than authentication data.

A customer stores:

- first name,
- last name,
- email address,
- phone number,
- date of birth,
- status,
- creation timestamp.

A customer can be identified using different types of identity documents.

## Customer Identity Document

Customer identity documents are stored in a separate CustomerIdentityDocument entity.

An identity document stores:

- customer,
- document type,
- document number,
- issuing country,
- optional expiry date,
- primary document flag,
- verification timestamp,
- employee who verified the document.

Supported document types can include:

- NationalId,
- Passport,
- ForeignIdentityCard.

A customer does not need to have a national identification number if another accepted identity document is available.

A customer can have multiple identity documents.

At least one verified identity document is required before vehicle handover.

One identity document can be marked as the primary document.

## Customer Driving License

Customer driving license data is stored separately from identity documents.

A driving license record stores:

- customer,
- license number,
- issuing country,
- expiry date,
- verification timestamp,
- employee who verified the document.

A valid and verified driving license is required before vehicle handover.

A customer can have zero or one current driving license record.

When a driving license is replaced or renewed, the current record is updated through a controlled employee verification process.

A customer can exist without a driving license, but a valid and verified driving license is required before vehicle handover.

## Customer Statuses

A customer can have one of the following statuses:

- Active,
- Blocked,
- Blacklisted,
- Anonymized.

### Active

The customer can use the system normally and create reservations.

### Blocked

The customer is temporarily blocked, for example because of an unpaid outstanding balance.

### Blacklisted

The customer has been blacklisted by an employee or administrator and cannot create new reservations.

### Anonymized

The customer's personal data has been anonymized while historical business records remain available.

## Reservation

Reservation represents a planned rental before vehicle handover.

A reservation stores:

- customer,
- reserved vehicle category,
- optional assigned vehicle,
- pickup branch,
- return branch,
- planned pickup date and time,
- planned return date and time,
- reservation status,
- creation timestamp,
- optional confirmation timestamp,
- optional cancellation timestamp,
- optional cancellation reason,
- total reservation price.

AssignedVehicleId is optional because an employee can confirm a reservation before assigning a specific vehicle.

Reservation pickup and return periods are stored using exact dates and times rather than only calendar dates.
