using MahApps.Metro.Controls.Dialogs;
using MapsterMapper;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Wms.Controls.Mvvm
{
    /// <summary>
    /// 中继层，导航的基类
    /// </summary>
    public abstract class BaseNavigationAware :BaseViewModel,  INavigationAware
    {
        public IDialogCoordinator DialogCoordinator { get; set; }
       
        public IMapper DefaultMapper { get; set; }
        protected BaseNavigationAware(IContainerProvider provider) : base(provider)
        {
            DialogCoordinator = provider.Resolve<IDialogCoordinator>();
            DefaultMapper = provider.Resolve<IMapper>();
        }

        //省去了string.Empty的操作，视图初始化
        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return false;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
           
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            
        }

        /// <summary>
        /// 删除的判定，确认Or取消
        /// </summary>
        /// <returns></returns>
        public async Task<MessageDialogResult> ShowBaseNavigationAwareMessageDialogAsync()
        {
            var settings = new MetroDialogSettings
            {
                AffirmativeButtonText = "确认",
                NegativeButtonText = "取消",
                AnimateHide = true,
                AnimateShow = true,
                ColorScheme = MetroDialogColorScheme.Accented
            };

            var result = await this.DialogCoordinator.ShowMessageAsync(this,"是否删除该用户?","删除用户",MessageDialogStyle.AffirmativeAndNegative, settings);
            return result;
        }


        /// <summary>
        /// 操作完成判定
        /// </summary>
        /// <returns></returns>
        public async Task<MessageDialogResult> CompletedDialogAsync()
        {
            var settings = new MetroDialogSettings
            {
                AffirmativeButtonText = "确认",
                AnimateHide = true,
                AnimateShow = true,
                ColorScheme = MetroDialogColorScheme.Accented
            };

            var result = await this.DialogCoordinator.ShowMessageAsync(this, "提示", "操作完成", MessageDialogStyle.AffirmativeAndNegative, settings);
            return result;
        }

        /// <summary>
        /// 打开可输入Message
        /// </summary>
        /// <returns></returns>
        public async Task<MessageDialogResult> ShowInputDialogAsync()
        {
            var settings = new MetroDialogSettings
            {
                AffirmativeButtonText = "确认",
                NegativeButtonText = "取消",
                ColorScheme = MetroDialogColorScheme.Inverted,
                AnimateHide = true,
                AnimateShow = true
            };

            var result = await this.DialogCoordinator.ShowInputAsync(this, "请输入", "请输入姓名",  settings);

            if (result==null)
            {
               return MessageDialogResult.Negative;
            }
            return MessageDialogResult.Affirmative;
        }

        /// <summary>
        /// 刷新操作3秒延迟后自动关闭
        /// </summary>
        public async void ShowProgressDialogAsync()
        {
            var controller = await DialogCoordinator.ShowProgressAsync(this, "请稍等", "正在进行操作...");
            controller.SetIndeterminate();

            // 执行长时间运行的操作
            await Task.Delay(3000);

            await controller.CloseAsync();
        }

        /// <summary>
        /// 启动模态弹窗阻塞其他进程
        /// </summary>
        public void ShowOutDialogAsync()
        {
            var settings = new MetroDialogSettings
            {
                AffirmativeButtonText = "确认",
                NegativeButtonText = "取消",
                ColorScheme = MetroDialogColorScheme.Inverted,
                AnimateHide = true,
                AnimateShow = true
            };
            var controller =  DialogCoordinator.ShowModalMessageExternal(this, "请稍等", "正在进行操作...",  MessageDialogStyle.Affirmative, settings);
        }
        /// <summary>
        /// 登录MessageBox
        /// </summary>
        public async void ShowLoginDialogAsunc()
        {
            var settings = new LoginDialogSettings
            {
                NegativeButtonVisibility = Visibility.Visible,
                NegativeButtonText = "取消",
                AffirmativeButtonText = "登录"
            };

            var result = await DialogCoordinator.ShowLoginAsync(this, "登录", "请输入用户名和密码", settings);
            if (result == null)
            {
                // 用户取消了登录操作
            }
            else if (!string.IsNullOrEmpty(result.Username) && !string.IsNullOrEmpty(result.Password))
            {
                // 用户输入了用户名和密码，执行登录操作
            }
            else
            {
                // 用户未输入完整的用户名和密码
            }
        }

        /// <summary>
        /// 打开自定义弹窗
        /// </summary>
        public async void ShowCustomDialogAsync()
        {
            var customDialog = new CustomDialog();
            await DialogCoordinator.ShowMetroDialogAsync("",customDialog);

            // 等待用户关闭自定义对话框
            await customDialog.WaitUntilUnloadedAsync();

          /*  if ((bool)result)
            {

                // 用户点击了“确认”按钮
            }
            else
            {
                // 用户点击了“取消”按钮
            }*/
        }
    }
}
