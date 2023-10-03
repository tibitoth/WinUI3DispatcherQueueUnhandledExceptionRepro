using Microsoft.UI.Dispatching;

using System;

namespace WinUI3DispatcherQueueUnhandledExceptionRepro;

public class DispatcherQueueWrapper
{
    private readonly DispatcherQueue _dispatcher;
    private readonly IErrorHandler _errorHandler;

    public DispatcherQueueWrapper(DispatcherQueue dispatcher, IErrorHandler errorHandler)
    {
        _dispatcher = dispatcher;
        _errorHandler = errorHandler;
    }

    public bool TryEnqueue(Action action)
    {
        return _dispatcher.TryEnqueue(() =>
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                _errorHandler.HandleException(ex);
            }
        });
    }
}
