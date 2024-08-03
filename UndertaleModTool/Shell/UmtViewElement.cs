using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Windows;

namespace UndertaleModTool.Shell;

internal abstract class UmtViewElement : INotifyPropertyChanged
{
    public UIElement? View
    {
        get => view;
        set => SetProperty(ref view, value);
    }

    public string? Title
    {
        get => title;
        set => SetProperty(ref title, value);
    }

    public bool IsActive
    {
        get => isActive;
        set => SetProperty(ref isActive, value);
    }

    public bool IsSelected
    {
        get => isSelected;
        set => SetProperty(ref isSelected, value);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected void SetProperty<T>(
        [NotNullIfNotNull("newValue")] ref T property,
        T                                          newValue,
        [CallerMemberName] string                  propertyName = ""
    )
    {
        property = newValue;
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private UIElement? view;
    private string?    title;
    private bool       isActive;
    private bool       isSelected;
}