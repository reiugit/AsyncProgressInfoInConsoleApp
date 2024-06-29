using AsyncProgressInfoInConsoleApp;

Console.WriteLine("\nOn some operating systems, the console window does not successfully get");
Console.WriteLine("the keyboard focus, when starting the application from Visual Studio.");
Console.WriteLine("In this case just click inside the console window.\n");
Console.WriteLine("\nPress 'Esc' to cancel the task.\n");

var heavyServiceCancellationTokenSource = new CancellationTokenSource();
var keyboardHandlerCancellationTokenSource = new CancellationTokenSource();

var heavyServiceCancellationToken = heavyServiceCancellationTokenSource.Token;
var keyboardHandlerCancellationToken = keyboardHandlerCancellationTokenSource.Token;

// start the keyboard handler
Task keyBoardHandlerTask = KeyboardHandler.CancelWhenEscapeKeyIsPressedAsync(heavyServiceCancellationTokenSource,
                                                                        keyboardHandlerCancellationToken);

// start the heavy task
await SomeHeavyService.DoSomeHeavyTaskAsync(heavyServiceCancellationToken);

// stop the keyboard handler
keyboardHandlerCancellationTokenSource.Cancel();
await keyBoardHandlerTask;

Console.WriteLine("\n\nPress any key to exit.");
Console.ReadKey(true);

