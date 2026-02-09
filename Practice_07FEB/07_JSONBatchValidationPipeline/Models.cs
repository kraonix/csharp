public class CustomerApplication
{
    public string Name { get; set; }
    public string Email { get; set; }
    public int Age { get; set; }
    public string PAN { get; set; }
}

public class RecordValidationResult
{
    public int Index { get; set; }
    public bool IsValid => Errors.Count == 0;
    public List<string> Errors { get; set; } = new();
}

public class ValidationReport
{
    public int TotalRecords { get; set; }
    public int ValidRecords { get; set; }
    public int InvalidRecords { get; set; }
    public List<RecordValidationResult> Details { get; set; } = new();
}
