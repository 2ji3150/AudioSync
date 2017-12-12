using System.Windows;

namespace AudioSync {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class SyncPreReport : Window {
        public SyncPreReport(ref ResourceDictionary dict, ref int[] change) {
            Resources.MergedDictionaries.Add(dict);
            InitializeComponent();
            DST_ADD.Text += $" {change[0]}";
            DST_U.Text += $" {change[1]}";
            DST_D.Text += $" {change[2]}";
        }

        private void ButtonOK_Click(object sender, RoutedEventArgs e) => DialogResult = true;

        private void Close_Executed(object sender, RoutedEventArgs e) => Close();
    }
}
