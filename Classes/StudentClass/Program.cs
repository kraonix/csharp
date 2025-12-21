class StudentClass
{
    /// <summary>
    /// Class representing a student with name and age.
    /// </summary>
    public string Name;
    public int Age;

    #region
    // Constructor
    public StudentClass(string name, int age)
    {
        Name = name;
        Age = age;
    }
    #endregion

    #region 
    /// Method to display student information
    public void DisplayInfo()
    {
        Console.WriteLine();
        Console.WriteLine("Student Information:");
        Console.WriteLine($"Name: {Name}, Age: {Age}");
        Console.WriteLine();
    }
    #endregion
}

class Program
{
    /// <summary>
    /// Program to demonstrate the StudentClass.
    /// </summary>
    public static void Main()
    {
        // Get student details from user
        Console.Write("Enter student name: ");
        string studentName = Console.ReadLine();
        Console.Write("Enter student age: ");
        int studentAge = int.Parse(Console.ReadLine());

        // Create an instance of StudentClass
        StudentClass student = new StudentClass(studentName, studentAge);

        // Display student information
        student.DisplayInfo();
    }
}