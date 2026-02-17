using System.Collections.Generic;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Controls.Primitives;
using Eremex.AvaloniaUI.Controls.Editors;
using Eremex.AvaloniaUI.Controls.Utils;


namespace LoginScreenEMX.Views;

public partial class ConnectToServerView : UserControl
{
    private bool _isSearchInProgress = false;
    private bool _isNodeMode = false; // Флаг для отслеживания состояния

    public ConnectToServerView()
    {
        InitializeComponent();
    }


    private async void SearchButton_Click(object sender, RoutedEventArgs e)
    {
        if (_isSearchInProgress) return;

        var button = sender as ToggleButton;
        if (button == null) return;

        _isSearchInProgress = true;

        // Показываем спиннер и скрываем иконки
        SearchSpinner.IsVisible = true;
        IconsPanel.IsVisible = false;
        button.IsEnabled = false;

        try
        {
            await PerformSearchLogic();

            // Переключаем режим
            _isNodeMode = !_isNodeMode;

            // Обновляем блоки и иконки
            ToggleBlocks(_isNodeMode);
            ToggleInfo(_isNodeMode);
            UpdateIconsVisibility(_isNodeMode);

            // Обновляем состояние кнопки
            button.IsChecked = _isNodeMode;
        }
        finally
        {
            SearchSpinner.IsVisible = false;
            IconsPanel.IsVisible = true;
            button.IsEnabled = true;
            _isSearchInProgress = false;
        }
    }

    private void UpdateIconsVisibility(bool isChecked)
    {
        if (IconsPanel.Children.Count >= 2)
        {
            var offIcon = IconsPanel.Children[0] as PathIcon;
            var onIcon = IconsPanel.Children[1] as PathIcon;

            if (offIcon != null)
                offIcon.IsVisible = !isChecked;
            if (onIcon != null)
                onIcon.IsVisible = isChecked;
        }
    }

    private void ToggleInfo(bool showNode)
    {
        if (showNode)
        {
            InfoContentControl.Content = new SuccessBlockView
            {
                HeaderText = "Node Search Success:",
                BodyText = "Message providing information to the user with actionable insights."
            };
        }
        else
        {
            InfoContentControl.Content = new InfoBlockView()
            {
                HeaderText = "Connections Tips:",
                BodyText = "Message providing information to the user with actionable insights."
            };
        }
    }

    private void ToggleBlocks(bool showNode)
    {
        if (HostBlock != null)
            HostBlock.IsVisible = !showNode;
        if (NodeBlock != null)
            NodeBlock.IsVisible = showNode;
    }

    private void CloseButton_Click(object? sender, RoutedEventArgs e)
    {
        if (VisualRoot is MainWindow mainWindow)
        {
            mainWindow.CloseWindow();
        }
    }
    
    private void ErrorConnection_Click(object? sender, RoutedEventArgs e)
    {
        if (VisualRoot is MainWindow mainWindow)
        {
            InfoContentControl.Content = new ErrorBlockView
            {
                HeaderText = "Error Connection:",
                BodyText = "Message providing information to the user with actionable insights."
            };
        }
    }

    private void TitleBar_PointerPressed(object? sender, PointerPressedEventArgs e)
    {
        if (VisualRoot is MainWindow mainWindow)
        {
            mainWindow.BeginWindowDrag(e);
        }
    }

    private async Task PerformSearchLogic()
    {
        // Ваша логика поиска
        await Task.Delay(3000);
    }

    public class PasswordBoxBehavior : Avalonia.Xaml.Interactivity.Behavior<TextEditor>
    {
        private const string revealButtonClassName = "revealPasswordButton";
        public char PasswordChar { get; set; } = '*';
        public bool ShowRevealButton { get; set; } = true;

        protected override void OnAttached()
        {
            base.OnAttached();
            if (AssociatedObject != null)
                AssociatedObject.Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            var realEditor = AssociatedObject.FindVisualChild<TextBox>();
            if (realEditor == null)
                return;
            realEditor.PasswordChar = PasswordChar;
            if (ShowRevealButton)
                realEditor.Classes.Add(revealButtonClassName);
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            if (AssociatedObject != null)
                AssociatedObject.Loaded -= OnLoaded;
        }
    }

    private void ProxySettings_Click(object? sender, RoutedEventArgs e)
    {
        if (VisualRoot is MainWindow mainWindow)
        {
            mainWindow.ShowProxySettings();
        }
    }
}