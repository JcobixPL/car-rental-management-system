# Business Rules

## Reservation Price

The rental price is calculated when the customer creates a reservation.

The price of an existing reservation does not change when an administrator updates the pricing configuration.

## Vehicle Category Deposit

Each vehicle category has a standard deposit amount configured by an administrator.

Insurance packages may reduce the required deposit.

## Insurance

Customers do not receive insurance coverage by default and may be responsible for damages.

Customers can select an optional insurance package during the reservation process.

Insurance package prices, coverage rules and deposit reductions are configured by an administrator.

## Additional Services

Customers can purchase additional services, including:

- additional drivers,
- permission to travel abroad,
- child seats.

Additional service prices are configured by an administrator.

## Daily Rental Pricing

The price for each additional rental day may be reduced by a configurable percentage.

The daily price cannot fall below a configurable minimum daily amount.

## Price Snapshot

The price of each item added to a reservation is fixed at the moment the item is selected.

This applies to:

- vehicle category rental price,
- insurance packages,
- additional drivers,
- permission to travel abroad,
- child seats,
- other optional services.

If an administrator changes the pricing configuration, existing reservation items keep their original prices.

If a customer adds an optional service later, for example during vehicle pickup, the current price at the time of adding the service is used.

## Reservation and Rental Changes

Before vehicle pickup, a customer can manage their own reservation and add or remove optional services.

Insurance can only be purchased before the vehicle is handed over to the customer.

During an active rental, the customer may request:

- a child seat,
- permission to travel abroad,
- a change of the planned return date,
- a change of the return branch.

Changes to the return date or return branch require employee approval because they may affect vehicle availability and branch operations.

## Customer Reservation Cancellation

A customer can cancel their own reservation before vehicle pickup.

The system records the cancellation date, cancellation reason and the user who performed the cancellation.

## Late Cancellation Fee

If a customer cancels a reservation less than the configured number of hours before the planned pickup time, a cancellation fee is charged.

The cancellation fee percentage and time threshold are configured by an administrator.

If the reservation was paid in advance, the refund is reduced by the cancellation fee.

If the reservation was not paid in advance, the system creates an outstanding customer balance.

A customer with an unpaid outstanding balance cannot create a new reservation until the balance is paid.

## Deposit Payment

The vehicle deposit is paid during vehicle pickup.

The final deposit amount is calculated at pickup because it may be reduced by the selected insurance package.

## Outstanding Balance Payment

A customer can pay an outstanding balance online or through an employee at a rental branch.

After the outstanding balance is fully paid, the customer can create new reservations.

## Reservation Payment

A customer can choose to pay for a reservation online during the reservation process or pay during vehicle pickup.

The selected payment method does not change the reservation price.

## Supported Payment Methods

The system supports the following payment methods:

- online card payment,
- online bank transfer,
- card payment at a rental branch.

Cash payments are not supported.

## Payment Gateway

Online payments are simulated within the application.

The payment implementation should be designed so that a real external payment gateway can be integrated in the future without changing the core business logic.

## Customer Account and Guest Reservations

A customer can create a reservation without having an existing user account.

During the reservation process, the customer provides contact and identification data required by the rental company.

The system creates a customer profile for business purposes.

A customer profile is separate from a user account.

The customer can verify their email address using a one-time verification code or secure link.

After verification, the customer can view and manage their current and previous reservations.

A customer may later activate a full user account.

Sensitive identification data, such as a national identification number, must not be used as a login or account identifier.

## Customer Authentication

A customer can sign in using one of the following methods:

- email address and password,
- one-time verification code sent to the customer's email address.

One-time codes expire after a limited period and cannot be reused.

## Employee and Administrator Authentication

Employees and administrators sign in using a system-generated username and password.

The username is generated from the first letter of the employee's first name and their last name.

If the generated username already exists, the system appends the next available numeric suffix.

Usernames must be unique and must not contain internal database identifiers.

Two-factor authentication is required for employees and administrators.

Two-factor authentication uses a time-based one-time password generated by an authenticator application.

The system should support recovery codes for users who lose access to their authenticator application.

Access to sensitive customer identification data must be restricted by role and recorded in the audit log.

## Staff Two-Factor Authentication

Two-factor authentication is required for employees and administrators in the production environment.

For local development and automated testing, the requirement may be disabled or replaced with a controlled test authentication mechanism.

Development and test authentication behavior must not create a bypass that can be enabled by an ordinary production user.

## Employee Reservation Cancellation

An employee can cancel a pending reservation or an approved reservation before the vehicle is handed over to the customer.

An employee cannot return an approved reservation to the pending status.

Employee cancellation requires a cancellation reason.

If an employee cancels a reservation, the customer receives a full refund regardless of the time remaining before the planned pickup.

The cancellation fee does not apply when the cancellation is performed by an employee.

## Reservation Conversion to Active Rental

After the vehicle is handed over to the customer, the reservation becomes an active rental.

An active rental cannot be cancelled.

The rental must be completed through the vehicle return process.

## Rental Extension Request

A customer can request an extension of an active rental.

The extension is not applied automatically and requires employee approval.

An employee reviews the request based on vehicle availability, future reservations and operational needs.

If the extension request is rejected, the employee must select a rejection reason and provide a justification.
