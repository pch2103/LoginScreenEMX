using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Eremex.AvaloniaUI.Controls.Editors;


namespace LoginScreenEMX.Views;

public partial class ProxySettingsView : UserControl
{
    public ProxySettingsView()
    {
        InitializeComponent();
        
    }
    
    private void WarningConnection_Click(object? sender, RoutedEventArgs e)
    {
        if (VisualRoot is MainWindow mainWindow)
        {
            InfoContentControl.Content = new WarningBlockView
            {
                HeaderText = "Warning Connection:",
                BodyText = "Message providing information to the user with actionable insights."
            };
        }
    }

    private void BackButton_Click(object? sender, RoutedEventArgs e)
    {
        if (VisualRoot is MainWindow mainWindow)
        {
            mainWindow.ShowMainContent();
        }
    }
    private void CloseButton_Click(object? sender, RoutedEventArgs e)
    {
        if (VisualRoot is MainWindow mainWindow)
        {
            mainWindow.CloseWindow();
        }
    }
    
    private void TitleBar_PointerPressed(object? sender, PointerPressedEventArgs e)
    {
        if (VisualRoot is MainWindow mainWindow)
        {
            mainWindow.BeginWindowDrag(e);
        }
    }
}