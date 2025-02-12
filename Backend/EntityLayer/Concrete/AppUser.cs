using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace SignalR.EntityLayer.Concrete
{
    public class AppUser : IdentityUser<int>
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }
}
