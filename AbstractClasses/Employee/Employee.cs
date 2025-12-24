using System.Runtime.InteropServices;

namespace Employee.AbstractClass
{
    /// <summary>
    /// Abstract class representing an Employee
    /// </summary>
    public abstract class Employee
    {
        public abstract double CalcTax(double income);
    }

    public class IndianEmployee : Employee
    {
        /// <summary>
        /// Income of the employee in India
        /// </summary>
        public double income;
        public double tax;

        public IndianEmployee(double income)
        {
            this.income = income;
        }

        public override double CalcTax(double income)
        {
            if(income <= 250000)
                tax = 0;                               // No tax for income up to 2.5 lakhs
            else if(income <= 500000)
                tax = income * 0.05;                   // 5% tax for income between 2.5 lakhs and 5 lakhs
            else if(income <= 1000000)
                tax = income * 0.20;                   // 20% tax for income between 5 lakhs and 10 lakhs
            else
                tax = income * 0.30;                   // 30% tax for income above 10 lakhs

            return tax;
        }

    }

    public class USEmployee : Employee
    {
        /// <summary>
        /// Income of the employee in US  
        /// </summary>
        public double income;
        public double tax;
        public USEmployee(double income)
        {
            this.income = income;
        }

        public override double CalcTax(double income)
        {
            if(income <= 10000)
                tax = income * 0.10;                   // 10% tax for income up to $10,000
            else if(income <= 40000)
                tax = income * 0.12;                   // 12% tax for income between $9,876 and $40,125
            else if(income <= 80000)
                tax = income * 0.22;                   // 22% tax for income between $40,000 and $80,000
            else
                tax = income * 0.24;                   // 24% tax for income above $80,000

            return tax;
        }
    }
}