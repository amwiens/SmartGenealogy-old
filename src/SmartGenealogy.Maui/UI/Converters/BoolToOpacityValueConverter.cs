﻿using System.Collections;

namespace SmartGenealogy.Maui;

public class BoolToOpacityValueConverter : IValueConverter
{
    private readonly bool _inversed;

    public BoolToOpacityValueConverter(bool inversed = false)
    {
        _inversed = inversed;
    }

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var opacityWhenTrue = parameter is double opacity ? opacity : 1;
        var boolean = value is bool b && b;

        return _inversed && boolean
            || !_inversed && !boolean
            ? 0
            : opacityWhenTrue;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}

public class AllBoolsToOpacityValueConverter : BoolToOpacityValueConverter, IMultiValueConverter
{
    private readonly bool _inversed;

    public AllBoolsToOpacityValueConverter(bool inversed = false)
    {
        _inversed = inversed;
    }

    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        return Convert(values.All(x => x is bool b && (_inversed && !b || !_inversed && b)), targetType, parameter, culture);
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}

public class AnyFalseToOpacityValueConverter : BoolToOpacityValueConverter, IMultiValueConverter
{
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        return Convert(values.Any(x => x is not bool b || !b), targetType, parameter, culture);
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}

public class FirstItemValueConverter : IValueConverter, IMultiValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is IEnumerable items)
        {
            var enumerator = items.GetEnumerator();

            if (enumerator.MoveNext())
            {
                return enumerator.Current;
            }
        }

        return null;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }

    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        return values?.FirstOrDefault(x => x != null);
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}