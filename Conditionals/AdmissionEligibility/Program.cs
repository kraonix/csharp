class AdmissionEligibility
{
    public static void Main(string[] args)
    {

        // Input marks for three subjects
        Console.Write("Enter Marks in Maths: ");
        int maths = int.Parse(Console.ReadLine());

        Console.Write("Enter Marks in Physics: ");
        int physics = int.Parse(Console.ReadLine());

        Console.Write("Enter Marks in Chemistry: ");
        int chemistry = int.Parse(Console.ReadLine());

        // Check eligibility criteria
        bool pass = false;


        // Eligibility conditions
        if(maths >= 65 && physics >= 55 && chemistry >= 50)
        {
            if((maths + physics + chemistry) >= 180 || (maths + physics) >= 140)
            {
                pass = true;
            }
        }

        Console.WriteLine(pass ? "Eligible for Admission" : "Not Eligible for Admission");

    }
}