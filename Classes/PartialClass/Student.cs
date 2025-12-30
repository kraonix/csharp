namespace PartialClass
{
    public partial class Student
    {
        //Properties
        private int? Roll{get; set;}
        public string? Name{get; set;}

        //Display Method
        public void Display()
        {
            Console.WriteLine("\n---- Details ----");
            Console.WriteLine($"Roll no. {Roll} => {Name}\n");
        }
    }
}