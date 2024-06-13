using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugRod.Lib.Containers
{
    public class Issue
    {
        public Issue(int id, string name, string description, string state)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
            this.State = state;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string State { get; set; }
    }
}
