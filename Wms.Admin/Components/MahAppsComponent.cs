using Wms.Admin.Contexts;
using Wms.Admin.IRepositorys;
using Wms.Admin.IServices;
using Wms.Admin.Providers.LoginSign;
using Wms.Admin.Repositorys;
using Wms.Admin.Services;
using MahApps.Metro.Controls.Dialogs;
using Prism.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wms.Admin.Components
{
    public class MahAppsComponent : IContainerComponent
    {
        public void Load(IContainerRegistry registry, ComponentContext context)
        {
            //注册Mahapps.Metro控件的对话框，方面使用
            registry.Register<IDialogCoordinator, DialogCoordinator>();
        }
    }
}
