using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugRod.Lib.Containers
{
    internal class Repository
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string WebAddress { get; set; } // IP or WebName including port


    }

    enum AuthenticationType : byte
    {
        Token           = 1,
        LoginPassword   = 2,
    }
}
