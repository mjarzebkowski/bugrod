using BugRod.Lib.Containers;
using BugRod.Lib.NetworkConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugRod.Lib
{
    public static class RepositoryFactory
    {
        public static Repository CreateRepository(RepositoryType repositoryType, string name, string webAddress, string description, string token, IConnectionClient _connectionClient)
        {

            return repositoryType switch
            {
                RepositoryType.GitHub => new GitHubRepository(name, webAddress, RepositoryType.GitHub, description, token, _connectionClient),
                RepositoryType.GitLab => new GitLabRepository(name, webAddress, RepositoryType.GitLab, description, token, _connectionClient),
                //RepositoryType.Bitbucket => new BitbucketRepository(name, webAddress, RepositoryType.BitBucket, description),
                _ => throw new ArgumentException("Invalid repository type", nameof(repositoryType)),
            };
        }
    }
}
