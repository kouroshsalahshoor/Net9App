
using System.Diagnostics;

var stopwatch = new Stopwatch();
stopwatch.Start();

// Execute multiple long-running tasks concurrently
Task task1 = LongRunningOperation("Task 1");
Task task2 = LongRunningOperation("Task 2");
Task task3 = LongRunningOperation("Task 3");
Task task4 = LongRunningOperation("Task 4");

// Wait for all tasks to complete
await Task.WhenAll(task1, task2, task3, task4);

stopwatch.Stop();

Console.WriteLine($"Elapsed time: {stopwatch.ElapsedMilliseconds} ms");

static async Task LongRunningOperation(string taskName)
{
    Console.WriteLine($"{taskName} started...");
    await Task.Delay(5000); // simulate a long-running operation
    Console.WriteLine($"{taskName} completed.");
}