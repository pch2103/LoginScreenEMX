using System.Collections.ObjectModel;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Eremex.AvaloniaUI.Controls.Editors;
using Eremex.AvaloniaUI.Controls.Utils;

namespace LoginScreenEMX.Views;

public partial class ActivationUtilityView : UserControl
{
    public ActivationUtilityView()
    {
        InitializeComponent();
        DataContext = this;
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
    
    public class LicenseInfo
    {
        public string Server { get; set; }
        public string License { get; set; }
    }

// Внутри ViewModel
    public ObservableCollection<LicenseInfo> LicenseItems { get; } = new()
    {
        new LicenseInfo { Server = "DESKTOP-35KV6PT", License = "Active demo mode license file" },
        new LicenseInfo { Server = "SERVER-MAIN", License = "Enterprise Edition" },
        new LicenseInfo { Server = "BACKUP-SRV", License = "Standby license" },
        new LicenseInfo { Server = "DEV-NODE-4", License = "license 4" },
        new LicenseInfo { Server = "DEV-NODE-5", License = " license 5" },
        new LicenseInfo { Server = "DEV-NODE-6", License = "license 6" },
        new LicenseInfo { Server = "DEV-NODE-7", License = " license 7" },
    };
}