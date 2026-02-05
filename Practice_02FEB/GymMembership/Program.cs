using System;
using System.Collections.Generic;
using System.Linq;
namespace GymMembership
{
    class Program
    {
        static void Main()
        {
            GymManager manager = new GymManager();
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\n=== GYM MEMBERSHIP MANAGEMENT ===");
                Console.WriteLine("1. Add Member");
                Console.WriteLine("2. Add Fitness Class");
                Console.WriteLine("3. Register Member for Class");
                Console.WriteLine("4. Group Members by Membership Type");
                Console.WriteLine("5. View Upcoming Classes");
                Console.WriteLine("6. View All Members");
                Console.WriteLine("0. Exit");
                Console.Write("Choice: ");

                int choice = int.Parse(Console.ReadLine());

                try
                {
                    switch (choice)
                    {
                        case 1:
                            Console.Write("Name: ");
                            string name = Console.ReadLine();
                            Console.Write("Membership Type (Basic/Premium/Platinum): ");
                            string type = Console.ReadLine();
                            Console.Write("Duration (months): ");
                            int months = int.Parse(Console.ReadLine());
                            manager.AddMember(name, type, months);
                            Console.WriteLine("Member added");
                            break;

                        case 2:
                            Console.Write("Class Name: ");
                            string cname = Console.ReadLine();
                            Console.Write("Instructor: ");
                            string instructor = Console.ReadLine();
                            Console.Write("Schedule (yyyy-MM-dd HH:mm): ");
                            DateTime schedule = DateTime.Parse(Console.ReadLine());
                            Console.Write("Max Participants: ");
                            int max = int.Parse(Console.ReadLine());
                            manager.AddClass(cname, instructor, schedule, max);
                            Console.WriteLine("Class added");
                            break;

                        case 3:
                            Console.Write("Member ID: ");
                            int mid = int.Parse(Console.ReadLine());
                            Console.Write("Class Name: ");
                            string cls = Console.ReadLine();
                            bool registered = manager.RegisterForClass(mid, cls);
                            Console.WriteLine(registered ? "Registration successful" : "Class full");
                            break;

                        case 4:
                            var grouped = manager.GroupMembersByMembershipType();
                            foreach (var g in grouped)
                            {
                                Console.WriteLine($"\n{g.Key}:");
                                foreach (var m in g.Value)
                                    Console.WriteLine($"{m.MemberId} - {m.Name}");
                            }
                            break;

                        case 5:
                            foreach (var c in manager.GetUpcomingClasses())
                                Console.WriteLine($"{c.ClassName} | {c.Schedule} | Seats Left: {c.MaxParticipants - c.RegisteredMembers.Count}");
                            break;

                        case 6:
                            foreach (var m in manager.GetAllMembers())
                                Console.WriteLine($"{m.MemberId} | {m.Name} | Expires: {m.ExpiryDate}");
                            break;

                        case 0:
                            exit = true;
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