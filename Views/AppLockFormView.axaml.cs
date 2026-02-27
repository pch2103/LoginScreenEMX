using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Eremex.AvaloniaUI.Controls.Editors;
using Eremex.AvaloniaUI.Controls.Utils;

namespace LoginScreenEMX.Views;

public partial class AppLockFormView : UserControl
{
    public AppLockFormView()
    {
        InitializeComponent();
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
}