public class EstimateDetails
{
    public float? ConstructionArea { get; set; }
    public float? SiteArea { get; set; }
}

public class ConstructionEstimateException : Exception
{
    public ConstructionEstimateException(string msg) : base(msg) { }
}

public class Program
{
    public static EstimateDetails ValidateConstructionEstimates(float constructionArea, float siteArea)
    {
        EstimateDetails e = new EstimateDetails()
        {
            ConstructionArea = constructionArea,
            SiteArea = siteArea
        };

        if (e.ConstructionArea > e.SiteArea)
        {
            throw new ConstructionEstimateException("Construction Area Can't be Larger than Site Area");
        }

        return e;
    }

    public static void Main(string[] args)
    {
        try
        {
            Console.Write($"\nEnter Construction Area: ");
            float constructionArea = float.Parse(Console.ReadLine());

            Console.Write($"Enter Site Area: ");
            float siteArea = float.Parse(Console.ReadLine());

            EstimateDetails e = ValidateConstructionEstimates(constructionArea, siteArea);

            Console.WriteLine("Construction Plan Passed!");
        }
        catch (ConstructionEstimateException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}