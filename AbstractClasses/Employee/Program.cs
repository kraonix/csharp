using Employee.AbstractClass;

class Program
{
    static void Main(string[] args)
    {
        ///<summary>
        /// Demonstrates tax calculation for Indian and US employees
        ///</summary>
        

        IndianEmployee indianEmp = new IndianEmployee(1000000);
        Console.WriteLine("\nIndian Employee Income(Before Tax): " + indianEmp.income);
        Console.WriteLine("Indian Employee Income(After Tax): " + (indianEmp.income - indianEmp.CalcTax(indianEmp.income)));
        Console.WriteLine("Total Tax Paid: " + indianEmp.tax);

        USEmployee usEmp = new USEmployee(100000);
        Console.WriteLine("\nUS Employee Income(Before Tax): " + usEmp.income);
        Console.WriteLine("US Employee Income(After Tax): " + (usEmp.income - usEmp.CalcTax(usEmp.income)));
        Console.WriteLine("Total Tax Paid: " + usEmp.tax + "\n");

    }
}