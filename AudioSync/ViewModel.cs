using AudioSync.Properties;
using Reactive.Bindings;
using System.Collections.ObjectModel;

namespace AudioSync {
    public class ViewModel {
        public ObservableCollection<ListBoxTemplate> ListBoxitems { get; } = new ObservableCollection<ListBoxTemplate>();
        public ReactiveProperty<short> OutIndex { get; } = new ReactiveProperty<short>(Settings.Default.outindex);
        public ReactiveProperty<double> Pvalue { get; } = new ReactiveProperty<double>();
        public ReactiveProperty<string> Src { get; } = new ReactiveProperty<string>(Settings.Default.src);
        public ReactiveProperty<string> Dst { get; } = new ReactiveProperty<string>(Settings.Default.dst);
        public ReactiveProperty<bool> Idle { get; } = new ReactiveProperty<bool>(true);
        public ReactiveProperty<bool> ShowPanel { get; } = new ReactiveProperty<bool>();
        public ReactiveProperty<bool> Waiting { get; } = new ReactiveProperty<bool>();
        public ReactiveProperty<bool> Embed { get; } = new ReactiveProperty<bool>(Settings.Default.embed);
        public ReactiveProperty<bool> Mirroring { get; } = new ReactiveProperty<bool>(Settings.Default.mirroring);
    }
}
