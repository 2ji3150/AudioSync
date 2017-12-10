using System.Collections.ObjectModel;
using System.ComponentModel;
using AudioSync.Properties;
using Reactive.Bindings;

namespace AudioSync {
    class ViewModel : INotifyPropertyChanged {
        public ViewModel() => ListBoxitems = new ObservableCollection<ListBoxTemplate>();
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<ListBoxTemplate> ListBoxitems { get; set; }

        private static readonly PropertyChangedEventArgs OutIndexPropertyChangedEventArgs = new PropertyChangedEventArgs(nameof(OutIndex));
        private short _outindex = Settings.Default.outindex;
        public short OutIndex {
            get => _outindex;
            set {
                if (_outindex == value) return;
                _outindex = value;
                PropertyChanged?.Invoke(this, OutIndexPropertyChangedEventArgs);
            }
        }

        private static readonly PropertyChangedEventArgs PvaluePropertyChangedEventArgs = new PropertyChangedEventArgs(nameof(Pvalue));
        private double _pvalue;
        public double Pvalue {
            get => _pvalue;
            set {
                if (_pvalue == value) return;
                _pvalue = value;
                PropertyChanged?.Invoke(this, PvaluePropertyChangedEventArgs);
            }
        }

        private static readonly PropertyChangedEventArgs SrcPropertyChangedEventArgs = new PropertyChangedEventArgs(nameof(Src));
        private string _src = Settings.Default.src;
        public string Src {
            get => _src;
            set {
                if (_src == value) return;
                _src = value;
                PropertyChanged?.Invoke(this, SrcPropertyChangedEventArgs);
            }
        }

        private static readonly PropertyChangedEventArgs DstPropertyChangedEventArgs = new PropertyChangedEventArgs(nameof(Dst));
        private string _dst = Settings.Default.dst;
        public string Dst {
            get => _dst;
            set {
                if (_dst == value) return;
                _dst = value;
                PropertyChanged?.Invoke(this, DstPropertyChangedEventArgs);
            }
        }

        private static readonly PropertyChangedEventArgs IdlePropertyChangedEventArgs = new PropertyChangedEventArgs(nameof(Idle));
        private bool _idle = true;
        public bool Idle {
            get => _idle;
            set {
                if (_idle == value) return;
                _idle = value;
                PropertyChanged?.Invoke(this, IdlePropertyChangedEventArgs);
            }
        }

        private static readonly PropertyChangedEventArgs ShowPanelPropertyChangedEventArgs = new PropertyChangedEventArgs(nameof(ShowPanel));
        private bool _showpanel;
        public bool ShowPanel {
            get => _showpanel;
            set {
                if (_showpanel == value) return;
                _showpanel = value;
                PropertyChanged?.Invoke(this, ShowPanelPropertyChangedEventArgs);
            }
        }

        private static readonly PropertyChangedEventArgs WaitingPropertyChangedEventArgs = new PropertyChangedEventArgs(nameof(Waiting));

        private bool _waiting = false;
        public bool Waiting {
            get => _waiting;
            set {
                if (_waiting == value) return;
                _waiting = value;
                PropertyChanged?.Invoke(this, WaitingPropertyChangedEventArgs);
            }
        }

        private static readonly PropertyChangedEventArgs EmbedPropertyChangedEventArgs = new PropertyChangedEventArgs(nameof(Embed));
        private bool _embed = Settings.Default.embed;
        public bool Embed {
            get => _embed;
            set {
                if (_embed == value) return;
                _embed = value;
                PropertyChanged?.Invoke(this, EmbedPropertyChangedEventArgs);
            }
        }

        private static readonly PropertyChangedEventArgs MirroringPropertyChangedEventArgs = new PropertyChangedEventArgs(nameof(Mirroring));
        private bool _mirroring = Settings.Default.mirroring;
        public bool Mirroring {
            get => _mirroring;
            set {
                if (_mirroring == value) return;
                _mirroring = value;
                PropertyChanged?.Invoke(this, MirroringPropertyChangedEventArgs);
            }
        }
    }
}
