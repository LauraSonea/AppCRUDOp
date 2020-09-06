using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCRUDOp
{
    public interface IMongoDbSettings
    {
        string DatabaseName { get; set; }
        string ConnectionString { get; set; }
    }
}
