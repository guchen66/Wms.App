using Wms.Admin.Contexts;
using Wms.Admin.Providers.LoginSign;
using Wms.Admin.Services;
using Mapster;
using MapsterMapper;
using MySqlConnector.Logging;
using Prism.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Wms.Admin.Components
{
    public class LocalServerComponent : IContainerComponent
    {
        public void Load(IContainerRegistry registry, ComponentContext context)
        {
            
            registry.Register<ILoginService, LoginService>();
            registry.RegisterSingleton<Wms.Admin.IServices.ILogger, DefaultLogger>();
        }
    }
}
