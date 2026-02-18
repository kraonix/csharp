using System;
using System.Linq;

class Program
{
    static HospitalManagementSystem hospital = new HospitalManagementSystem();

    static void Main()
    {
        SeedData.Initialize(hospital);
        while (true)
        {
            Console.WriteLine("\n===== HOSPITAL MANAGEMENT SYSTEM =====");
            Console.WriteLine("1. Add Doctor");
            Console.WriteLine("2. Remove Doctor");
            Console.WriteLine("3. Add Patient");
            Console.WriteLine("4. Remove Patient");
            Console.WriteLine("5. Schedule Appointment");
            Console.WriteLine("6. Doctors with >10 Appointments");
            Console.WriteLine("7. Patients Treated in Last 30 Days");
            Console.WriteLine("8. Group Appointments by Doctor");
            Console.WriteLine("9. Top 3 Highest Earning Doctors");
            Console.WriteLine("10. Patients by Disease");
            Console.WriteLine("11. Total Revenue");
            Console.WriteLine("0. Exit");
            Console.Write("Enter choice: ");

            int choice = int.Parse(Console.ReadLine());

            try
            {
                switch (choice)
                {
                    case 1: AddDoctor(); break;
                    case 2: RemoveDoctor(); break;
                    case 3: AddPatient(); break;
                    case 4: RemovePatient(); break;
                    case 5: ScheduleAppointment(); break;
                    case 6: DoctorsWithMoreAppointments(); break;
                    case 7: PatientsLast30Days(); break;
                    case 8: GroupAppointments(); break;
                    case 9: Top3Doctors(); break;
                    case 10: PatientsByDisease(); break;
                    case 11: TotalRevenue(); break;
                    case 0: return;
                    default: Console.WriteLine("Invalid choice."); break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }

    static void AddDoctor()
    {
        Console.Write("Id: ");
        int id = int.Parse(Console.ReadLine());
        Console.Write("Name: ");
        string name = Console.ReadLine();
        Console.Write("Phone: ");
        string phone = Console.ReadLine();
        Console.Write("Specialization: ");
        string spec = Console.ReadLine();
        Console.Write("Consultation Fee: ");
        decimal fee = decimal.Parse(Console.ReadLine());

        hospital.Doctors.Add(new Doctor
        {
            Id = id,
            Name = name,
            Phone = phone,
            Specialization = spec,
            ConsultationFee = fee
        });

        Console.WriteLine("Doctor added.");
    }

    static void RemoveDoctor()
    {
        Console.Write("Enter Doctor Id: ");
        int id = int.Parse(Console.ReadLine());

        var doctor = hospital.Doctors.FirstOrDefault(d => d.Id == id);
        if (doctor != null)
        {
            hospital.Doctors.Remove(doctor);
            Console.WriteLine("Doctor removed.");
        }
        else
            Console.WriteLine("Doctor not found.");
    }

    static void AddPatient()
    {
        Console.Write("Id: ");
        int id = int.Parse(Console.ReadLine());
        Console.Write("Name: ");
        string name = Console.ReadLine();
        Console.Write("Phone: ");
        string phone = Console.ReadLine();
        Console.Write("Disease: ");
        string disease = Console.ReadLine();

        hospital.Patients.Add(new Patient
        {
            Id = id,
            Name = name,
            Phone = phone,
            Disease = disease,
            LastVisit = DateTime.MinValue
        });

        Console.WriteLine("Patient added.");
    }

    static void RemovePatient()
    {
        Console.Write("Enter Patient Id: ");
        int id = int.Parse(Console.ReadLine());

        var patient = hospital.Patients.FirstOrDefault(p => p.Id == id);
        if (patient != null)
        {
            hospital.Patients.Remove(patient);
            Console.WriteLine("Patient removed.");
        }
        else
            Console.WriteLine("Patient not found.");
    }

    static void ScheduleAppointment()
    {
        Console.Write("Doctor Id: ");
        int docId = int.Parse(Console.ReadLine());
        Console.Write("Patient Id: ");
        int patId = int.Parse(Console.ReadLine());
        Console.Write("Date (yyyy-MM-dd HH:mm): ");
        DateTime date = DateTime.Parse(Console.ReadLine());

        hospital.ScheduleAppointment(docId, patId, date);
        Console.WriteLine("Appointment scheduled.");
    }

    static void DoctorsWithMoreAppointments()
    {
        var result = hospital.Appointments
            .GroupBy(a => a.DoctorId)
            .Where(g => g.Count() > 10)
            .Select(g => g.Key);

        foreach (var docId in result)
            Console.WriteLine($"DoctorId: {docId}");
    }

    static void PatientsLast30Days()
    {
        var result = hospital.Patients
            .Where(p => p.LastVisit >= DateTime.Now.AddDays(-30));

        foreach (var p in result)
            Console.WriteLine($"{p.Name} - Last Visit: {p.LastVisit}");
    }

    static void GroupAppointments()
    {
        var result = hospital.Appointments
            .GroupBy(a => a.DoctorId);

        foreach (var group in result)
        {
            Console.WriteLine($"\nDoctorId: {group.Key}");
            foreach (var appt in group)
                Console.WriteLine($"  AppointmentId: {appt.AppointmentId}, Date: {appt.AppointmentDate}");
        }
    }

    static void Top3Doctors()
    {
        var result = hospital.Appointments
            .GroupBy(a => a.DoctorId)
            .Select(g => new
            {
                DoctorId = g.Key,
                Earnings = g.Sum(a => a.BillAmount)
            })
            .OrderByDescending(x => x.Earnings)
            .Take(3);

        foreach (var doc in result)
            Console.WriteLine($"DoctorId: {doc.DoctorId}, Earnings: {doc.Earnings}");
    }

    static void PatientsByDisease()
    {
        var result = hospital.Patients
            .GroupBy(p => p.Disease);

        foreach (var group in result)
        {
            Console.WriteLine($"\nDisease: {group.Key}");
            foreach (var p in group)
                Console.WriteLine($"  {p.Name}");
        }
    }

    static void TotalRevenue()
    {
        var revenue = hospital.Appointments.Sum(a => a.BillAmount);
        Console.WriteLine($"Total Revenue: {revenue}");
    }
}
