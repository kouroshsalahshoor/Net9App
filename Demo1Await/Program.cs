
Console.WriteLine($"Starting Main method, Thread Id: {System.Threading.Thread.CurrentThread.ManagedThreadId}");

//await LongRunningTaskAsync();
//Console.WriteLine($"Continued execution after LongRunningTaskAsync, Thread Id: {System.Threading.Thread.CurrentThread.ManagedThreadId}");

var task = LongRunningTaskAsync();
Console.WriteLine($"Continued execution after LongRunningTaskAsync, Thread Id: {System.Threading.Thread.CurrentThread.ManagedThreadId}");
await task;

Console.WriteLine($"Ending Main method, Thread Id: {System.Threading.Thread.CurrentThread.ManagedThreadId}");
Console.Read();

async Task LongRunningTaskAsync()
{
    Console.WriteLine($"Starting LongRunningTaskAsync method, Thread Id: {System.Threading.Thread.CurrentThread.ManagedThreadId}");

    await Task.Delay(5000);

    Console.WriteLine($"Ending LongRunningTaskAsync method, Thread Id: {System.Threading.Thread.CurrentThread.ManagedThreadId}");
}