using Wms.Controls.Mvvm;
using Prism.Commands;
using Prism.Ioc;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Wms.Controls.ViewModels
{
    public class HomeViewModel : BaseViewModel, INavigationAware
    {
        #region  属性、字段

        private readonly IRegionManager _regionManager;
        private readonly IRegionNavigationJournal _journal;
        private readonly IRegionNavigationService _navigationService;
        #endregion

        #region  命令

        public ICommand BackDeskTopCommand { get; set; }
        #endregion

        public HomeViewModel(IContainerProvider provider) : base(provider)
        {
            _navigationService = provider.Resolve<IRegionNavigationService>();
            BackDeskTopCommand = new DelegateCommand(ShowDesktop);
        }

        #region  方法

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            // Do nothing
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            _navigationService.Journal.GoBack();
            /* _journal = navigationContext.NavigationService.Journal;
             if (_journal != null && _journal.CanGoBack)
            {
                _journal.GoBack();
            }
            */
        }

        private void ShowDesktop()
        {
            // 使用 Windows API 实现显示桌面功能（替代 Shell32 COM 引用）
            IntPtr hWnd = FindWindow("Shell_TrayWnd", null);
            if (hWnd != IntPtr.Zero)
            {
                SendMessage(hWnd, 0x0112, (IntPtr)0xF140, IntPtr.Zero);
            }
        }

        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);
        #endregion
    }
}
