interface Room
{
    public double calculateTotalBill(int nightsStayed, int joiningYear);
    public int calculateMembershipYears(int joiningYear);

}

class HotelRoom : Room
{
    public int currYear = 2026;
    public String roomType;
    public double ratePerNight;
    public String guestName;
    public int nightsStayed;
    public int joiningYear;

    public HotelRoom(string guestName, string roomType, double ratePerNight, int nightsStayed, int joiningYear)
    {
        this.guestName = guestName;
        this.roomType = roomType;
        this.ratePerNight = ratePerNight;
        this.nightsStayed = nightsStayed;
        this.joiningYear = joiningYear;
    }
    public double calculateTotalBill(int nightsStayed, int joiningYear)
    {
        if (calculateMembershipYears(joiningYear) > 3)
        {
            return 0.9 * ratePerNight * nightsStayed;
        }
        else
        {
            return ratePerNight * nightsStayed;
        }
    }
    public int calculateMembershipYears(int joiningYear)
    {
        return (currYear - joiningYear);
    }
}

class Program
{
    public static void Main(string[] args)
    {
        List<string> temp = new List<string> { "Deluxe Room", "Suite Room" };
        List<HotelRoom> hotelRooms = new List<HotelRoom>();

        for (int i = 0; i < 2; i++)
        {
            Console.WriteLine($"\nEnter {temp[i]} Details: ");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Rate per Night: ");
            double ratePerNight = double.Parse(Console.ReadLine());
            Console.Write("Nights Stayed: ");
            int nightsStayed = int.Parse(Console.ReadLine());
            Console.Write("Joining Year: ");
            int joiningYear = int.Parse(Console.ReadLine());

            hotelRooms.Add(new HotelRoom(name, temp[i], ratePerNight, nightsStayed, joiningYear));
        }

        Console.WriteLine("\nRoom Summary:");
        foreach (var v in hotelRooms)
        {
            Console.WriteLine($"{v.roomType}: {v.guestName}, {v.ratePerNight} per night, Membership: {v.calculateMembershipYears(v.joiningYear)} years");
        }

        Console.WriteLine("\nTotal Bill: ");
        foreach (var v in hotelRooms)
        {
            Console.WriteLine($"For {v.guestName} ({v.roomType}): {v.calculateTotalBill(v.nightsStayed, v.joiningYear)}");
        }
    }
}