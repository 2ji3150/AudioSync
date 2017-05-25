using System;
using System.Windows.Data;
using System.Windows.Shell;

namespace AudioSync {
    [ValueConversion(typeof(bool), typeof(TaskbarItemProgressState))]
    public class ProgressStateConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) => ((bool?)value == true) ? TaskbarItemProgressState.Indeterminate : TaskbarItemProgressState.Normal;
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) => throw new NotSupportedException();
    }
}
