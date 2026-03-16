using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;

namespace LoginScreenEMX.Views;

public partial class CustomDialog : Window
{
    public bool DialogResult { get; private set; }
    
    public CustomDialog()
    {
        InitializeComponent();
    }

    private void OkButton_Click(object? sender, RoutedEventArgs e)
    {
        DialogResult = true;
        Close();
    }

    private void CancelButton_Click(object? sender, RoutedEventArgs e)
    {
        DialogResult = false;
        Close();
    }
    
    private void TitleBar_PointerPressed(object? sender, PointerPressedEventArgs e)
    {
        if (VisualRoot is MainWindow mainWindow)
        {
            mainWindow.BeginWindowDrag(e);
        }
    }
    
}