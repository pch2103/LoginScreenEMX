using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Platform;
using Eremex.AvaloniaUI.Controls.Common;

namespace LoginScreenEMX.Views;

public partial class MainWindow : MxWindow
{
    public MainWindow()
    {
        InitializeComponent();
    }
    
    public void ShowMainContent()
    {
        MainContentControl.Content = new ConnectToServerView();
    }

    public void ShowProxySettings()
    {
        MainContentControl.Content = new ProxySettingsView();
    }

    public void CloseWindow()
    {
        Close();
    }

    public void BeginWindowDrag(PointerPressedEventArgs e)
    {
        if (e.GetCurrentPoint(this).Properties.IsLeftButtonPressed)
        {
            BeginMoveDrag(e);
        }
    }
}