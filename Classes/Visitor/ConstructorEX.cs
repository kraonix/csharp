namespace Example.ConstructorEX
{
    public class Visitor
    {
        // Parent Class
        public int ID {get; set;}
        public string Name {get; set;}
        public string Requirement {get; set;}
        public string Logs {get; set;}

        // Constructors
        private Visitor()                                                                   // Default Constructor
        {
            Logs += $"Object Created at {DateTime.Now}{Environment.NewLine}";
        }

        public Visitor(int id) : this()                                                     // Parameterized Constructor
        {
            Logs += $"ID Created at {DateTime.Now}{Environment.NewLine}";

            if (id <= 0) 
                throw new ArgumentException("\nID should be greater than 0\n");
            this.ID = id;
        }

        public Visitor(int id, string name) : this(id)                                      // Parameterized Constructor
        {
            Logs += $"Name Added at {DateTime.Now}{Environment.NewLine}";

            if (name.ToLower().Contains("idiot")) 
                throw new ArgumentException("\nPlease type a Proper Name\n");
            this.Name = name;
        }
        public Visitor(int id, string name, string requirement) : this(id, name)             // Parameterized Constructor
        {
            Logs += $"Requirement added at {DateTime.Now}{Environment.NewLine}";

            if (requirement.ToLower().Contains("Commerce")) 
                throw new ArgumentException("\nNo Commerce Please!\n");
            this.Requirement = requirement;
        }
    }
}