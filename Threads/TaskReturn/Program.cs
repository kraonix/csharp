// 2) Task<T> return
// Write Task<int> GetNumberAsync() that waits 300ms then returns 99. Print the result.

Console.Write(await GetNumberAsync());

async Task<int> GetNumberAsync()
{
    await Task.Delay(3000);
    return 99;
}