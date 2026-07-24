using HtmlAgilityPack;
using Wms.Admin.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wms.Admin.Services
{
    public class HttpClientService : IHttpClientService
    {
        public string GetLink()
        {
            throw new NotImplementedException();
        }

        public ICollection<string> GetLinks()
        {
            throw new NotImplementedException();
        }

        public string GetTitle()
        {
            var html=GetUrl();
            HtmlWeb web = new HtmlWeb();
            HtmlDocument htmlDoc = web.Load(html);
            var node=htmlDoc.DocumentNode.SelectSingleNode("title");
            return node.InnerText;
        }

        public string GetUrl()
        {
            throw new NotImplementedException();
        }


        public void GetNetEncoding()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            var encoding=  Encoding.GetEncoding("GBK");
        }

        public string GetTitle(string encoding)
        {
            throw new NotImplementedException();
        }
    }
}
