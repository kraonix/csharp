// 3) Chain async methods
// Make AAsync() await BAsync(), and BAsync() await a delay. Print messages so you can see the chain.

await AAsync();

async Task AAsync()
{
    await BAsync();
    Console.WriteLine("A");
}

async Task BAsync()
{
    Console.WriteLine("B");
    await Task.Delay(3000);
}