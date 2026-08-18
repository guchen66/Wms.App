using Wms.Core.Common;
using Wms.Data.Models;
using NewLife.Configuration;
using SqlSugar;
using SqlSugar.IOC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wms.Data.Extensions;
using NewLife.Reflection;
using Wms.Admin.Providers;
using System.Data;
using Wms.Data.Models.NotMapped;
namespace Wms.App
{
    public static class AppStartup
    {
        public static void AddSqlSugar()
        {
            SugarIocServices.AddSqlSugar(new IocConfig()
            {
                ConnectionString = GetConnectionData("Mysql"),
                DbType = IocDbType.MySql,
                //IsAutoCloseConnection = true
            });
         
            //  设置全局过滤器
            SugarIocServices.ConfigurationSugar(db => 
            {
                db.GlobalFilter();
                var databaseList = db.DbMaintenance.GetDataBaseList();

                // 判断目标数据库是否存在

                //例1 获取所有表
                /*   var tables = db.DbMaintenance.GetTableInfoList(false);//true 走缓存 false不走缓存
                   foreach (var table in tables)
                   {
                       var s1=table.DbObjectType;
                       var s2=table.Name;
                       var s3 = table.Description;

                       Console.WriteLine(table.Description);//输出表信息
                   }

                   var userColumns= db.DbMaintenance.GetColumnInfosByTableName("UserInfo", false);
                   foreach (var item in userColumns)
                   {
                       var s1 = item.Value;
                       var s2 = item.DbColumnName;
                       var s3 = item.TableName;
                       var s4 = item.DataType;
                       var s5 = item.PropertyType;
                       var s6 = item.SqlParameterDbType;
                       var s7 = item.OracleDataType;
                       var s8 = item.GetType();
                   }*/
            });
            // 获取所有数据库名称
           
            //创建数据库
            if (GeneratorDataProvider.IsAutoTable)
            {
                StaticConfig.CodeFirst_MySqlCollate = "utf8mb4_0900_ai_ci";//较高版本支持
                DbScoped.Sugar.DbMaintenance.CreateDatabase();

                ////创建表
                DbScoped.Sugar.CodeFirst.InitTables(
                    typeof(UserInfo), typeof(RoleInfo),typeof(AsideMenuControl),
                    typeof(WareHouse),typeof(ProductDataConfig),typeof(OrderHeaderItem),
                    typeof(GoodInfo),typeof(WorkStation),typeof(WorkStep),
                     typeof(DeviceInfo), typeof(ProductData),typeof(ProductType),
                     typeof(ProductTypeMapping),
                     typeof(SetConfigInfo),typeof(AlarmInfo)
                );
            }
            //生成种子数据
            if (GeneratorDataProvider.IsAutoTableData)
            {
                // AddSeedData();
            }
        }
        /// <summary>
        /// 使用NewLife读取Json
        /// </summary>
        /// <returns></returns>
        public static string GetConnectionData(string name)
        {
            string result = "";
            var provider = new JsonConfigProvider()
            {
                FileName = "AppConfig.json"
            };
            result = provider.GetSection($"SqlConnection:{name}").Value;
            return result;
        }
    }
}
