using System.Collections.Generic;
using System.Linq;
using Avalonia.Media;
using CommunityToolkit.Mvvm.ComponentModel;

namespace LoginScreenEMX.Helpers
{
    public partial class FontTag : ObservableObject
    {
        [ObservableProperty] private string _fontFamily = "Arial";
        [ObservableProperty] private string _fontStyleName = "Обычный";
        [ObservableProperty] private double _fontSize = 14;
        [ObservableProperty] private bool _isStrikethrough = false;
        [ObservableProperty] private bool _isUnderline = false;
        [ObservableProperty] private string _characterSet = "Кириллица";

        public string DisplayText => $"{FontFamily}, {FontStyleName}, {FontSize}pt";

        partial void OnFontFamilyChanged(string value)    => OnPropertyChanged(nameof(DisplayText));
        partial void OnFontStyleNameChanged(string value) => OnPropertyChanged(nameof(DisplayText));
        partial void OnFontSizeChanged(double value)      => OnPropertyChanged(nameof(DisplayText));

        public FontWeight Weight => FontStyleName switch
        {
            "Полужирный"        => FontWeight.Bold,
            "Полужирный курсив" => FontWeight.Bold,
            _                   => FontWeight.Normal
        };

        public FontStyle Style => FontStyleName switch
        {
            "Курсив"            => FontStyle.Italic,
            "Полужирный курсив" => FontStyle.Italic,
            _                   => FontStyle.Normal
        };

        public TextDecorationCollection? TextDecorations
        {
            get
            {
                if (IsStrikethrough && IsUnderline)
                    return new TextDecorationCollection
                    {
                        Avalonia.Media.TextDecorations.Strikethrough[0],
                        Avalonia.Media.TextDecorations.Underline[0]
                    };

                if (IsStrikethrough)
                    return Avalonia.Media.TextDecorations.Strikethrough;

                if (IsUnderline)
                    return Avalonia.Media.TextDecorations.Underline;

                return null;
            }
        }

        partial void OnIsStrikethroughChanged(bool value) => OnPropertyChanged(nameof(TextDecorations));
        partial void OnIsUnderlineChanged(bool value)     => OnPropertyChanged(nameof(TextDecorations));
    }

    public static class FontHelper
    {
        public static List<string> SystemFonts { get; } =
            FontManager.Current.SystemFonts
                .Select(f => f.Name)
                .OrderBy(n => n)
                .ToList();

        public static List<string> FontStyles { get; } =
        [
            "Обычный",
            "Курсив",
            "Полужирный",
            "Полужирный курсив"
        ];

        public static List<string> CharacterSets { get; } =
        [
            "Кириллица",
            "Латиница",
            "Греческий",
            "Арабский",
            "Китайский",
            "Японский",
            "Корейский",
            "Символы"
        ];
    }
}