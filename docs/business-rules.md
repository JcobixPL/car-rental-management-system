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

## Short-Term Rental Duration

The maximum duration of a single short-term rental is configured by an administrator.

The default maximum rental duration is 60 days.

An approved rental extension uses the pricing rules from the original reservation.

If the customer wants to rent the vehicle beyond the maximum rental duration, the current rental must be completed and a new reservation must be created using the current pricing configuration.

## Reservation Booking Window

The maximum time in advance that a customer can create a reservation is configured by an administrator.

The default booking window is 3 months.

## Customer Outstanding Balance and Future Reservations

A customer can have multiple future reservations.

If a customer receives an outstanding balance for a late cancellation and does not pay it, the system blocks the customer from creating new reservations.

The system also cancels the customer's future reservations.

Automatically cancelled reservations must include a cancellation reason indicating that the customer has an unpaid outstanding balance.

If a future reservation was paid in advance, the customer receives a refund according to the applicable refund rules.

The system records the automatic cancellation in the audit log.

## Outstanding Balance Payment Grace Period

When an outstanding balance is created, the customer has a limited time to pay it.

The default payment grace period is 48 hours and can be configured by an administrator.

During the grace period, the customer cannot create new reservations, but existing future reservations remain active.

If the outstanding balance is fully paid before the deadline, the customer's future reservations remain unchanged.

If the outstanding balance is not paid before the deadline, the system automatically cancels the customer's future reservations.

## Outstanding Balance Before Vehicle Pickup

A customer with an unpaid outstanding balance cannot pick up a vehicle.

If a future reservation starts before the outstanding balance payment deadline, the customer must pay the outstanding balance before the planned pickup time.

If the outstanding balance is not paid before the planned pickup time, that reservation is automatically cancelled.

Other future reservations remain active until the outstanding balance payment deadline expires.

## Outstanding Balance Resolution

A customer cannot be manually unblocked while an unpaid outstanding balance exists.

The reservation block is removed only when:

- the outstanding balance is fully paid,
- the outstanding balance is cancelled because it was created incorrectly,
- an administrator corrects the outstanding balance to zero with a required justification.

All outstanding balance corrections and cancellations must be recorded in the audit log.

## Branch Card Payment Processing

Card payments at a rental branch are processed through a simulated payment terminal.

An employee can initiate a payment, but cannot manually mark the payment as completed.

The simulated terminal returns a payment result, such as approved or declined.

The system records the payment result, timestamp and employee who initiated the transaction.

## Payment Attempt History

Each payment attempt creates a separate immutable history record.

A payment attempt record includes:

- payment method,
- requested amount,
- result status,
- timestamp,
- employee who initiated the transaction, when applicable,
- failure reason, when available.

Failed payment attempts cannot be deleted or changed.

Payment attempt history is separate from the technical application logs and the audit log.

## Payment Retry

A customer can retry a failed payment and may choose a different supported payment method.

Each payment attempt is recorded as a separate history entry.

## Customer Self-Service Data Changes

A customer can update their own contact data, including email address and phone number.

Changes to customer contact data must be recorded in the audit history.

The system records the changed field, previous value, new value and timestamp.

A new email address or phone number must be verified before it becomes the active contact value.

## Customer Identification Data Changes

A customer cannot independently change sensitive identification data, including:

- national identification number,
- passport number,
- driving license number.

Sensitive identification data can only be updated by an employee after verifying the relevant document.

The system records the employee, timestamp, changed field and verification reason in the audit log.

## Customer Profile Retention

Customer profiles are not deleted through ordinary application operations.

A customer profile can be active, blocked or blacklisted.

Customer rental history must remain available for operational, accounting and legal purposes for the configured retention period.

After the retention period expires and there is no legal or business reason to keep the personal data, the customer profile should be anonymized.

Anonymization must preserve historical rental records while removing or replacing personal identification data.

## Customer Blacklist

An employee or administrator can add a customer to the blacklist.

Adding a customer to the blacklist requires a selected reason and an additional comment.

The system records the user who performed the action, timestamp and reason in the audit log.

A blacklisted customer cannot create new reservations.

## Customer Blacklist Removal

An employee or administrator can remove a customer from the blacklist.

Removing a customer from the blacklist requires a reason and an additional comment.

The system records the user who performed the action, timestamp and reason in the audit log.

## Blacklisted Customer Account Access

A blacklisted customer can still sign in and view their previous reservations, rental history and outstanding balances.

A blacklisted customer cannot create new reservations.

## Blacklist Impact on Future Reservations

When a customer is added to the blacklist, the system blocks the customer from creating new reservations.

The system automatically cancels all future reservations belonging to the blacklisted customer.

Automatically cancelled reservations must include a cancellation reason indicating that the customer was blacklisted.

If a cancelled reservation was paid in advance, the customer receives a full refund.

The system records the automatic cancellations in the audit log.

## Blacklisting During Active Rental

A customer can be added to the blacklist during an active rental.

Blacklisting does not cancel or terminate the active rental.

The customer must return the vehicle according to the rental agreement.

The system blocks new reservations, cancels future reservations and displays a warning to employees handling the active rental and vehicle return.

## Out-of-Hours Pickup and Return

A customer can select any pickup or return time.

If the selected pickup or return time is outside the branch opening hours, an additional out-of-hours service fee applies.

The out-of-hours service fee is configured by an administrator.

The applicable fee is stored as part of the reservation price snapshot.

Out-of-hours pickup and return do not require employee approval.

The service is always available when the applicable fee is added to the reservation.

## Insurance Payment

Insurance is charged for each rental day.

The customer pays for insurance in advance for the planned rental period.

If the rental is extended, the insurance remains active and the customer pays for the additional insurance days after vehicle return.

The daily insurance price used for additional days is the price stored when the insurance package was selected.

## Insurance Refund for Early Return

If a customer returns the vehicle earlier than planned, the customer receives a refund for unused insurance days.

The refund is calculated using the daily insurance price stored when the insurance package was selected.

Only full unused rental days are eligible for a refund.

## Rental Refund for Early Return

If a customer returns the vehicle earlier than planned, the customer receives a refund for unused rental days.

The refund is calculated as the difference between:

- the rental price paid for the planned rental period,
- the rental price applicable to the actual rental period.

The actual rental price is recalculated using the pricing snapshot stored when the reservation was created.

Later pricing changes do not affect the refund calculation.

Only full unused rental days are eligible for a refund.
