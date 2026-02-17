using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace LoginScreenEMX.Views;

public partial class ErrorBlockView : UserControl
{
    public static readonly StyledProperty<string> HeaderTextProperty =
        AvaloniaProperty.Register<ErrorBlockView, string>(nameof(HeaderText), "Default Text");
        
    public static readonly StyledProperty<string> BodyTextProperty =
        AvaloniaProperty.Register<ErrorBlockView, string>(nameof(BodyText), "Default Text");
    
    public string HeaderText
    {
        get => GetValue(HeaderTextProperty);
        set => SetValue(HeaderTextProperty, value);
    }
        
    public string BodyText
    {
        get => GetValue(BodyTextProperty);
        set => SetValue(BodyTextProperty, value);
    }
    public ErrorBlockView()
    {
        InitializeComponent();
    }
}