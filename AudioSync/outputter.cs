using System.IO;

namespace AudioSync {
    public class Outputter {
        private IOut _iout;
        public string Out(string srcfile, string dstfile) => _iout.Out(srcfile, dstfile);
        public Outputter(IOut iout) => _iout = iout;
    }

    public interface IOut {
        string Out(string srcfile, string dstfile);
    }

    public class OutAppleCodec : IOut {
        const string aacarg = @"/c Encoder\qaac64 --normalize -V 127";
        public string Out(string srcfile, string dstfile) => $"{aacarg} {srcfile.WQ()} -o {dstfile.WQ()}";        
    }

    public class OutEmbededAppleCodec : IOut {
        const string aacarg = @"/c Encoder\qaac64 --normalize -V 127";
        public string Out(string srcfile, string dstfile) {
            string cover = Path.Combine(Directory.GetParent(srcfile).FullName, "Folder.jpg");         
            return $"{aacarg} --artwork {cover.WQ()} {srcfile.WQ()} -o {dstfile.WQ()}";
        }
    }
}
