namespace MarksList.Models;

public class MarksDashboardViewModel
{
    public double AvgMarks1 { get; set; }
    public double AvgMarks2 { get; set; }

    public List<Marks> AllMarks { get; set; } = new();
}