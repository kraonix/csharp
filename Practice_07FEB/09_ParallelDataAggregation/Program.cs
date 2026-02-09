class Program
{
    static void Main()
    {
        var sales = new List<Sale>
        {
            new Sale { Region="North", Category="Electronics", Amount=1000, Date=DateTime.Parse("2026-02-01") },
            new Sale { Region="North", Category="Clothing", Amount=500, Date=DateTime.Parse("2026-02-01") },
            new Sale { Region="South", Category="Electronics", Amount=800, Date=DateTime.Parse("2026-02-02") },
            new Sale { Region="South", Category="Clothing", Amount=1200, Date=DateTime.Parse("2026-02-02") },
            new Sale { Region="North", Category="Electronics", Amount=700, Date=DateTime.Parse("2026-02-03") },
        };

        var aggregator = new SalesAggregator();
        aggregator.Analyze(sales);
    }
}
