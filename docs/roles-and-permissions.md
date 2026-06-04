# Roles and Permissions

## Employee

An employee performs the daily operational work of a rental branch.

An employee can:

- review pending reservations,
- approve reservations,
- assign and change vehicles assigned to reservations,
- cancel reservations with a required cancellation reason,
- hand over vehicles to customers,
- receive returned vehicles,
- record payments,
- create customer profiles,
- register vehicles received by their branch,
- manage vehicles assigned to their branch,
- record vehicle mileage during pickup and return,
- report vehicle damages and mechanical issues,
- create vehicle-related cases,
- plan vehicle relocations between branches,
- process post-rental tasks,
- review reported damages,
- decide whether a customer should be charged for damage.

Vehicle-related cases may include:

- mechanical issues,
- collision or exterior damage,
- mandatory vehicle inspections,
- periodic technical maintenance,
- administrative matters.

An employee cannot freely modify historical mileage records. Corrections require administrator permissions and must be recorded in the audit log.

## Customer Data Management

An employee can create and update customer data required for rental operations.

Changes to sensitive customer identification data must be recorded in the audit log.

The system records the employee, timestamp, changed field and reason for the change when applicable.

Sensitive values should be masked in the user interface and should not be exposed in ordinary application logs.
