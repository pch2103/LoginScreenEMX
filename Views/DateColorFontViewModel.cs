using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Avalonia.Media;
using CommunityToolkit.Mvvm.ComponentModel;
using LoginScreenEMX.Helpers;

namespace LoginScreenEMX;


public class DateColorFontViewModel : INotifyPropertyChanged
{
    public ObservableCollection<Color> MyCustomColors { get; set; } = new()
    {
        Colors.Red,
        Colors.Blue,
        Colors.Green
    };
    
    public FontTag SelectedFont { get; set; } = new FontTag
    {
        FontFamily   = "Arial",
        FontStyleName = "Обычный",
        FontSize     = 14
    };

    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged([CallerMemberName] string? name = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

    private DateTime _selectedDateTime = DateTime.Now;
    public DateTime SelectedDateTime
    {
        get => _selectedDateTime;
        set
        {
            if (_selectedDateTime == value) return;
            _selectedDateTime = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(Hours));
            OnPropertyChanged(nameof(Minutes));
            OnPropertyChanged(nameof(Seconds));
        }
    }

    public decimal? Hours
    {
        get => _selectedDateTime.Hour;
        set
        {
            if (value == null || _selectedDateTime.Hour == (int)value) return;
            UpdateDateTime((int)value, Minutes.HasValue ? (int)Minutes.Value : 0, Seconds.HasValue ? (int)Seconds.Value : 0);
        }
    }

    public decimal? Minutes
    {
        get => _selectedDateTime.Minute;
        set
        {
            if (value == null || _selectedDateTime.Minute == (int)value) return;
            UpdateDateTime(Hours.HasValue ? (int)Hours.Value : 0, (int)value, Seconds.HasValue ? (int)Seconds.Value : 0);
        }
    }

    public decimal? Seconds
    {
        get => _selectedDateTime.Second;
        set
        {
            if (value == null || _selectedDateTime.Second == (int)value) return;
            UpdateDateTime(Hours.HasValue ? (int)Hours.Value : 0, Minutes.HasValue ? (int)Minutes.Value : 0, (int)value);
        }
    }

    private void UpdateDateTime(int h, int m, int s)
    {
        _selectedDateTime = _selectedDateTime.Date + new TimeSpan(h, m, s);
        OnPropertyChanged(nameof(SelectedDateTime));
        OnPropertyChanged(nameof(Hours));
        OnPropertyChanged(nameof(Minutes));
        OnPropertyChanged(nameof(Seconds));
    }
}