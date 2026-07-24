using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Wms.Controls.Mvvm;
using Wms.Data.Models;
using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using SqlSugar.IOC;
using Wms.Controls.Commands;
using Wms.Core.Events;
using NewLife.Log;
using Wms.Core.Dtos;
using System.DirectoryServices.Protocols;
using Wms.Core.Consts;
using SqlSugar;
using Wms.Admin.IServices;
using Wms.Admin.IRepositorys;
using Wms.Admin.Providers.LoginSign;

namespace Wms.App.ViewModels
{
    public class LoginWindowViewModel : BaseViewModel
    {
        private string _userName;

        public string UserName
        {
            get => _userName;
            set => SetProperty(ref _userName, value);
        }

        private string _password;

        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        private string _errorMessage;

        public string ErrorMessage
        {
            get => _errorMessage;
            set => SetProperty(ref _errorMessage, value);
        }

        private bool _isErrorVisible;

        public bool IsErrorVisible
        {
            get => _isErrorVisible;
            set => SetProperty(ref _isErrorVisible, value);
        }

        private ILoginService _loginService;

        private readonly IBaseRepository<UserInfo> _userRepository;

        public LoginWindowViewModel(ILoginService loginService, IContainerProvider provider) : base(provider)
        {
            _userRepository = provider.Resolve<IBaseRepository<UserInfo>>();
            _loginService = loginService;
            LoginCommand = new DelegateCommand<Window>(async (win) => await ExecuteLogin(win));
            CancelCommand = new DelegateCommand(ExecuteCancel);
        }

        private async Task ExecuteLogin(Window win)
        {
            // 清除之前的错误提示
            IsErrorVisible = false;
            ErrorMessage = string.Empty;

            // 验证输入
            if (string.IsNullOrWhiteSpace(UserName))
            {
                ErrorMessage = "请输入用户名";
                IsErrorVisible = true;
                return;
            }

            if (string.IsNullOrWhiteSpace(Password))
            {
                ErrorMessage = "请输入密码";
                IsErrorVisible = true;
                return;
            }

            // 调用登录服务进行验证
            var loginResult = await _loginService.LoginAsync(new LoginInputDto
            {
                UserName = UserName,
                Password = Password
            });

            if (loginResult)
            {
                EventAggregator.GetEvent<LoginEvent>().Publish(win);
                await Task.Delay(100);
            }
            else
            {
                ErrorMessage = "用户名或密码错误，请重新输入";
                IsErrorVisible = true;
            }
        }

        private void ExecuteCancel()
        {
            EventAggregator.GetEvent<LogOutEvent>().Publish();
        }

        public ICommand LoginCommand { get; set; }
        public ICommand CancelCommand { get; set; }
    }
}