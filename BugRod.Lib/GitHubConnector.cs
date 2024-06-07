using BugRod.Lib.Abstract;
using BugRod.Lib.Containers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugRod.Lib
{
    internal class GitHubConnector : IRepositoryConnector
    {
        public Task<OperationStatus> AddIssue(Repository repository, Issue bug)
        {
            throw new NotImplementedException();
        }

        public Task<OperationStatus> CloseIssue(Repository repository, Issue bug)
        {
            throw new NotImplementedException();
        }

        public Task<OperationStatus> ConnectToService(Repository repository)
        {
            throw new NotImplementedException();
        }

        public Task<OperationStatus> DisconnectService(Repository repository)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<OperationStatus>> ExportIssue(Repository sourceRepository, IEnumerable<Issue> bugs)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Issue>> GetIssues()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<OperationStatus>> ImportIssue(Repository destinationRepository, string fromFilePath)
        {
            throw new NotImplementedException();
        }

        public Task<OperationStatus> ModifyIssue(Repository repository, Issue bug)
        {
            throw new NotImplementedException();
        }
    }
}
