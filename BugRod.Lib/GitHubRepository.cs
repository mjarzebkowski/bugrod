using BugRod.Lib.Abstract;
using BugRod.Lib.Containers;
using BugRod.Lib.NetworkConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BugRod.Lib
{
    public class GitHubRepository : Repository
    {
        private IConnectionClient _httpClient;

        public GitHubRepository(string name, string webAddress, RepositoryType repositoryType, string description, string token, IConnectionClient httpClient)
                : base(name, webAddress, repositoryType, description, token)
        {
            _httpClient = httpClient;
            var connector = new GitLabRepositoryConnector(_httpClient);
            this.Issues = connector.GetIssuesAsync(this).Result.ToList<Issue>();

        }

        public override IRepositoryConnector GetConnector()
        {
            if (RepositoryType == RepositoryType.GitHub)
            {
                return new GitLabRepositoryConnector(this._httpClient);
            }
            throw new NotSupportedException($"Repository type {RepositoryType} is not supported");
        }
    }


    public class GitHubRepositoryConnector : IRepositoryConnector
    {
        public Task<bool> AddIssueAsync(Repository repository, string name, string description)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CloseIssueAsync(Repository repository, Issue bug)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExportIssueAsync(Repository sourceRepository, IEnumerable<Issue> bugs)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Issue>> GetIssuesAsync(Repository repository)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ImportIssueAsync(Repository destinationRepository, string fromFilePath)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ModifyIssueAsync(Repository repository, Issue bug)
        {
            throw new NotImplementedException();
        }
    }
}