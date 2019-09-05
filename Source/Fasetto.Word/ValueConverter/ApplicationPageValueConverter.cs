using System;
using System.Diagnostics;
using System.Globalization;
using Fasetto.Word.DataModel;
using Fasetto.Word.Pages;

namespace Fasetto.Word.ValueConverter
{
    /// <summary>
    /// Converts the <see cref="ApplicationPage"/> to an actual view/Page
    /// </summary>
    public class ApplicationPageValueConverter : BaseValueConverter<ApplicationPageValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return null;

            // Find the appropriate page
            switch ((ApplicationPage)value)
            {
                case ApplicationPage.Login:
                    return new LoginPage();

                default:
                    Debugger.Break();
                    return null;
            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
