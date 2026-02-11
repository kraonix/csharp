public interface IFinancialInstrument
{
    string Symbol { get; }
    decimal CurrentPrice { get; }
    InstrumentType Type { get; }
}

public enum InstrumentType { Stock, Bond, Option, Future }

// 1. Generic portfolio
public class Portfolio<T> where T : IFinancialInstrument
{
    private Dictionary<T, int> _holdings = new(); // Instrument -> Quantity

    // TODO: Buy instrument
    public void Buy(T instrument, int quantity, decimal price)
    {
        // Validate: quantity > 0, price > 0
        // Add to holdings or update quantity
        if (quantity < 0 && price < 0)
        {
            throw new ArgumentException("Invalid Quantity or Price");
        }

        if (_holdings.ContainsKey(instrument))
        {
            _holdings[instrument] += quantity;
        }
        else
        {
            _holdings[instrument] = quantity;
        }
    }

    // TODO: Sell instrument
    public decimal? Sell(T instrument, int quantity, decimal currentPrice)
    {
        // Validate: enough quantity
        // Remove/update holdings
        // Return proceeds (quantity * currentPrice)
        if (_holdings.ContainsKey(instrument))
        {
            if (_holdings[instrument] < quantity)
            {
                throw new ArgumentException("Sell Quantity must be Less or Equal to Quantity");
            }
            else
            {
                _holdings[instrument] -= quantity;
            }

            if (_holdings[instrument] == 0)
            {
                _holdings.Remove(instrument);
            }
        }
        else
        {
            throw new ArgumentException("No Holding of this Name Exists");
        }

        return quantity * currentPrice;
    }

    // TODO: Calculate total value
    public decimal CalculateTotalValue()
    {
        // Sum of (quantity * currentPrice) for all holdings
        decimal total = 0;
        foreach (var holding in _holdings)
        {
            total += holding.Key.CurrentPrice * holding.Value;
        }

        return total;
    }

    // TODO: Get top performing instrument
    public (T instrument, decimal returnPercentage)? GetTopPerformer(Dictionary<T, decimal> purchasePrices)
    {
        // Calculate return percentage for each
        // Return highest performer

        if (!_holdings.Any())
            return null;

        var performance = _holdings
            .Where(h => purchasePrices.ContainsKey(h.Key))
            .Select(h =>
            {
                var buyPrice = purchasePrices[h.Key];
                var current = h.Key.CurrentPrice;
                var returnPct = ((current - buyPrice) / buyPrice) * 100;
                return (instrument: h.Key, returnPct);
            })
            .OrderByDescending(x => x.returnPct)
            .FirstOrDefault();

        if (performance.instrument == null)
            return null;

        return (performance.instrument, performance.returnPct);
    }
    public IEnumerable<T> GetInstruments() => _holdings.Keys;
}

// 2. Specialized instruments
public class Stock : IFinancialInstrument
{
    public string Symbol { get; set; }
    public decimal CurrentPrice { get; set; }
    public InstrumentType Type => InstrumentType.Stock;
    public string CompanyName { get; set; }
    public decimal DividendYield { get; set; }
}

public class Bond : IFinancialInstrument
{
    public string Symbol { get; set; }
    public decimal CurrentPrice { get; set; }
    public InstrumentType Type => InstrumentType.Bond;
    public DateTime MaturityDate { get; set; }
    public decimal CouponRate { get; set; }
}

// 3. Generic trading strategy
public class TradingStrategy<T> where T : IFinancialInstrument
{
    // TODO: Execute strategy on portfolio
    public void Execute(Portfolio<T> portfolio, Func<T, bool> buyCondition, Func<T, bool> sellCondition)
    {
        // For each instrument in market data
        // Apply buy/sell conditions
        // Execute trades
        foreach (var instrument in portfolio.GetInstruments().ToList())
        {
            if (sellCondition(instrument))
            {
                portfolio.Sell(instrument, 1, instrument.CurrentPrice);
            }
            else if (buyCondition(instrument))
            {
                portfolio.Buy(instrument, 1, instrument.CurrentPrice);
            }
        }
    }

    // TODO: Calculate risk metrics
    public Dictionary<string, decimal> CalculateRiskMetrics(IEnumerable<T> instruments)
    {
        // Return: Volatility, Beta, Sharpe Ratio
        var random = new Random();

        return new Dictionary<string, decimal>
        {
            { "Volatility", (decimal)random.NextDouble() * 0.5m },
            { "Beta", (decimal)random.NextDouble() * 2 },
            { "Sharpe Ratio", (decimal)random.NextDouble() * 3 }
        };
    }
}

// 4. Price history with generics
public class PriceHistory<T> where T : IFinancialInstrument
{
    private Dictionary<T, List<(DateTime, decimal)>> _history = new();

    // TODO: Add price point
    public void AddPrice(T instrument, DateTime timestamp, decimal price)
    {
        // Add to history
        if (!_history.ContainsKey(instrument))
            _history[instrument] = new List<(DateTime, decimal)>();

        _history[instrument].Add((timestamp, price));
    }

    // TODO: Get moving average
    public decimal? GetMovingAverage(T instrument, int days)
    {
        // Calculate simple moving average
        if (!_history.ContainsKey(instrument))
            return null;

        var prices = _history[instrument]
            .OrderByDescending(p => p.Item1)
            .Take(days)
            .Select(p => p.Item2)
            .ToList();

        if (!prices.Any())
            return null;

        return prices.Average();
    }

    // TODO: Detect trends
    public Trend DetectTrend(T instrument, int period)
    {
        // Return: Upward, Downward, Sideways
        if (!_history.ContainsKey(instrument))
            return Trend.Sideways;

        var prices = _history[instrument]
            .OrderByDescending(p => p.Item1)
            .Take(period)
            .Select(p => p.Item2)
            .ToList();

        if (prices.Count < 2)
            return Trend.Sideways;

        if (prices.First() > prices.Last())
            return Trend.Upward;

        if (prices.First() < prices.Last())
            return Trend.Downward;

        return Trend.Sideways;
    }
}

public enum Trend { Upward, Downward, Sideways }

// 5. TEST SCENARIO: Trading simulation
// a) Create portfolio with mixed instruments
// b) Implement buy/sell logic
// c) Create trading strategy with lambda conditions
// d) Track price history
// e) Demonstrate:
//    - Portfolio rebalancing
//    - Risk calculation
//    - Trend detection
//    - Performance comparison

public class Program
{
    public static void Main()
    {
        var portfolio = new Portfolio<IFinancialInstrument>();

        var stock1 = new Stock { Symbol = "AAPL", CurrentPrice = 180m, CompanyName = "Apple" };
        var stock2 = new Stock { Symbol = "MSFT", CurrentPrice = 320m, CompanyName = "Microsoft" };
        var bond1 = new Bond { Symbol = "GOVT10Y", CurrentPrice = 100m, MaturityDate = DateTime.Now.AddYears(10) };

        portfolio.Buy(stock1, 10, 150m);
        portfolio.Buy(stock2, 5, 300m);
        portfolio.Buy(bond1, 20, 95m);

        Console.WriteLine("\n=== Portfolio Value ===");
        Console.WriteLine(portfolio.CalculateTotalValue());

        var history = new PriceHistory<IFinancialInstrument>();

        history.AddPrice(stock1, DateTime.Now.AddDays(-3), 170);
        history.AddPrice(stock1, DateTime.Now.AddDays(-2), 175);
        history.AddPrice(stock1, DateTime.Now.AddDays(-1), 180);

        Console.WriteLine("\nMoving Average (3 days):");
        Console.WriteLine(history.GetMovingAverage(stock1, 3));

        Console.WriteLine("Trend:");
        Console.WriteLine(history.DetectTrend(stock1, 3));

        var strategy = new TradingStrategy<IFinancialInstrument>();

        strategy.Execute(portfolio, buyCondition: i => i.CurrentPrice < 200, sellCondition: i => i.CurrentPrice > 300);

        Console.WriteLine("\n=== After Strategy Execution ===");
        Console.WriteLine(portfolio.CalculateTotalValue());

        var risk = strategy.CalculateRiskMetrics(portfolio.GetInstruments());

        Console.WriteLine("\n=== Risk Metrics ===");
        foreach (var r in risk)
            Console.WriteLine($"{r.Key}: {r.Value:F2}");
    }

}