using System.Collections.Generic;
using System.Text;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Media;

namespace LoginScreenEMX.Views;

public partial class CustomDialog : Window
{
    private bool _isDetailsVisible;
    public bool DialogResult { get; private set; }
    
    public CustomDialog()
    {
        InitializeComponent();
        InitializeDetails();
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
    private void InitializeDetails()
    {
        // Вариант 1: Простой текст
        var details = new StringBuilder();
        details.AppendLine("Статус клиента: проверен");
        details.AppendLine("Статус сервера LOAD002: проверен");
        details.AppendLine("Sponsor host system integrity status: проверен");
        details.AppendLine("Версия API: 2.5.3");
        details.AppendLine("Последняя проверка: 17.03.2026 14:30");
        details.AppendLine("Активных сессий: 3");
        details.AppendLine("Ошибок: 0");
        
        DetailsTextBox.EditorValue = details.ToString();
    }

    // Метод для добавления дополнительных деталей
    public void AddDetail(string label, string value)
    {
        var currentText = DetailsTextBox.EditorValue?.ToString() ?? string.Empty;
        DetailsTextBox.EditorValue = currentText + $"\n{label}: {value}";
    }

    // Метод для установки всех деталей сразу
    public void SetDetails(string details)
    {
        DetailsTextBox.EditorValue = details;
    }

    // Метод для установки деталей из словаря
    public void SetDetails(Dictionary<string, string> detailsDict)
    {
        var sb = new StringBuilder();
        foreach (var kvp in detailsDict)
        {
            sb.AppendLine($"{kvp.Key}: {kvp.Value}");
        }
        DetailsTextBox.EditorValue = sb.ToString();
    }

    private void DetailsButton_Click(object? sender, RoutedEventArgs e)
    {
        DetailsPanel.IsVisible = !DetailsPanel.IsVisible;

        // Отражение по вертикали
        if (DetailsPanel.IsVisible)
        {
            DetailsIcon.RenderTransform = new ScaleTransform(1, -1);
            DetailsIcon.Margin = new Thickness(0, 0, 0, 6);
        }
        else
        {
            DetailsIcon.RenderTransform = new ScaleTransform(1, 1);
            DetailsIcon.Margin = new Thickness(0, 6, 0, 0);
        }
    }
}