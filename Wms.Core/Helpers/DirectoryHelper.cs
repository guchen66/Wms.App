using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Wms.Core.Helpers
{
    /// <summary>
    /// 目录文件帮助类
    /// </summary>
    public static class DirectoryHelper
    {
        /// <summary>
        /// 获取根目录
        /// </summary>
        /// <returns></returns>
        public static string SelectRootDirectory()
        {
            string rootDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory);
            return rootDirectory;
        }

        /// <summary>
        /// 通过名称获取目录
        /// </summary>
        /// <returns></returns>
        public static string SelectDirectoryByName(string resourceName)
        {
            var folder = Directory.GetCurrentDirectory(); // 获取应用程序当前工作目录
           
            var path = Path.Combine(folder, resourceName); // 使用 Path.Combine 组合路径
            return path;
        }

        /// <summary>
        /// 获取指定类库，指定某个文件夹下，并且应用了某个特性的所有类
        /// </summary>
        public static Type[] GetClassSelf(string lib, string folder, Type inter = null)
        {
            if (string.IsNullOrEmpty(folder))
            {
                throw new ArgumentException("文件夹不存在", nameof(folder));
            }

            try
            {
                var classTypes = GetTypesInfoByLinq(lib, folder, inter);

                return classTypes.ToArray();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"获取类失败：{ex.Message}");
                return new Type[0]; // 返回空数组或者抛出异常，根据实际需求进行处理
            }
        }

        static IEnumerable<Type> GetTypesInfoByLinq(string lib, string folder, Type inter)
        {
            // 加载指定的程序集
            Assembly callingAssembly = Assembly.Load(lib);
            // 获取程序集中所有的类型
            Type[] allTypes = callingAssembly.GetTypes();
            // 筛选出位于指定文件夹下，并且应用了指定特性的所有类
            IEnumerable<Type> modelTypes = allTypes
                .Where(type => type.Namespace?.Contains(folder) == true && (inter == null || Attribute.IsDefined(type, inter)));

            return modelTypes;
        }
    }
}
