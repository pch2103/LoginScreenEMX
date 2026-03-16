using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.VisualTree;
using Avalonia.VisualTree;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using Avalonia.LogicalTree;
using Eremex.AvaloniaUI.Controls;

namespace LoginScreenEMX.Views;

public partial class DateColorFontView : UserControl
{
    public DateColorFontView()
    {
        InitializeComponent();
        DataContext = new DateColorFontViewModel();
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
    
    private async void ShowCustomDialog_Click(object? sender, RoutedEventArgs e)
    {
        // Найти родительское окно
        var parentWindow = this.FindAncestorOfType<Window>();
        
        // Создать диалог
        var dialog = new CustomDialog();
        
        // Показать как модальное окно (блокирует родительское окно)
        await dialog.ShowDialog(parentWindow);
        
        // Обработать результат после закрытия диалога
        if (dialog.DialogResult)
        {
            Debug.WriteLine("User clicked Yes");
            // Ваша логика при нажатии Yes
            PerformAction();
        }
        else
        {
            Debug.WriteLine("User clicked No");
            // Ваша логика при нажатии No
        }
    }
    
    private void PerformAction()
    {
        // Действие при подтверждении
        Debug.WriteLine("Action performed");
    }
}
