using Wms.Admin.IRepositorys;
using Wms.Controls.Mvvm;
using Wms.Core.Consts;
using Wms.Data.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Wms.Controls.ViewModels.SettingSign
{
    public class PrescriptionDialogViewModel : BaseDialogAware
    {
        #region 字段、属性

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

        private RepiceModel _repice;

        public RepiceModel Repice
        {
            get => _repice;
            set => SetProperty(ref _repice, value);
        }


        #endregion

        public PrescriptionDialogViewModel(IBaseRepository<UserInfo> userRepository)
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
           
        }

        public override void OnDialogOpened(IDialogParameters parameters)
        {
            if (parameters.ContainsKey("RefreshValue"))
            {
                
            }
        }

        private void ExecuteSave(string parameter)
        {
            var lastRow = _userRepository.Context.Queryable<UserInfo>().OrderByDescending(it => it.Id).First();


            RaiseRequestClose(new DialogResult(ButtonResult.OK));
        }

        private void ExecuteCancel(string parameter)
        {
            RaiseRequestClose(new DialogResult(ButtonResult.No));
        }
        #endregion
    }

    public class RepiceModel:BindableBase
    {
        private string _repice1;

        public string Repice1
        {
            get => _repice1;
            set => SetProperty(ref _repice1, value);
        }

        private string _repice2;

        public string Repice2
        {
            get => _repice2;
            set => SetProperty(ref _repice2, value);
        }

        private string _repice3;

        public string Repice3
        {
            get => _repice3;
            set => SetProperty(ref _repice3, value);
        }
        private string _repice4;

        public string Repice4
        {
            get => _repice4;
            set => SetProperty(ref _repice4, value);
        }

        private string _repice5;

        public string Repice5
        {
            get => _repice5;
            set => SetProperty(ref _repice5, value);
        }

    }
}
