using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace InventoryApp.Views;

/// <summary>
/// Converts bool → Visibility in the opposite direction to BooleanToVisibilityConverter.
/// true  → Collapsed
/// false → Visible
/// </summary>
[ValueConversion(typeof(bool), typeof(Visibility))]
public sealed class InverseBoolToVisibilityConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        => value is true ? Visibility.Collapsed : Visibility.Visible;

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        => value is Visibility v && v != Visibility.Visible;
}