using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace SignalR.DataAccessLayer.Configuration
{
    public class ConnectionConfiguration : IConnectionConfiguration
    {
        private readonly IConfiguration _configuration;

        public ConnectionConfiguration(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string ConnectionString => _configuration.GetConnectionString("DefaultConnection");
    }
}
