using Wms.Core.Consts;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wms.Controls.Mvvm
{
    public abstract class BaseDialogAware : BindableBase, IDialogAware
    {
        public string Title => "弹窗基类";
        private DateTime _dateValue = DateTime.Now;
        public DateTime DateValue
        {
            get { return _dateValue; }
            set { SetProperty(ref _dateValue, value); }
        }
        public event Action<IDialogResult> RequestClose;
        private RoleEnum _roleName;

        public RoleEnum RoleName
        {
            get => _roleName;
            set => SetProperty(ref _roleName, value);
        }
        public bool CanCloseDialog()
        {
            return true;
        }

        public virtual void OnDialogClosed()
        {
            RequestClose?.Invoke(new DialogResult(ButtonResult.OK));
        }

        public virtual void OnDialogOpened(IDialogParameters parameters)
        {
            
        }

        //触发窗体关闭事件
        public virtual void RaiseRequestClose(IDialogResult dialogResult)
        {
            RequestClose?.Invoke(dialogResult);
        }
    }
}
