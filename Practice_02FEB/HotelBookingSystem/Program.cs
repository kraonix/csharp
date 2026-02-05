namespace HBS
{
    class Program
    {
        static void Main()
        {
            BookingUtility booking = new BookingUtility();

            // 1. Add books
            booking.AddRoom(101, "Deluxe", 2000);
            booking.AddRoom(102, "Suite", 3200);
            booking.AddRoom(103, "Suite", 3000);
            booking.AddRoom(104, "Simple", 1000);

            // 2. Display books grouped by genre
            Console.WriteLine("\n--- Books Grouped by Type ---");
            var grouped = booking.GroupRoomsByType();

            foreach (var type in grouped)
            {
                Console.WriteLine("\n" + type.Key + ":");
                foreach (var room in type.Value)
                {
                    Console.WriteLine($"#{room.RoomNumber}: {room.RoomType} (₹{room.PricePerNight} per Night)");
                }
            }

            // 3. Book Room
            var Booked = booking.BookRoom(101, 5);
            if(!Booked) Console.WriteLine("No Room With this Room Number is on LisT :(");
            

            // 4. Range
            Console.WriteLine("\n--- Rooms In Range ---");
            Console.WriteLine("Total Rooms: " + booking.RoomCount());
            var filtered = booking.GetAvailableRoomsByPriceRange(2000, 3000);

            foreach (var room in filtered)
            {
                Console.WriteLine($"#{room.RoomNumber} | {room.RoomType} | {room.PricePerNight}");
            }
        }
    }
}