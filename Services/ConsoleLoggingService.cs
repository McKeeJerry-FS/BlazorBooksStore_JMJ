using System;
using BlazorBooksStore.Services.Interfaces;

namespace BlazorBooksStore.Services;

public class ConsoleLoggingService : ILoggingService
{
    public void Log(string message)
    {
        Console.WriteLine(message);
    }
}
