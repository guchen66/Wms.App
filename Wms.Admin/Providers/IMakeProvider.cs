using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bogus;
using Bogus.DataSets;
namespace Wms.Admin.Providers
{
    public interface IMakeProvider<TEntity> where TEntity : class
    {
        void Load(IRuleSet<TEntity> ruleSet);
    }
}
