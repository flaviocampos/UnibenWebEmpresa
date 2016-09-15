using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnibenWeb.Domain.Interfaces.Services
{
    public interface IBaseFbService : IDisposable
    {
        List<DbDataRecord> Query(string sql);
    }
}
