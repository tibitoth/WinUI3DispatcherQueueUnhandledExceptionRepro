using System;
using System.Diagnostics;

namespace WinUI3DispatcherQueueUnhandledExceptionRepro;

public class ErrorHandler : IErrorHandler
{
    public void HandleException(Exception ex)
    {
        Debug.WriteLine($"Unhandled exception in App {ex}");
    }
}