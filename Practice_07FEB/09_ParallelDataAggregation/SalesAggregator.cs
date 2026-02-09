using System;
using System.Collections.Generic;
using System.Linq;

public class SalesAggregator
{
    public void Analyze(List<Sale> sales)
    {
        var parallelSales = sales.AsParallel();

        // 1️⃣ Total sales by Region
        var totalByRegion = parallelSales
            .GroupBy(s => s.Region)
            .Select(g => new
            {
                Region = g.Key,
                Total = g.Sum(x => x.Amount)
            })
            .OrderBy(x => x.Region)   // deterministic order
            .ToList();

        // 2️⃣ Top category per Region
        var topCategoryByRegion = parallelSales
            .GroupBy(s => s.Region)
            .Select(regionGroup => new
            {
                Region = regionGroup.Key,
                TopCategory = regionGroup
                    .GroupBy(s => s.Category)
                    .Select(cg => new
                    {
                        Category = cg.Key,
                        Total = cg.Sum(x => x.Amount)
                    })
                    .OrderByDescending(x => x.Total)
                    .ThenBy(x => x.Category)  // deterministic tie breaker
                    .First().Category
            })
            .OrderBy(x => x.Region)
            .ToList();

        // 3️⃣ Best sales day overall
        var bestDay = parallelSales
            .GroupBy(s => s.Date.Date)
            .Select(g => new
            {
                Date = g.Key,
                Total = g.Sum(x => x.Amount)
            })
            .OrderByDescending(x => x.Total)
            .ThenBy(x => x.Date)
            .First();

        // Print Results
        Console.WriteLine("Total Sales by Region:");
        foreach (var r in totalByRegion)
            Console.WriteLine($"{r.Region} → {r.Total}");

        Console.WriteLine("\nTop Category by Region:");
        foreach (var r in topCategoryByRegion)
            Console.WriteLine($"{r.Region} → {r.TopCategory}");

        Console.WriteLine($"\nBest Sales Day Overall: {bestDay.Date:yyyy-MM-dd} → {bestDay.Total}");
    }
}
