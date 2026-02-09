using System;
using System.Threading;

class Program
{
    static void Main()
    {
        TicketService service = new TicketService(1);

        Thread t1 = new Thread(() =>
        {
            Console.WriteLine("User1 booking: " +
                service.BookSeat(1, "User1"));
        });

        Thread t2 = new Thread(() =>
        {
            Console.WriteLine("User2 booking: " +
                service.BookSeat(1, "User2"));
        });

        t1.Start();
        t2.Start();

        t1.Join();
        t2.Join();
    }
}
