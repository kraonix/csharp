public class HospitalManagementSystem
{
    public List<Doctor> Doctors = new();
    public List<Patient> Patients = new();
    public List<Appointment> Appointments = new();
    public Dictionary<int, MedicalRecord> MedicalRecords = new();

    public void ScheduleAppointment(int doctorId, int patientId, DateTime date)
    {
        var doctor = Doctors.FirstOrDefault(d => d.Id == doctorId);
        if (doctor == null)
            throw new DoctorNotAvailableException("Doctor not found.");

        var patient = Patients.FirstOrDefault(p => p.Id == patientId);
        if (patient == null)
            throw new PatientNotFoundException("Patient not found.");

        bool overlap = Appointments.Any(a =>
            a.DoctorId == doctorId &&
            a.AppointmentDate == date);

        if (overlap)
            throw new DoctorNotAvailableException("Doctor already has appointment at this time.");

        Appointment appt = new Appointment
        {
            AppointmentId = Appointments.Count + 1,
            DoctorId = doctorId,
            PatientId = patientId,
            AppointmentDate = date,
            BillAmount = doctor.CalculateBill()
        };

        Appointments.Add(appt);
        patient.LastVisit = date;
    }
}
