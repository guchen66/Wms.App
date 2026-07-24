using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wms.Communication.Interfances
{
    public interface ICommunicate
    {
        bool Open();
        void Close();
    }

    public enum CommunicateModel
    {
        /// <summary>
        /// 未知模式
        /// </summary>
        Note,

        /// <summary>
        /// Tcp通讯
        /// </summary>
        Net,

        /// <summary>
        /// 串口通讯
        /// </summary>
        Port
    }
}
