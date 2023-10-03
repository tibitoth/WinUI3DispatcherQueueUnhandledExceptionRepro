using Microsoft.UI.Xaml;

using System.Diagnostics;

namespace WinUI3DispatcherQueueUnhandledExceptionRepro;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        UnhandledException += App_UnhandledException;
    }

    private void App_UnhandledException(object sender, Microsoft.UI.Xaml.UnhandledExceptionEventArgs e)
    {
        e.Handled = true;
        Debug.WriteLine($"Unhandled exception in App {e.Exception}");
        Debugger.Break();
    }

    protected override void OnLaunched(LaunchActivatedEventArgs args)
    {
        m_window = new MainWindow();
        m_window.Activate();
    }

    private Window m_window;
}
