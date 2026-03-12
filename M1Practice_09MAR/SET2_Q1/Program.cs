using System;
using System.Text.RegularExpressions;
public class Program
{
    public static bool validateTransaction(string record)
    {
        if (string.IsNullOrEmpty(record))
            return false;

        string[] parts = record.Split('|');
        if (parts.Length != 5)
            return false;

        //ID Check
        string txn = parts[0];
        if (!Regex.IsMatch(txn, @"^TXN-\d{6}$"))
            return false;

        string digits = txn.Substring(4);
        if (digits[0] == '0')
            return false;

        if (Regex.IsMatch(digits, @"(\d)\1\1\1"))
            return false;

        string date = parts[1];
        if (!Regex.IsMatch(date, @"^\d{4}-\d{2}-\d{2}$"))
            return false;

        // Date Check
        string[] dateParts = date.Split('-');
        int year = int.Parse(dateParts[0]);
        int month = int.Parse(dateParts[1]);
        int day = int.Parse(dateParts[2]);

        if (year < 2000 || year > 2099)
            return false;

        if (month < 1 || month > 12)
            return false;

        int[] daysInMonth = { 31, (year % 4 == 0) ? 29 : 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        if (day < 1 || day > daysInMonth[month - 1])
            return false;


        //Currency Check
        string currency = parts[2];
        if (!(currency == "USD" || currency == "EUR" || currency == "INR" ||
              currency == "GBP" || currency == "AUD" || currency == "CAD"))
            return false;

        string amount = parts[3];
        if (!Regex.IsMatch(amount, @"^(0|[1-9]\d*)(\.\d{1,2})?$"))
            return false;

        if (!decimal.TryParse(amount, out decimal amt))
            return false;

        if (amt < 0 || amt > 999999.99m)
            return false;

        //Status Check    
        string status = parts[4];
        if (!(status == "SUCCESS" || status == "FAILED" || status == "PENDING"))
            return false;

        //All Good    
        return true;
    }
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            string input = Console.ReadLine();
            if (validateTransaction(input))
            {
                Console.WriteLine("VALID LOG");
            }
            else
            {
                Console.WriteLine("INVALID LOG");
            }
        }
    }
}