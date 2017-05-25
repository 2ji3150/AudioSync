using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Media;
using System.Net;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using AudioSync.Properties;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace AudioSync {
    public partial class MainWindow : Window {
        public MainWindow() {
            SwitchLanguageDictionary();
            InitializeComponent();
            DataContext = vm;
        }
        public static RoutedCommand SyncCommand = new RoutedCommand();
        ViewModel vm = new ViewModel();
        ResourceDictionary dict = new ResourceDictionary();
        readonly Uri us = new Uri($"..\\Resources\\StringResources.xaml", UriKind.Relative), jp = new Uri($"..\\Resources\\StringResources.ja.xaml", UriKind.Relative);
        private void SyncCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e) => e.CanExecute = Directory.Exists(vm.Src) && Directory.Exists(vm.Dst);

        private async void SyncCommand_Executed(object sender, ExecutedRoutedEventArgs e) {
            vm.ListBoxitems.Clear();
            SyncService syncservice = new SyncService(ref vm);
            ushort[] change = syncservice.Scan();
            SyncPreReport spr = new SyncPreReport(ref dict, ref change) { Owner = this };
            if (spr.ShowDialog() != true) {
                vm.Idle = true;
                return;
            }
            await syncservice.Sync();
            SystemSounds.Asterisk.Play();
            MessageBox.Show(Properties.Resources.msgbox_complete);
            vm.ListBoxitems.Clear();
            vm.Pvalue = 0;
            vm.Idle = true;
        }

        #region 多言語
        private void Janpanese_Click(object sender, RoutedEventArgs e) {
            dict.Source = jp;
            Resources.MergedDictionaries.Add(dict);
            Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("ja");
        }
        private void English_Click(object sender, RoutedEventArgs e) {
            dict.Source = us;
            Resources.MergedDictionaries.Add(dict);
            Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("en");
        }

        private void SwitchLanguageDictionary() {
            dict.Source = Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName == "ja" ? jp : us;
            Resources.MergedDictionaries.Add(dict);
        }
        #endregion

        private void Src_ofd_Click(object sender, RoutedEventArgs e) {
            using (var dialog = new CommonOpenFileDialog() { IsFolderPicker = true }) {
                if (dialog.ShowDialog() == CommonFileDialogResult.Ok) vm.Src = dialog.FileName;
            }
        }
        private void Dst_opd_Click(object sender, RoutedEventArgs e) {
            using (var dialog = new CommonOpenFileDialog() { IsFolderPicker = true }) {
                if (dialog.ShowDialog() == CommonFileDialogResult.Ok) vm.Dst = dialog.FileName;
            }
        }

        private void Setting_Click(object sender, RoutedEventArgs e) => vm.ShowPanel = !vm.ShowPanel;
        private void About_Click(object sender, RoutedEventArgs e) => MessageBox.Show($"{Assembly.GetExecutingAssembly().GetName().Version}{Environment.NewLine}by Heiseikiseki");

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
            Settings.Default.src = vm.Src;
            Settings.Default.dst = vm.Dst;
            Settings.Default.outindex = vm.OutIndex;
            Settings.Default.embed = vm.Embed;
            Settings.Default.mirroring = vm.Mirroring;
            Settings.Default.Save();
        }

        private async void CheckNewVer_Click(object sender, RoutedEventArgs e) {
            vm.Waiting = true;
            string newversion = null;
            await Task.Run(() => {
                using (WebClient wc = new WebClient()) {
                    using (Stream st = wc.OpenRead("https://www.dropbox.com/s/ck0x7a82l3xg1wr/AudioSync.txt?dl=1")) {
                        using (StreamReader sr = new StreamReader(st)) {
                            newversion = sr.ReadToEnd();
                        }
                    }
                }
            });
            vm.Waiting = false;
            if (Assembly.GetExecutingAssembly().GetName().Version.ToString() != newversion) {
                if (MessageBox.Show(Properties.Resources.msgbox_haveupdate, "AudioSync", MessageBoxButton.YesNo, MessageBoxImage.Information) != MessageBoxResult.Yes) return;
                Process.Start("https://sourceforge.net/projects/audio-sync/files/latest/download");
            }
            else MessageBox.Show(Properties.Resources.msgbox_noupdate);
        }
    }
}