using System;

namespace WinUI3DispatcherQueueUnhandledExceptionRepro;

public interface IErrorHandler
{
    public void HandleException(Exception ex);
}
