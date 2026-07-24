using MiniExcelLibs;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wms.Admin.Providers
{
    public static class PlcProvider
    {
        public static IPlcConfiguration Configuration => (IPlcConfiguration)CatchOrDefault(() => GetPlc(), new PlcBuilder().Build());


        private static IPlcConfiguration GetPlc()
        {
            throw new NotImplementedException();
        }

        private static T CatchOrDefault<T>(Func<T> action, T defaultValue = null) where T : class
        {
            try
            {
                return action();
            }
            catch
            {
                return defaultValue ?? null;
            }
        }
    }

    public interface IPlcConfiguration
    {
        string this[string key] { get; set; }

        IEnumerable<IPlcConfigurationSection> GetChildren();

        IPlcChangeToken GetReloadToken();
  
        IPlcConfigurationSection GetSection(string key);
    }

    public interface IPlcConfigurationSection : IPlcConfiguration
    {
        string Key { get; }

        string Path { get; }

        string Value { get; }
    }

    public interface IPlcChangeToken
    {
        bool ActiveChangeCallbacks { get; }

        bool HasChanged { get; }

        IDisposable RegisterCallBack(Action<object> callback,object state);
    }

    public class PlcBuilder
    {
        public object Build()
        {
            throw new NotImplementedException();
        }
    }
}
