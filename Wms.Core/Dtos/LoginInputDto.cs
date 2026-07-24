using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wms.Core.Dtos
{
    /// <summary>
    /// 登录参数
    /// </summary>
    public class LoginInputDto : BaseDto
    {
        private string _userName;

        public string UserName
        {
            get => _userName;
            set =>SetProperty(ref _userName, value);
        }

        private string _password;

        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }
    }
}
