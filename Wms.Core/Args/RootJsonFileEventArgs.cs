using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wms.Core.Args
{
    public class RootJsonFileEventArgs : EventArgs
    {
        public RootJsonFile DefaultJsonFile { get; set; }
        public RootJsonFileEventArgs(RootJsonFile rootJsonFile)
        {
            DefaultJsonFile = rootJsonFile;
        }
    }

    public class RootFile
    {
        public Type Type { get; set; }
        public RootJsonFile RootJsonFile { get; set; }

    }

    public class RootJsonFile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Source { get; set; }          //具体位置
        public string IsChanged { get; set; }       //Json文件是否改动过
    }
}
