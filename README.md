# ModularMonolith
Modular Monolith Course Assessment
# ModularMonolith
Modular Monolith Course Assessment

## Doctor Availability

### Features for Doctors:
- **List Slots**: As a doctor, you can list all your available time slots.
- **Add New Slots**: As a doctor, you can add new available time slots. Each time slot includes:
  - `Id`: Unique identifier (Guid)
  - `Time`: Date and time (e.g., 22/02/2023 04:30 pm)
  - `DoctorId`: Unique identifier of the doctor (Guid)
  - `DoctorName`: Name of the doctor (string)
  - `IsReserved`: Slot reservation status (bool)
  - `Cost`: Cost of the appointment (Decimal)

## Appointment Booking

### Features for Patients:
- **View Available Slots**: As a patient, you can view all available slots for all doctors.
- **Book Appointment**: As a patient, you can book an appointment in a free slot. Each appointment includes:
  - `Id`: Unique identifier (Guid)
  - `SlotId`: Unique identifier of the slot (Guid)
  - `PatientId`: Unique identifier of the patient (Guid)
  - `PatientName`: Name of the patient (string)
  - `ReservedAt`: Date and time when the appointment was reserved (Date)

## Appointment Confirmation

- **Notification**: Once an appointment is scheduled, the system sends a confirmation notification to the patient and the doctor. The notification includes:
  - Patient's name
  - Appointment time
  - Doctor's name
- **Notification Method**: For this assessment, the notification can be logged as a message.

## Doctor Appointment Management

### Features for Doctors:
- **View Upcoming Appointments**: As a doctor, you can view all your upcoming appointments.
- **Manage Appointments**: As a doctor, you can mark appointments as completed or cancel them if necessary.

## Data Persistence

- Use any database engine or an in-memory list with no database at all to persist data.

This README outlines the key features and requirements for managing doctor availability, appointment booking, and appointment management within the Modular Monolith application.
