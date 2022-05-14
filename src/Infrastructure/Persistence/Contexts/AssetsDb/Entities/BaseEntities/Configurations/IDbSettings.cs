using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Contexts.AssetsDb.Entities.BaseEntities.Configurations
{
    public interface IDbSettings
    {
        string ConnectionString { get; set; }

        string DatabaseName { get; set; }
    }
}