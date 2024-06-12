using BugRod.Lib.Containers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugRod.Lib
{
    public static class RepositoryFactory
    {
        public static Repository CreateRepository(RepositoryType repositoryType, string name, string webAddress, string description)
        {
            return repositoryType switch
            {
                RepositoryType.GitHub => new GitHubRepository(name, webAddress, RepositoryType.GitHub, description),
                RepositoryType.GitLab => new GitLabRepository(name, webAddress, RepositoryType.GitLab, description),
                //RepositoryType.Bitbucket => new BitbucketRepository(name, webAddress, description),
                _ => throw new ArgumentException("Invalid repository type", nameof(repositoryType)),
            };
        }
    }
}
