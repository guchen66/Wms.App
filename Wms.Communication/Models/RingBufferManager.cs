using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wms.Communication.Models
{
    public class RingBufferManager
    {
        public byte[] RingBuffer { get; set; }     //存放内存的数组

        public int DataCount { get; set; }         //写入数据的大小

        public int DataStart { get; set; }         //数据起始索引

        public int DataEnd { get; set; }           //数据结束索引

        public RingBufferManager(int bufferSize)
        {
            DataCount = 0;

            DataStart = 0;

            DataEnd = 0;

            RingBuffer = new byte[bufferSize];
        }

        public byte this[int index]
        {
            get
            {
                if (index >= DataCount) throw new Exception("环形缓冲区异常，索引溢出");
                if (DataStart + index < RingBuffer.Length)
                {
                    return RingBuffer[DataStart + index];
                }
                else
                {
                    return RingBuffer[(DataStart + index) - RingBuffer.Length];
                }
            }

        }

        public int GetDataCount()  //获得当前写入的字节数
        {
            return DataCount;
        }

        public int GetReserveCount()  //获得剩余的字节数
        {
            return RingBuffer.Length - DataCount;
        }

        public void Clear()
        {
            DataCount = 0;
        }

        public void Clear(int count) //清空指定大小的数据
        {
            if (count >= DataCount)     //如果需要清理的数据大小大于现有的数据大小，则全部清理
            {
                DataCount = 0;
                DataStart = 0;
                DataEnd = 0;
            }
            else
            {
                if (DataStart + count >= RingBuffer.Length)
                {
                    DataStart = (DataStart + count) - RingBuffer.Length;
                }
                else
                {
                    DataStart += count;
                }
                DataCount -= count;
            }
        }

        public void WriteBuffer(byte[] buffer, int offset, int count)
        {
            Int32 reserveCount = RingBuffer.Length - DataCount;
            if (reserveCount >= count)                              //可用空间够用
            {
                if (DataEnd + count < RingBuffer.Length)              //数据没到结尾
                {
                    Array.Copy(buffer, offset, RingBuffer, DataEnd, count);
                    DataEnd += count;
                    DataCount += count;
                }
                else
                {
                    Debug.WriteLine("缓存重新开始........");
                    Int32 overflowIndexLength = (DataEnd + count) - RingBuffer.Length;        //超出索引长度
                    Int32 endPushIndexLength = count - overflowIndexLength;              //填充在末尾的数据长度
                    Array.Copy(buffer, offset, RingBuffer, DataEnd, endPushIndexLength);
                    DataEnd = 0;
                    offset += endPushIndexLength;
                    DataCount += endPushIndexLength;
                    if (overflowIndexLength != 0)
                    {
                        Array.Copy(buffer, offset, RingBuffer, DataEnd, overflowIndexLength);
                    }
                    DataEnd += overflowIndexLength;                            //结束索引
                    DataCount += overflowIndexLength;                           //缓存大小
                }
            }
            else
            {
                //缓存溢出，不处理

            }

        }

        public void ReadBuffer(byte[] targetBytes, Int32 offset, Int32 count)
        {
            if (count > DataCount) throw new Exception("环形缓冲区异常，读取长度大于数据长度");
            Int32 tempDataStart = DataStart;
            if (DataStart + count < RingBuffer.Length)
            {
                Array.Copy(RingBuffer, DataStart, targetBytes, offset, count);
            }
            else
            {
                Int32 overflowIndexLength = (DataEnd + count) - RingBuffer.Length;        //超出索引长度
                Int32 endPushIndexLength = count - overflowIndexLength;              //填充在末尾的数据长度
                Array.Copy(RingBuffer, offset, targetBytes, offset, endPushIndexLength);

                offset += endPushIndexLength;

                if (overflowIndexLength != 0)
                {
                    Array.Copy(RingBuffer, 0, targetBytes, DataEnd, overflowIndexLength);
                }
                DataEnd += overflowIndexLength;                            //结束索引
                DataCount += overflowIndexLength;                           //缓存大小

            }

        }

        public void WriteBuffer(byte[] buffer)
        {
            WriteBuffer(buffer, 0, buffer.Length);
        }
    }
}
