using Wms.Communication.Interfances;
using Wms.Communication.Models;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Wms.Communication.Bases
{
    /// <summary>
    /// 通讯的基类
    /// </summary>
    public abstract class CommunicateBase : ICommunicate
    {
        //字段成员
        public SerialPort serialPort = null;
        public TcpClient tcpClient = null;
        public CommunicateModel CommunicateModel = CommunicateModel.Note;

        //环形缓冲区
        internal RingBufferManager RingBuffer = null;
        internal object lockRingBuffer = new object();

        //属性成员

        /// <summary>
        /// 连接状态
        /// </summary>
        public bool Connected { get; internal set; }
        public abstract bool Open();
        public abstract void Close();

    }
}
