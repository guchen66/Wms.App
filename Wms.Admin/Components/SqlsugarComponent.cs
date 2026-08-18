using Wms.Admin.Contexts;
using Wms.Admin.IRepositorys;
using Wms.Admin.IServices;
using Wms.Admin.Providers.LoginSign;
using Wms.Admin.Repositorys;
using Wms.Admin.Services;
using Prism.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wms.Admin.Components
{
    public class SqlsugarComponent : IContainerComponent
    {
        public void Load(IContainerRegistry registry, ComponentContext context)
        {
            registry.RegisterScoped(typeof(IBaseService<>), typeof(BaseService<>));
            registry.RegisterScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            registry.RegisterScoped<IProductDataConfigService,ProductDataConfigService>();
            registry.RegisterScoped<IUserService, UserService>();
            registry.RegisterScoped<IUserRepository, UserRepository>();
        }
    }
}
