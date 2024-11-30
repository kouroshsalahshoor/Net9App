
Task task = Task.Run(() => {
    // This code will run asynchronously
    Console.WriteLine("This code will run asynchronously");
});
await task;

Console.WriteLine();
Console.WriteLine();
Console.WriteLine();

Task[] tasks = new Task[10];
for (int i = 0; i < tasks.Length; i++)
{
    tasks[i] = Task.Run(() =>
    {
        // This code will run asynchronously
        Console.WriteLine("This code will run asynchronously " + i.ToString());
    });
}
Task.WhenAll(tasks).Wait();