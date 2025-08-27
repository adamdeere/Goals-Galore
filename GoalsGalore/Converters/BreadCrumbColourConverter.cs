using System.Globalization;

namespace GoalsGalore.Converters;

public class StepBgConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        int current = (int)value;
        int target = int.Parse(parameter.ToString());
        return current >= target ? Color.FromArgb("#2196F3") : Color.FromArgb("#E0E0E0");
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();
}

public class StepTextConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        int current = (int)value;
        int target = int.Parse(parameter.ToString());
        return current >= target ? Colors.White : Colors.Black;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();
}

public class StepLineConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        int current = (int)value;
        int target = int.Parse(parameter.ToString());
        return current >= target ? Color.FromArgb("#2196F3") : Color.FromArgb("#E0E0E0");
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();
}