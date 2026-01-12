enum CommodityCategory
{
    Furniture, Grocery, Service
}

class Commodity
{
    public CommodityCategory Category;
    public string CommodityName;
    public int CommodityQuatity;
    public double CommodityPrice;
    public Commodity(CommodityCategory category, string commodityName, int commodityQuantity, double commodityPrice)
    {
        this.Cotegory = category;
        this.CommodityName = commodityName;
        this.CommodityQuantity = commodityQuantity;
        this.CommodityPrice = commodityPrice;
    }
}

class PrepareBill
{
    private readonly IDictionary<CommodityCategory, double> _taxRates;

    public PrepareBill(){}

    public void SetTaxRates(CommodityCategory category, double taxRate)
    {
        IDictionary[category] = taxRate;
    }

    public double CalculateBillAmount(IList<Commodity> items)
    {
        double total = 0;
        foreach (var i in items)
        {
            total += i.CommodityPrice;
        }

        return total;
    }
}

class Program
{
    public static void Main(string[] args)
    {
        var Commodities = new List<Commodity>()
        {
            new Commodity(CommodityCategory.Furniture, "Bed", 2, 50000),
            new Commodity(CommodityCategory.Grocery, "Flour", 5, 80),
            new Commodity(CommodityCategory.Service, "Insurance", 8, 8500)
        };

        var prepareBill = new PrepareBill();

        prepareBill.SetTaxRates(CommodityCategory.Furniture, 18);
        prepareBill.SetTaxRates(CommodityCategory.Grocery, 5);
        prepareBill.SetTaxRates(CommodityCategory.Service, 12);

        var billAmount = prepareBill.CalculateBillAmount (commodities);
        Console.WriteLine($"{billAmount}");
    }
}