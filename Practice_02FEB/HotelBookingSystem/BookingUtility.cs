namespace HBS
{
    public class BookingUtility
    {
        //Rooms Collection
        private List<Room> rooms = new List<Room>();

        //Rooms Count
        public int RoomCount()
        {
            return rooms.Count;
        }

        // Room Add
        public void AddRoom(int roomNumber, string type, double price)
        {
            bool IsPresent = true;
            foreach (var room in rooms)
            {
                if (roomNumber == room.RoomNumber)
                {
                    IsPresent = false;
                    break;
                }
            }

            if (IsPresent == true)
            {
                Room room = new Room()
                {
                    RoomNumber = roomNumber,
                    RoomType = type,
                    PricePerNight = price,
                    IsAvailable = true
                };

                rooms.Add(room);
            }
            else
            {
                Console.WriteLine("Room with this Room Number already EXISTS!");
            }
        }

        //Groups Available Rooms By Type
        public Dictionary<string, List<Room>> GroupRoomsByType()
        {
            Dictionary<string, List<Room>> result = new Dictionary<string, List<Room>>();

            foreach (var room in rooms)
            {
                if (!result.ContainsKey(room.RoomType) && room.IsAvailable)
                    result[room.RoomType] = new List<Room>();

                result[room.RoomType].Add(room);
            }

            return result;
        }

        // Books room if available, calculates total cost
        public bool BookRoom(int roomNumber, int nights)
        {
            bool Booked = false;
            double TotalCost;
            foreach(var room in rooms)
            {
                if(roomNumber == room.RoomNumber)
                {
                    if (room.IsAvailable)
                    {
                        room.IsAvailable = false;
                        Booked = true;
                        TotalCost = room.PricePerNight * nights;
                        Console.WriteLine($"\n#{roomNumber}, Room Booked Successfully!\nTotal Cost: ₹{TotalCost}");
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"#{roomNumber}, Room is already Booked!");
                        Booked = true;
                        break;
                    }
                }
            }

            return Booked;
        }

        // Returns available rooms within price range
        public List<Room> GetAvailableRoomsByPriceRange(double min, double max)
        {
            List<Room> result = new List<Room>();
            double minRate = min;
            double maxRate = max;

            foreach(var room in rooms)
            {
                if(room.PricePerNight >= minRate && room.PricePerNight <= maxRate)
                {
                    result.Add(room);
                }
            }

            return result;
        }
    }
}