using Wms.Admin.IRepositorys;
using Wms.Admin.Repositorys;
using Wms.Controls.Mvvm;
using Wms.Core.Consts;
using Wms.Core.Dtos;
using Wms.Data.Models;
using Microsoft.VisualBasic.ApplicationServices;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Wms.Controls.ViewModels.Dialogs
{
    public class UpdateUserInfoDialogViewModel : BaseDialogAware
    {
        #region 属性、字段

        public string Title => "修改UserInfo弹窗";

        public event Action action;
        List<UserInfo> UserInfos = null;
        public IBaseRepository<UserInfo> _userRepository;

        private int _currentId;

        public int CurrentId
        {
            get { return _currentId; }
            set { SetProperty(ref _currentId, value); }
        }

        private string _name;

        public string InputName
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        private string _password;

        public string InputPassword
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }


        public List<UserInfo> users = null;
        private ObservableCollection<UserInfo> _userInfoList;

        public ObservableCollection<UserInfo> UserInfoList
        {
            get { return _userInfoList; }
            set { SetProperty(ref _userInfoList, value); }
        }
        private DateTime _dateValue = DateTime.Now;
        public DateTime DateValue
        {
            get { return _dateValue; }
            set { SetProperty(ref _dateValue, value); }
        }
        #endregion

        public UpdateUserInfoDialogViewModel(IBaseRepository<UserInfo> userRepository)
        {
            _userRepository=userRepository;
            SaveCommand = new DelegateCommand<int?>(ExecuteSave);
            CancelCommand = new DelegateCommand<string>(ExecuteCancel);
        }

        #region 命令

        public ICommand SaveCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        #endregion

        #region 方法


        public override void OnDialogClosed()
        {
            action();
        }

        public override void OnDialogOpened(IDialogParameters parameters)
        {
            if (parameters.ContainsKey("dataList"))
            {
                users = parameters.GetValue<List<UserInfo>>("dataList");
                foreach (var user in users)
                {
                    CurrentId = user.Id;
                    InputName = user.Name;
                    InputPassword = user.Password;
                    DateValue = (DateTime)user.CreateTime;
                }
            }
            if (parameters.ContainsKey("RefreshValue"))
            {
                action = parameters.GetValue<Action>("RefreshValue");
            }
        }

        private void ExecuteSave(int? id)
        {
            
            var users = _userRepository.Context.Queryable<UserInfo>().Where(x => x.Id == id).First();
            if (users != null)
            {
                users.Name = InputName;
                users.Password = InputPassword;
              
                users.RoleId = RoleName.ToInt()+1;       //导航一对一修改RloId就行  +1是因为枚举从0开始的，而数据库Role表的主键是从1开始的
                users.UpdateTime = DateValue;
              var s=  _userRepository.Context.Updateable(users).ExecuteCommand();
            }
            RaiseRequestClose(new DialogResult(ButtonResult.OK));
        }

        private void ExecuteCancel(string parameter)
        {
            RaiseRequestClose(new DialogResult(ButtonResult.No));
         //   RequestClose?.Invoke(new DialogResult(ButtonResult.No));      // 使用基类后失效
        }

        #endregion
    }
}
