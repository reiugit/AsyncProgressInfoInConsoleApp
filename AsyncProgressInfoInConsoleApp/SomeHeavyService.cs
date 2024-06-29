namespace AsyncProgressInfoInConsoleApp;

internal class SomeHeavyService
{
    public static async Task DoSomeHeavyTaskAsync(CancellationToken cancellationToken)
    {
        try
        {
            for (var i = 1; i <= 50; i++)
            {
                await Task.Delay(200, cancellationToken);

                var progressBar = new string('=', i);

                var Info = $"\r[{progressBar,-50}]    {i * 2,3} %    {i}/{50}";

                Console.Write(Info);
            }
            Console.WriteLine("\n\n* The service task has finished successfully!");
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("* The service task has been cancelled.");
        }

    }
}


