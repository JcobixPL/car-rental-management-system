# Reservation and Rental Lifecycle

## Reservation Statuses

A reservation can have one of the following statuses:

- PendingApproval,
- Confirmed,
- Cancelled,
- ConvertedToRental.

### PendingApproval

The customer created a reservation, but an employee has not reviewed it yet.

### Confirmed

An employee approved the reservation and assigned a specific vehicle.

### Cancelled

The reservation was cancelled before the vehicle was handed over to the customer.

### ConvertedToRental

The vehicle was handed over to the customer and the reservation was converted into an active rental.

## Rental Statuses

A rental can have one of the following statuses:

- Active,
- Completed.

### Active

The vehicle has been handed over to the customer.

### Completed

The vehicle has been returned and the rental process has been completed.
