using System;

public static class SeedData
{
    public static void Initialize(HospitalManagementSystem hospital)
    {
        // Doctors
        hospital.Doctors.AddRange(new List<Doctor>
        {
            new Doctor { Id = 1, Name = "Dr. Sharma", Phone = "9991110001", Specialization = "Cardiology", ConsultationFee = 800 },
            new Doctor { Id = 2, Name = "Dr. Mehta", Phone = "9991110002", Specialization = "Orthopedics", ConsultationFee = 600 },
            new Doctor { Id = 3, Name = "Dr. Rao", Phone = "9991110003", Specialization = "Neurology", ConsultationFee = 1000 },
            new Doctor { Id = 4, Name = "Dr. Kapoor", Phone = "9991110004", Specialization = "General", ConsultationFee = 500 }
        });

        // Patients
        hospital.Patients.AddRange(new List<Patient>
        {
            new Patient { Id = 1, Name = "Sachin", Phone = "8880001111", Disease = "Heart Issue", LastVisit = DateTime.Now.AddDays(-5) },
            new Patient { Id = 2, Name = "Neeraj", Phone = "8880002222", Disease = "Fracture", LastVisit = DateTime.Now.AddDays(-20) },
            new Patient { Id = 3, Name = "Arzoo", Phone = "8880003333", Disease = "Migraine", LastVisit = DateTime.Now.AddDays(-40) },
            new Patient { Id = 4, Name = "Raj", Phone = "8880004444", Disease = "Cold", LastVisit = DateTime.Now.AddDays(-2) }
        });

        // Appointments (sample revenue data)
        hospital.Appointments.AddRange(new List<Appointment>
        {
            new Appointment { AppointmentId = 1, DoctorId = 1, PatientId = 1, AppointmentDate = DateTime.Now.AddDays(-5), BillAmount = 800 },
            new Appointment { AppointmentId = 2, DoctorId = 2, PatientId = 2, AppointmentDate = DateTime.Now.AddDays(-20), BillAmount = 600 },
            new Appointment { AppointmentId = 3, DoctorId = 3, PatientId = 3, AppointmentDate = DateTime.Now.AddDays(-40), BillAmount = 1000 },
            new Appointment { AppointmentId = 4, DoctorId = 4, PatientId = 4, AppointmentDate = DateTime.Now.AddDays(-2), BillAmount = 500 },
            new Appointment { AppointmentId = 5, DoctorId = 1, PatientId = 4, AppointmentDate = DateTime.Now.AddDays(-1), BillAmount = 800 },
            new Appointment { AppointmentId = 6, DoctorId = 1, PatientId = 2, AppointmentDate = DateTime.Now.AddDays(-3), BillAmount = 800 },
            new Appointment { AppointmentId = 7, DoctorId = 1, PatientId = 3, AppointmentDate = DateTime.Now.AddDays(-4), BillAmount = 800 }
        });

        // Medical Records
        hospital.MedicalRecords.Add(1, new MedicalRecord(1, 1) { Diagnosis = "Dengue", Treatment = "Medication" });
        hospital.MedicalRecords.Add(2, new MedicalRecord(2, 2) { Diagnosis = "Leg Fracture", Treatment = "Cast" });
        hospital.MedicalRecords.Add(3, new MedicalRecord(3, 3) { Diagnosis = "Migraine", Treatment = "Therapy" });

        Console.WriteLine("\nSample data loaded successfully.");
    }
}
