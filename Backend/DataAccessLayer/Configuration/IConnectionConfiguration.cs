using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.Configuration
{
    public interface IConnectionConfiguration
    {
        public string ConnectionString { get; }
    }
}
