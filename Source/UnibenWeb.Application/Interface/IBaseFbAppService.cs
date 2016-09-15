using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnibenWeb.Application.Interface
{
    public interface IBaseFbAppService : IDisposable
    {
        List<DbDataRecord> Query(string sql);
    }
}
