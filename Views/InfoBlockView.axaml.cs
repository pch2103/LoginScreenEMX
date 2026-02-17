using Avalonia;
using Avalonia.Controls;

namespace LoginScreenEMX.Views;

public partial class InfoBlockView : UserControl
{
    public static readonly StyledProperty<string> HeaderTextProperty =
        AvaloniaProperty.Register<InfoBlockView, string>(nameof(HeaderText), "Default Text");
        
    public static readonly StyledProperty<string> BodyTextProperty =
        AvaloniaProperty.Register<InfoBlockView, string>(nameof(BodyText), "Default Text");
    
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
    public InfoBlockView()
    {
        InitializeComponent();
    }
}