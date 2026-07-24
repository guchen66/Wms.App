using Wms.Controls.Views;
using Wms.Core.Common;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wms.App
{
    [Module(ModuleName = "ShellModule", OnDemand = true)]
    public class ShellModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion(RegionNames.ContentRegion, typeof(HomeView));
            regionManager.RegisterViewWithRegion(RegionNames.HeaderRegion, typeof(HeaderView));
            regionManager.RegisterViewWithRegion(RegionNames.FooterRegion, typeof(FooterView));
        }

      

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }

       
    }
}
