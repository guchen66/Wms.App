using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MiniExcelLibs;
using NewLife.Data;
using SqlSugar;
using SqlSugar.IOC;

namespace Wms.Admin.Providers
{
    public class ExcelProvider
    {

        public static string DownloadExcelFile<T>(IEnumerable<T> dataList,string excelTitle,Dictionary<string, string> columnMap)where T : class, new()
        {
            SugarIocServices.ConfigurationSugar(db =>
            {
                DbTableInfo tableInfo = new DbTableInfo();

                //例1 获取所有表
                var tables = db.DbMaintenance.GetTableInfoList(false);//true 走缓存 false不走缓存
                foreach (var table in tables)
                {
                    var s1 = table.DbObjectType;
                    var s2 = table.Name;
                    var s3 = table.Description;

                    Console.WriteLine(table.Description);//输出表信息
                }

                var userColumns = db.DbMaintenance.GetColumnInfosByTableName("UserInfo", false);
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
                }
            });
            var fileName = $"{DateTime.Now:yyyyMMddHHmmss}-{excelTitle}.xlsx";
            var filePath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory),
                fileName);

          
            return filePath;
        }
    }
}
