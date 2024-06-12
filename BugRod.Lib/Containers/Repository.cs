﻿using BugRod.Lib.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugRod.Lib.Containers
{
    public abstract class Repository
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public string WebAddress { get; set; } // IP or WebName including port
        public RepositoryType RepositoryType { get; set; }
        public List<Issue> Issues { get; private set; } = new List<Issue>();

        public Repository(string name, string webAddress, RepositoryType repositoryType, string Description)
        {
            this.Name = name;
            this.WebAddress = webAddress;
            this.RepositoryType = repositoryType;
            this.Description = Description;
        }

        public abstract IRepositoryConnector GetConnector();
        }
}
