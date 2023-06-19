﻿namespace SmartGenealogy.Converters;

public class AvatarWithStatusColorConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        string resourceName;

        var stringValue = value != null ? value.ToString() : string.Empty;

        switch (stringValue)
        {
            case nameof(AvatarStatus.Online):
                resourceName = "Green";
                break;

            case nameof(AvatarStatus.Busy):
                resourceName = "Red";
                break;

            case nameof(AvatarStatus.Away):
                resourceName = "Orange";
                break;

            default: // Offline
                resourceName = "DisabledColor";
                break;
        }

        return ResourceHelper.FindResource<Color>(resourceName);
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotSupportedException();
    }
}