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
using Avalonia.LogicalTree;

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
}
