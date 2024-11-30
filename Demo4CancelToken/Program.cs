
// Create a cancelation token source
using (var cts = new CancellationTokenSource())
{
    // Start the long-running operation
    //var task = LongRunningOperationAsync(cts.Token);

    // Wait for user input to cancel the operation
    Console.WriteLine("Press any key to cancel the operation...");
    Console.ReadKey();

    // Cancel the operation
    cts.Cancel();

    try
    {
        await LongRunningOperationAsync(cts.Token);

        // Wait for the operation to complete
        //await task;
    }
    catch (OperationCanceledException ex)
    {
        // Handle cancellation
        Console.WriteLine("Operation was canceled.");
    }
    catch (Exception ex)
    {
        // Handle other exceptions
        Console.WriteLine("An error occurred: " + ex.Message);
    }
}

static async Task<string> LongRunningOperationAsync(CancellationToken cancellationToken)
{
    try
    {
        // Check if cancellation was requested before starting the operation
        cancellationToken.ThrowIfCancellationRequested();

        // Perform the long-running operation
        string result = await DoSomeWorkAsync();

        // Check if cancellation was requested during the operation
        cancellationToken.ThrowIfCancellationRequested();

        return result;
    }
    catch (OperationCanceledException ex)
    {
        // Handle cancellation
        Console.WriteLine("Operation was canceled.");
        throw;
    }
    catch (Exception ex)
    {
        // Handle other exceptions
        Console.WriteLine("An error occurred: " + ex.Message);
        throw;
    }
}

static async Task<string> DoSomeWorkAsync()
{
    // Simulate a long-running operation
    await Task.Delay(TimeSpan.FromSeconds(10));
    return "Operation completed successfully.";
}