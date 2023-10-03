using Microsoft.UI.Xaml;

using System;
using System.Threading.Tasks;

namespace WinUI3DispatcherQueueUnhandledExceptionRepro;

public sealed partial class MainWindow : Window
{
    DispatcherQueueWrapper _dispatcherQueueWrapper;

    public MainWindow()
    {
        InitializeComponent();

        _dispatcherQueueWrapper = new DispatcherQueueWrapper(DispatcherQueue, new ErrorHandler());
    }

    private async void Throw_Click(object sender, RoutedEventArgs e)
    {
        await Task.Run(() =>
        {
            DispatcherQueue.TryEnqueue(() =>
            {
                textBlock.Text = "Accessed from another thread";
                throw new Exception("Unhandled exception from MainWindow's DispatcherQueue");
            });
        });
    }

    private async void DontThrow_Click(object sender, RoutedEventArgs e)
    {
        await Task.Run(() =>
        {
            _dispatcherQueueWrapper.TryEnqueue(() =>
            {
                textBlock.Text = "Accessed from another thread";
                throw new Exception("Handled exception from MainWindow's DispatcherQueue");
            });
        });
    }
}
