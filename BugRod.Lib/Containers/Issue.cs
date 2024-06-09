﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugRod.Lib.Containers
{
    public class Issue
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string State { get; set; }
    }
}
