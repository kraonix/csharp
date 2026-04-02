using System.Collections.Generic;
using System.Text.RegularExpressions;

public class Program
{
    public static bool Validator(string input)
    {
        List<string> temp = input.Split('|').ToList();
        bool IsOk = true;

        // ID validator
        string ID = temp[0];
        IsOk &= Regex.IsMatch(ID, @"^TXN\-[1-9][0-9]{5}");
        if (Regex.IsMatch(ID, @"(\d)\1{3}")) IsOk &= false;

        //Date Validator
        string Date = temp[1];
        IsOk &= Regex.IsMatch(Date, @"[0-9]{4}\-[0-9]{2}\-[0-9]{2}");
        List<string> DateList = Date.Split('-').ToList();
        int year = int.Parse(DateList[0]);
        int Month = int.Parse(DateList[1]);
        int Day = int.Parse(DateList[2]);
        if (year < 2000 || year > 2099) IsOk &= false;

        if (Month > 12) IsOk &= false;
        else
        {
            List<int> months = new List<int> { 31, (year % 4 == 0 ? 29 : 28), 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            if (Day > months[Month - 1]) IsOk &= false;
        }

        //Currency Validator
        string currency = temp[2];
        IsOk &= Regex.IsMatch(currency, @"(USD|EUR|INR|GBP|AUD|CAD)");

        //Amount Validator
        string amountString = temp[3];
        if (amountString[0] == '0' && amountString[1] != '.') IsOk &= false;
        double amount = double.Parse(temp[3]);
        if (amount < 0 || amount >= 999999.99) IsOk &= false;
        

        //Status Validator
        string status = temp[4];
        IsOk &= Regex.IsMatch(status, @"(SUCCESS|FAILED|PENDING)");

        return IsOk;
    }

    public static void Main()
    {
        int size = int.Parse(Console.ReadLine());
        string input = "";
        for (int i = 0; i < size; i++)
        {
            input = Console.ReadLine();
            if (Validator(input))
            {
                Console.WriteLine("Valid");
            }
            else
            {
                Console.WriteLine("Invalid");
            }
        }
    }
}
