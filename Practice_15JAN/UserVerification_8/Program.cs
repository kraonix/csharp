namespace UserVerification
{
    public class User
    {
        public string? Name { get; set; }
        public string? PhoneNumber { get; set; }
    }

    public class InvalidPhoneNumberException: Exception
    {
        public InvalidPhoneNumberException(string msg) : base(msg){}
    }

    public class Program
    {
        public static User ValidatePhoneNumber(string name, string phoneNumber)
        {
            User user = new User()
            {
                Name = name,
                PhoneNumber = phoneNumber
            };

            if (phoneNumber.Length != 10)
            {
                throw new InvalidPhoneNumberException("Phone Number Should Have 10 Digits!!!");
            }
            return user;
        }

        public static void Main()
        {
            try
            {
                Console.Write($"\nEnter Name: ");
                string name = Console.ReadLine();
                Console.Write("Enter PhoneNumber: ");
                string phoneNumber = Console.ReadLine();
                User user = ValidatePhoneNumber(name, phoneNumber);
                Console.WriteLine("Account Created Successfully!!!");
            }
            catch (InvalidPhoneNumberException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}