# Product Vision

## Project Name

Car Rental Management System (CRMS)

## User Roles

* Administrator
* Employee
* Customer

## Business Context

The system is designed for a single car rental company operating multiple branches in different cities.

Each deployment of the application and its database belongs to one rental company.

Customers can pick up a vehicle at one branch and return it at another branch.

## Reservation Context

During the reservation process, the customer selects a pickup branch and sees vehicles available at that location.

The customer can select a return branch different from the pickup branch.

## Vehicle Reservation Model

Customers reserve a vehicle category rather than a specific vehicle.

The system checks the expected availability of the selected vehicle category for the requested pickup branch and rental period.

A specific vehicle is assigned to the reservation by an employee before pickup.

If no vehicle from the reserved category is available, an employee may assign a vehicle from a higher category without increasing the customer's price.

Reservation cancellation due to vehicle unavailability should be treated as an exceptional situation.

## Reservation Approval Process

After a customer creates a reservation, it is added to the list of pending reservations.

An employee reviews the reservation before the planned pickup date.

An employee can approve the reservation based on the expected availability of the reserved vehicle category.

A specific vehicle does not need to be assigned at the moment the reservation is approved.

A specific available vehicle from any category can be assigned to the reservation by an employee.

The customer always pays the price of the originally reserved vehicle category.

If no suitable vehicle is available before pickup, the employee may cancel the reservation and must provide a cancellation reason.

Vehicle Assignment Changes

An employee may change the vehicle assigned to an approved reservation before the vehicle is handed over to the customer.

The assigned vehicle cannot belong to a category lower than the category reserved by the customer.

If a higher-category vehicle was assigned because the reserved category was unavailable, the employee may later replace it with a vehicle from the originally reserved category.

The system should record the history of vehicle assignment changes, including the employee, previous vehicle, new vehicle, timestamp and reason.

## Reservation Pricing and Vehicle Upgrade

The customer pays the price of the vehicle category selected during the reservation.

If an employee assigns a vehicle from a higher category, the customer is not charged an additional fee.

The employee may decide to assign a higher-category vehicle without increasing the price or cancel the reservation if no suitable vehicle is available.

Reservation cancellation requires a selected cancellation reason and may include an additional comment.

