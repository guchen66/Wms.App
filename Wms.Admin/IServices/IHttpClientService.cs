using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wms.Admin.IServices
{
    public interface IHttpClientService
    {
        /// <summary>
        /// 获取网站标题
        /// </summary>
        /// <returns></returns>
        string GetTitle();

        /// <summary>
        /// 获取网站标题
        /// 需要响应的字符编码
        /// </summary>
        /// <returns></returns>
        string GetTitle(string encoding);

        string GetUrl();

        /// <summary>
        /// 获取超链接
        /// </summary>
        /// <returns></returns>
        string GetLink();

        /// <summary>
        /// 获取超链接集合
        /// </summary>
        /// <returns></returns>
        ICollection<string> GetLinks();
    }
}
