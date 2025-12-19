class GradeDesprition
{
    /// <summary>
    /// Program for describing grades.
    /// </summary>
    /// <param name="args"></param>
    public static void main(string[] args)
    {
        // Input the grade
        Console.Write("Enter the grade (E, V, G, A, F): ");
        char grade = Char.ToUpper(Console.ReadLine()[0]);

        // Determine and print the description using switch-case
        switch (grade)
        {
            case 'E':
                Console.WriteLine("Excellent");
                break;
            case 'V':
                Console.WriteLine("Very Good");
                break;
            case 'G':
                Console.WriteLine("Good");
                break;
            case 'A':
                Console.WriteLine("Average");
                break;
            case 'F':
                Console.WriteLine("Fail");
                break;
            default:
                Console.WriteLine("Invalid grade entered.");
                break;
        }
    }
}