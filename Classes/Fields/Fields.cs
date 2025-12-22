namespace Example.Fields
{
    public class CallFields
    {
        private int id;
        
        public int ID
        {
            set
            {
                if (value > 0)
                {
                    id = value;
                }
                else
                {
                    throw new ArgumentException("ID should be greater");
                }
            }
        }

        public void ShowDetails(){
            Console.WriteLine(id);
        }
    }
}