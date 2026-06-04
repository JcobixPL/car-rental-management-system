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

## Deposit and Post-Rental Balance

A vehicle deposit is a security amount collected during vehicle pickup.

Approved post-rental charges can be deducted from the deposit.

If the approved charges exceed the available deposit amount, the remaining amount becomes an outstanding customer balance.

If the deposit exceeds the approved charges, the remaining deposit amount is returned to the customer.

An outstanding post-rental balance must be paid within the configured payment period.

The default payment period is 7 days.

## Damage Liability and Insurance Deductible

Damage charges depend on the insurance package selected for the rental and the applicable coverage rules.

An insurance package can define a customer deductible.

The deductible limits the customer's liability for a covered damage event.

The deposit amount and the insurance deductible are separate values.

If a damage is excluded from insurance coverage, the customer may be responsible for the full approved damage cost.

All damage charges must be reviewed and approved by an employee before they are applied.

## Insurance Deductible Configuration

The insurance deductible depends on both the vehicle category and the insurance package selected for the rental.

An administrator configures the deductible amount for each supported vehicle category and insurance package combination.

The applicable deductible amount is stored as part of the rental terms when the insurance package is selected.

Later changes to the deductible configuration do not affect existing reservations or rentals.

## Rental-Level Insurance Deductible

The insurance deductible applies to the entire rental rather than separately to each damage event.

For damages covered by the selected insurance package, the customer's total liability during a single rental cannot exceed the stored deductible amount.

Damages excluded from insurance coverage are not limited by the deductible and may result in full customer liability.
