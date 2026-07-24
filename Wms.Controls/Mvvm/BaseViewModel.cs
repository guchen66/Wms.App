using Wms.Core.Common;
using Wms.Core.Globals;
using Prism.Events;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wms.Controls.Mvvm
{
    /// <summary>
    /// 使用继承链
    /// 除了将Prism的公用接口放在中间类之外，一些通用的属性，方法，接口也可以放置
    /// 而公用对象里可以放公用的service
    /// </summary>
    public class BaseViewModel : BindableBase
    {
        public IRegionNavigationJournal NavigationJournal;  //导航日志，上一页，下一页
        public IRegionManager RegionManager;                //区域管理
        public IEventAggregator EventAggregator;            //事件处理
        public IDialogService DialogService { get; set; }   //打开弹窗
        public IContainerProvider Provider { get; set; }    //服务容器
        public AppData appData { get; set; } = AppData.Instance;

        public BaseViewModel(IContainerProvider provider)
        {
            Provider = provider;
            NavigationJournal = Provider.Resolve<IRegionNavigationJournal>();
            RegionManager = Provider.Resolve<IRegionManager>();
            EventAggregator = Provider.Resolve<IEventAggregator>();
            DialogService = Provider.Resolve<IDialogService>();

        }

        /// <summary>
        /// 默认情况下，直接导航
        /// </summary>
        /// <param name="navigatePath"></param>
        /// <param name="completeNavigation"></param>
        protected void NavigationToView(string navigatePath,bool completeNavigation=true)
        {
            if (navigatePath != null)
                RegionManager.RequestNavigate(RegionNames.ContentRegion, navigatePath, arg =>
                {
                    NavigationJournal = arg.Context.NavigationService.Journal;
                });
        }

        private void NavigationComplete(NavigationResult result)
        {
            System.Windows.MessageBox.Show(String.Format("Navigation to {0} complete. ", result.Context.Uri));

            // MessageBox.Ask("内容","标题");
        }
    }
}
