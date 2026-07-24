using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Wms.Communication.MES
{
    public class MesApiClient
    {
        private readonly HttpClient _httpClient;

        public MesApiClient()
        {
            _httpClient = new HttpClient();
        }

        public async Task<bool> UploadDataToMesAsync(object data)
        {
            try
            {
                var json = JsonConvert.SerializeObject(data);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                // 替换成MES系统的Web API URL
                var url = MesProvider.Url;

                // 发送POST请求
                var response = await _httpClient.PostAsync(url, content);

                // 检查响应状态码
                if (response.IsSuccessStatusCode)
                {
                    // 解析响应内容（如果需要）
                    // var responseContent = await response.Content.ReadAsStringAsync();
                    return true;
                }
                else
                {
                    // 处理错误响应
                    Console.WriteLine("Error: " + response.StatusCode);
                    return false;
                }
            }
            catch (Exception ex)
            {
                // 记录或显示错误信息
                Console.WriteLine("Exception: " + ex.Message);
                return false;
            }
        }
    }
}
