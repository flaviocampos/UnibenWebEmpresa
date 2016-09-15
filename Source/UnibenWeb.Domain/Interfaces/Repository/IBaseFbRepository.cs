using System.Collections.Generic;
using System.Data.Common;
using System.Linq;

namespace UnibenWeb.Domain.Interfaces.Repository
{
    public interface IBaseFbRepository
    {
        List<DbDataRecord> FbQuery(string sql); 
    }
}
