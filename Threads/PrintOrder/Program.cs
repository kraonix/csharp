// 1) Print order
// Create an async method that prints Start, awaits Task.Delay(500), then prints End. Call it from Main.

await Print();

async Task Print()
{
    Console.WriteLine("Start");
    await Task.Delay(5000);
    Console.WriteLine("End");
}