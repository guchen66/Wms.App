using Wms.Core.Dtos;
using Wms.Core.Events;
using Wms.Data.Models;
using Newtonsoft.Json;
using Prism.Events;
using Prism.Ioc;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Wms.Admin.Providers.LoginSign
{
    public class LoginService : ILoginService
    {
        public SimpleClient<UserInfo> db = new SimpleClient<UserInfo>();
        private readonly IEventAggregator _eventAggregator;
        //  private readonly ILogger _logger;
        private readonly IContainerProvider _container;
        public LoginService(IEventAggregator eventAggregator, IContainerProvider container)
        {
            //  this._logger = logger;
            _eventAggregator = eventAggregator;
            _container = container;
            _eventAggregator.GetEvent<LoginEvent>().Subscribe(LoginExecute);
            _eventAggregator.GetEvent<LogOutEvent>().Subscribe(async () => await LogoutAsync());
        }

        public void LoginExecute(Window win)
        {
            win.DialogResult = true;    //Window.DialogResult 属性表示对话框的返回值=true表示APp.xaml.cs中的MainWindow已经成功登录，                                        //  win.Close();             //然后关闭LoginView
            // 关闭当前登录界面
            LogoutAsync();
        }

        public Task LogoutAsync()
        {
            // 查找当前活动窗口并关闭
            var activeWindow = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.IsActive);
            activeWindow?.Close();
            return Task.CompletedTask;
        }

        public async Task<bool> LoginAsync(LoginInputDto loginDto)
        {
            if (loginDto == null || string.IsNullOrWhiteSpace(loginDto.UserName) || string.IsNullOrWhiteSpace(loginDto.Password)) 
                return false;
            
            // 查询数据库验证用户名和密码是否匹配
            var userInfo = await db.GetFirstAsync(x => x.Name == loginDto.UserName && x.Password == loginDto.Password);
            return userInfo != null;
        }

        public Task<bool> RegisterAsync()
        {
            throw new NotImplementedException();
        }
    }
}
