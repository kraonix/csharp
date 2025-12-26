using UserDetails;
class MainSystem
{
    public static void Main()
    {
        StudentDetails[] students =
        [
            new StudentDetails(12413747, 3, "Sachin", 1),
            new StudentDetails(12409000, 3, "Sahil", 3),
            new StudentDetails(12325350, 3, "Ayushi", 2),
            new StudentDetails(12342554, 3, "Anuska", 3),
            new StudentDetails(12234344, 3, "Viakas", 1),
            new StudentDetails(13254545, 3, "Rammu", 1),
            new StudentDetails(12324554, 3, "Shammu", 2)
        ];

        ExaminerDetails[] examiners =
        [
            new ExaminerDetails(1222, 2, "Examiner 1", 11),
            new ExaminerDetails(1223, 2, "Examiner 2", 12),
            new ExaminerDetails(1224, 2, "Examiner 3", 13)
        ];

        HODDetails hod = new(1001, 1, "Adarsh", 2);



        hod.HodFunction(hod, students, examiners);
    }
}