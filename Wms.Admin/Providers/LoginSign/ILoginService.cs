using Wms.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wms.Admin.Providers.LoginSign
{
    public interface ILoginService
    {
        /// <summary>
        /// 登录
        /// </summary>
        /// <returns></returns>
        Task<bool> LoginAsync(LoginInputDto loginDto);

        /// <summary>
        /// 退出
        /// </summary>
        /// <returns></returns>
        Task LogoutAsync();
    }
}
