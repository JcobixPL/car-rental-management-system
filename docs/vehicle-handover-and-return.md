# Vehicle Handover and Return

## Vehicle Handover

Before a vehicle is handed over to a customer, an employee records the vehicle condition.

The handover record includes:

- current mileage,
- fuel level,
- existing damage list,
- vehicle equipment checklist,
- handover date and time,
- employee performing the handover,
- customer confirmation.

A vehicle cannot be handed over without a specific vehicle assigned to the reservation.

After the handover is completed, the reservation is converted into an active rental.

## Vehicle Photos

Vehicle condition photos are not included in the MVP.

The MVP uses structured damage and equipment records instead.

Photo documentation may be added in a future version.

## Vehicle Equipment Checklist

Each vehicle has an equipment checklist used during vehicle handover and return.

The default equipment checklist includes:

- vehicle registration document,
- liability insurance policy,
- fire extinguisher,
- warning triangle,
- first aid kit,
- tire repair kit or spare wheel,
- tool kit,
- vehicle documentation.

Each equipment item can be marked as present or missing.

An equipment item can be configured as required for vehicle handover.

By default, the fire extinguisher and warning triangle are required for handover.

A missing non-required equipment item does not block vehicle handover, but the missing item must be recorded.

## Missing Equipment After Return

If an equipment item was present during vehicle handover but is missing during vehicle return, the system creates a post-rental review task.

The employee reviews the missing item and decides whether to:

- charge the customer,
- waive the charge,
- create a vehicle case.

The decision, reason and employee must be recorded.

## Post-Rental Charges

After vehicle return, the system calculates proposed charges for:

- missing fuel,
- exceeded mileage limits,
- missing equipment,
- reported damages,
- other rental-related issues.

Proposed charges are not applied automatically.

An employee must review each proposed charge and can:

- approve the proposed amount,
- change the amount with a required justification,
- waive the charge with a required justification.

The system records the employee, original proposed amount, final amount, decision, reason and timestamp.
