
// Connection string to your SQL Server database
using Hangfire;

string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=Hangfire;Integrated Security=SSPI;TrustServerCertificate=true;";

// Configure Hangfire to use SQL Server storage
GlobalConfiguration.Configuration.UseSqlServerStorage(connectionString);

// Enqueue the background job
var myJob = new MyBackgroundJob();
BackgroundJob.Enqueue(() => myJob.PrintMessage());

RecurringJob.AddOrUpdate("myrecurringjob", () => Console.WriteLine("Recurring task is running..."),
            Cron.Minutely);

BackgroundJob.Schedule(() => Console.WriteLine("Delayed job is running..."), TimeSpan.FromMinutes(10));

// Run Hangfire server in the background
using (var server = new BackgroundJobServer())
{
    Console.WriteLine("Hangfire server started. Press any key to exit...");
    Console.ReadKey();
}

public class MyBackgroundJob
{
    public void PrintMessage()
    {
        Console.WriteLine("This is a background job running in Hangfire!");
    }
}