namespace AudioSync {
    class ListBoxTemplate {
        private short _iconID;
        private string _fullpath;

        public ListBoxTemplate(short ID, string Path) {
            _iconID = ID;
            _fullpath = Path;
        }
        public short IconID {
            get => _iconID; set => _iconID = value;
        }
        public string FullPath {
            get => _fullpath; set => _fullpath = value;
        }
    }
}
