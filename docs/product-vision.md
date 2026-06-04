# Product Vision

## Project Name

Car Rental Management System (CRMS)

## User Roles

- Administrator
- Employee
- Customer

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
