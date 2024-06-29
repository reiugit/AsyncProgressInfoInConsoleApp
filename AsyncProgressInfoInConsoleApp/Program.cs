using AsyncProgressInfoInConsoleApp;

Console.WriteLine("\nOn some operating systems, the console window does not successfully get");
Console.WriteLine("the keyboard focus, when starting the application from Visual Studio.");
Console.WriteLine("In this case just click inside the console window.\n");
Console.WriteLine("\nPress 'Esc' to cancel the task.\n");

var heavyServiceCts = new CancellationTokenSource();
var keyboardHandlerCts = new CancellationTokenSource();

var heavyServiceCancellationToken = heavyServiceCts.Token;
var keyboardHandlerCancellationToken = keyboardHandlerCts.Token;

// start the keyboard handler
var keyBoardHandler = KeyboardHandler.CancelWhenEscapeKeyIsPressedAsync(heavyServiceCts, keyboardHandlerCancellationToken);

// start the heavy task
await SomeHeavyService.DoSomeHeavyTaskAsync(heavyServiceCancellationToken);

// stop the keyboard handler
keyboardHandlerCts.Cancel();
await keyBoardHandler;

Console.WriteLine("\n\nPress any key to exit.");
Console.ReadKey(true);

