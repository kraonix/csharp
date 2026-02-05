using System;
using System.Collections.Generic;
using System.Linq;
namespace HospitalManagement
{
    class Program
{
    static void Main()
    {
        HospitalManager manager = new HospitalManager();
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\n=== HOSPITAL PATIENT MANAGEMENT SYSTEM ===");
            Console.WriteLine("1. Add Patient");
            Console.WriteLine("2. Add Doctor");
            Console.WriteLine("3. Schedule Appointment");
            Console.WriteLine("4. View Doctors by Specialization");
            Console.WriteLine("5. View Today's Appointments");
            Console.WriteLine("6. View All Patients");
            Console.WriteLine("7. View All Doctors");
            Console.WriteLine("0. Exit");
            Console.Write("Choice: ");

            int choice = int.Parse(Console.ReadLine());

            try
            {
                switch (choice)
                {
                    case 1:
                        Console.Write("Patient Name: ");
                        string pname = Console.ReadLine();
                        Console.Write("Age: ");
                        int age = int.Parse(Console.ReadLine());
                        Console.Write("Blood Group: ");
                        string blood = Console.ReadLine();
                        manager.AddPatient(pname, age, blood);
                        Console.WriteLine("Patient registered");
                        break;

                    case 2:
                        Console.Write("Doctor Name: ");
                        string dname = Console.ReadLine();
                        Console.Write("Specialization: ");
                        string spec = Console.ReadLine();
                        manager.AddDoctor(dname, spec);
                        Console.WriteLine("Doctor added");
                        break;

                    case 3:
                        Console.Write("Patient ID: ");
                        int pid = int.Parse(Console.ReadLine());
                        Console.Write("Doctor ID: ");
                        int did = int.Parse(Console.ReadLine());
                        Console.Write("Appointment Time (yyyy-MM-dd HH:mm): ");
                        DateTime time = DateTime.Parse(Console.ReadLine());

                        bool scheduled = manager.ScheduleAppointment(pid, did, time);
                        Console.WriteLine(scheduled ? "Appointment scheduled" : "Slot already booked");
                        break;

                    case 4:
                        var grouped = manager.GroupDoctorsBySpecialization();
                        foreach (var g in grouped)
                        {
                            Console.WriteLine($"\n{g.Key}:");
                            foreach (var d in g.Value)
                                Console.WriteLine($"{d.DoctorId} - {d.Name}");
                        }
                        break;

                    case 5:
                        var today = manager.GetTodayAppointments();
                        foreach (var a in today)
                            Console.WriteLine($"Appointment {a.AppointmentId} | Patient {a.PatientId} | Doctor {a.DoctorId} | {a.AppointmentTime}");
                        break;

                    case 6:
                        foreach (var p in manager.GetAllPatients())
                            Console.WriteLine($"{p.PatientId} | {p.Name} | {p.BloodGroup}");
                        break;

                    case 7:
                        foreach (var d in manager.GetAllDoctors())
                            Console.WriteLine($"{d.DoctorId} | {d.Name} | {d.Specialization}");
                        break;

                    case 0:
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
}