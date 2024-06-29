namespace AsyncProgressInfoInConsoleApp;

internal static class KeyboardHandler
{
    internal static async Task CancelWhenEscapeKeyIsPressedAsync(
        CancellationTokenSource heavyServiceCancellationTokenSource,
        CancellationToken keyboardHandlerCancellationToken)
    {
        while (true)
        {
            if (IsCancelKeyPressed(heavyServiceCancellationTokenSource) ||
                keyboardHandlerCancellationToken.IsCancellationRequested)
            {
                break;
            }

            await Task.Delay(100, CancellationToken.None);
        }

        Console.WriteLine("* The keyboard handler has been stopped.");
    }

    private static bool IsCancelKeyPressed(CancellationTokenSource serviceCancellationTokenSource)
    {
        if (Console.KeyAvailable)
        {
            if (Console.ReadKey(true).Key == ConsoleKey.Escape)
            {
                Console.WriteLine("\n\n* The Esc-key has been pressed.");

                serviceCancellationTokenSource.Cancel();

                return true;
            }

        }

        return false;
    }
}
