using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugRod.Lib.Containers
{
    public class Repository
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string WebAddress { get; set; } // IP or WebName including port
        public AuthenticationType AuthenticationType { get; set; }

    }


}
