using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Wms.Admin.IRepositorys;
using Wms.Admin.Repositorys;
using Wms.Controls.Mvvm;
using Wms.Core.Consts;
using Wms.Data.Models;
using Microsoft.VisualBasic.ApplicationServices;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;

namespace Wms.Controls.ViewModels.Dialogs
{
    public class AddUserInfoDialogViewModel : BaseDialogAware
    {
        #region 字段、属性

        public string Title => "添加用户弹窗";
      //  public event Action<IDialogResult> RequestClose;
        public event Action action;
        private IBaseRepository<UserInfo> _userRepository;
        private string _name;

        public string InputName
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        private string _jobNumber;

        public string JobNumber
        {
            get => _jobNumber;
            set => SetProperty(ref _jobNumber, value);
        }

        private int _sort;

        public int Sort
        {
            get => _sort;
            set => SetProperty(ref _sort, value);
        }

        private int _roldId;

        public int RoldId
        {
            get => _roldId;
            set => SetProperty(ref _roldId, value);
        }

        private string _password;

        public string InputPassword
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }

        private RoleEnum _roleName;

        public RoleEnum RoleName
        {
            get => _roleName;
            set => SetProperty(ref _roleName, value);
        }

      

        #endregion

        public AddUserInfoDialogViewModel(IBaseRepository<UserInfo> userRepository)
        {
            _userRepository = userRepository;
            SaveCommand = new DelegateCommand<string>(ExecuteSave);
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
            if (parameters.ContainsKey("RefreshValue"))
            {
                action = parameters.GetValue<Action>("RefreshValue");
            }
        }

        private void ExecuteSave(string parameter)
        {
            var lastRow = _userRepository.Context.Queryable<UserInfo>().OrderByDescending(it => it.Id).First();

            
            UserInfo userInfo = new UserInfo()
            {
                JobNumber = JobNumber,
                Name = InputName,
                Password = InputPassword,
                CreateTime = DateValue,
                UpdateTime = DateValue,
                RoleId = RoleName.ToInt()+1,                //因为NewLife扩展枚举转Int默认是从0开始的
                Role = new RoleInfo() // 创建RoleInfo对象并赋值给导航属性
                {
                    Name = Convert.ToString(RoleName),
                    Sort = (int)RoleName 
                }
            };
             _userRepository.Context.Insertable<UserInfo>(userInfo).ExecuteCommand();//.AddAsync(userInfo);

          //  RequestClose?.Invoke(new DialogResult(ButtonResult.OK));
            RaiseRequestClose(new DialogResult(ButtonResult.OK));
        }

        private void ExecuteCancel(string parameter)
        {
            
          //  RequestClose?.Invoke(new DialogResult(ButtonResult.No));
            RaiseRequestClose(new DialogResult(ButtonResult.No));
        }

       

        #endregion
    }
}
