namespace HBS
{
    public class Room
    {
        public int RoomNumber { get; set; }
        required public string RoomType { get; set; }
        public double PricePerNight { get; set; }
        public bool IsAvailable { get; set; }
    }
}