class Program
{
    static void Main()
    {
        var jsonBatch = new List<string>
        {
            "{\"Name\":\"Sachin\",\"Email\":\"sachin@email.com\",\"Age\":25,\"PAN\":\"ABCDE1234F\"}",
            "{\"Name\":\"\",\"Email\":\"wrong-email\",\"Age\":17,\"PAN\":\"1234\"}",
            "INVALID JSON HERE"
        };

        var validator = new BatchValidator();
        var report = validator.ValidateBatch(jsonBatch);

        Console.WriteLine($"Total: {report.TotalRecords}");
        Console.WriteLine($"Valid: {report.ValidRecords}");
        Console.WriteLine($"Invalid: {report.InvalidRecords}");

        foreach (var record in report.Details)
        {
            Console.WriteLine($"\nRecord Index: {record.Index}");
            if (!record.IsValid)
            {
                foreach (var error in record.Errors)
                    Console.WriteLine($" - {error}");
            }
            else
            {
                Console.WriteLine(" Valid");
            }
        }
    }
}
