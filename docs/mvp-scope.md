# MVP Scope

## Goal

The first version of the Car Rental Management System must support the complete operational process of managing vehicles, reservations, rentals and vehicle availability.

## Included in MVP

### Branch and Staff Management

- An administrator can create and manage rental branches.
- An administrator can create and manage employee accounts.
- An administrator can assign employees to branches.

### Vehicle Management

- An employee can register a new vehicle received by their branch.
- An employee can manage vehicles assigned to their branch.
- An administrator can withdraw or block a vehicle from future reservations.
- The system tracks vehicle availability.
- A vehicle that is unavailable cannot be assigned to a new reservation.

### Vehicle Cases

- An employee can create a case related to a vehicle.
- A case can make a vehicle temporarily unavailable.
- Employees can manage the lifecycle of vehicle cases.
- Vehicle cases can include mechanical issues, damages, inspections, maintenance and administrative matters.

### Reservation Management

- A customer can create a reservation for a vehicle category.
- The customer selects a pickup branch, return branch and rental period.
- An employee can review pending reservations.
- An employee can approve a reservation and assign a specific vehicle.
- An employee can cancel a reservation with a required reason.

### Rental Process

- An employee can hand over a vehicle to the customer.
- An approved reservation becomes an active rental after vehicle pickup.
- An employee can receive a returned vehicle.
- The system completes the rental after the return process.

## Excluded from the First MVP

The following features are planned for later iterations:

- real external payment gateway integration,
- advanced insurance package processing,
- automated refunds,
- customer blacklist automation,
- two-factor authentication,
- advanced reporting and statistics,
- long-term rental support.
