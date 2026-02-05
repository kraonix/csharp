using System;
using System.Collections.Generic;
using System.Linq;
namespace HospitalManagement
{
    class HospitalManager
    {
        private List<Patient> patients = new List<Patient>();
        private List<Doctor> doctors = new List<Doctor>();
        private List<Appointment> appointments = new List<Appointment>();

        private int patientIdCounter = 1;
        private int doctorIdCounter = 1;
        private int appointmentIdCounter = 1;

        public void AddPatient(string name, int age, string bloodGroup)
        {
            patients.Add(new Patient
            {
                PatientId = patientIdCounter++,
                Name = name,
                Age = age,
                BloodGroup = bloodGroup
            });
        }

        public void AddDoctor(string name, string specialization)
        {
            doctors.Add(new Doctor
            {
                DoctorId = doctorIdCounter++,
                Name = name,
                Specialization = specialization
            });
        }

        public bool ScheduleAppointment(int patientId, int doctorId, DateTime time)
        {
            Patient patient = patients.FirstOrDefault(p => p.PatientId == patientId);
            Doctor doctor = doctors.FirstOrDefault(d => d.DoctorId == doctorId);

            if (patient == null || doctor == null)
                throw new Exception("Patient or Doctor not found");

            if (appointments.Any(a => a.DoctorId == doctorId && a.AppointmentTime == time))
                return false;

            appointments.Add(new Appointment
            {
                AppointmentId = appointmentIdCounter++,
                PatientId = patientId,
                DoctorId = doctorId,
                AppointmentTime = time,
                Status = "Scheduled"
            });

            return true;
        }

        public Dictionary<string, List<Doctor>> GroupDoctorsBySpecialization()
        {
            return doctors
                .GroupBy(d => d.Specialization)
                .ToDictionary(g => g.Key, g => g.ToList());
        }

        public List<Appointment> GetTodayAppointments()
        {
            DateTime today = DateTime.Today;
            return appointments
                .Where(a => a.AppointmentTime.Date == today)
                .ToList();
        }

        public List<Patient> GetAllPatients() => patients;
        public List<Doctor> GetAllDoctors() => doctors;
    }

}
