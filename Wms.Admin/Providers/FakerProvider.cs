using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Bogus;
using Wms.Admin.Components;
using Wms.Admin.Contexts;
using Wms.Data.Models;
using Wms.Data.Models.NotMapped;
using SqlSugar;

namespace Wms.Admin.Providers
{
    public class Demo
    {
        public void GetInfo()
        {
            FakeIocService.AddFaker(fake =>
            {
                fake.Name = "Test";
              
            });
        }
    }
    public static class FakeExtension
    {
        public static Action<FakeDataGenerator> FakeConfig { get; internal set; }

      /*  public static void ConfigurationFake(this IFakeDataGenerator fake, Action<FakeDataGenerator> action)
        {
            FakeConfig = action;
        }*/
    }
    public class FakeIocService
    {
        public static void AddFaker(Action<FakeDataGenerator> action)
        {
            FakeExtension.FakeConfig = action;
        }
    }
    public interface IFakeDataGenerator
    {
       // public string Name { get; }
        void GetName();
    }
    public class FakeDataGenerator: IFakeDataGenerator
    {
        private readonly SqlSugarClient _db;
        private readonly Faker _faker;

        public string Name { get; set; }

        public void GetName()
        {
            Console.WriteLine("Name");
        }
        //public IEnumerable<ProductDataConfig> GetProducts()
        //{
        //    Randomizer.Seed = new Random(123456);
        //    var products = new Faker<ProductDataConfig>();

        //    products.RuleFor(GetCode(new ProductDataConfig()), (f, c) => f.Name.FullName());
        //    products.RuleFor(x => x.Name, (f, c) => f.Name.FullName());
        //    Batch CreateTime
        //}

        //private Expression<Func<ProductDataConfig, Expression<Func<ProductDataConfig>>>> GetCode(ProductDataConfig config)
        //{
        //    throw new NotImplementedException();
        //}

        /* private Expression<Func<ProductDataConfig, Expression<Func<ProductDataConfig>>>> GetCode(ProductDataConfig config)
         {
             throw new NotImplementedException();
         }*/

        public FakeDataGenerator(SqlSugarClient db)
        {
            _db = db;
            _faker = new Faker("zh_CN");
            
        }
        private IEnumerable<Dictionary<string, object>> RewriteTitle<TEntity>(List<TEntity> Models)
        {
            var dict = new Dictionary<string, object>();
            foreach (var model in Models) 
            {
               yield return dict;
            }
        }
    }
}
