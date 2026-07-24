using Wms.Admin.Contexts;
using MahApps.Metro.Controls.Dialogs;
using Mapster;
using MapsterMapper;
using NewLife.Configuration;
using Prism.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Wms.Admin.Components
{
    public class MapsterComponent : IContainerComponent
    {
        public void Load(IContainerRegistry registry, ComponentContext context)
        {
            var config = new TypeAdapterConfig();
            var assembly = Assembly.Load("Wms.Admin");
            config.Scan(assembly);

            // 注册单例实例
            registry.RegisterInstance(typeof(TypeAdapterConfig), config);

            // 创建并注册 Mapper 实例
            var mapper = new Mapper(config);
            registry.RegisterInstance(typeof(Mapper), mapper);
            registry.Register<IMapper, Mapper>();
        }
    }

    public class MapsterIocService
    {
        public static void RegisterMapster(Action<Mapper> mapper)
        {
            MapsterExtension.Mapper = mapper;
        }
    }

    public static class MapsterExtension
    {
        public static Action<Mapper> Mapper { get; set; }
    }
}