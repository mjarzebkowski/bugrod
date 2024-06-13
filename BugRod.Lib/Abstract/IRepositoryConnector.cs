using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BugRod.Lib.Containers;

namespace BugRod.Lib.Abstract
{
    public interface IRepositoryConnector
    {
        // General
        //Task<bool> ConnectToService(Repository repository);
        //Task<bool> DisconnectService(Repository repository);

        //Show
        Task<IEnumerable<Issue>> GetIssuesAsync(Repository repository);

        // Manage
        Task<bool> AddIssueAsync(Repository repository, string name, string description);
        Task<bool> ModifyIssueAsync(Repository repository, Issue bug);
        Task<bool> CloseIssueAsync(Repository repository, Issue bug);
        Task<bool> ExportIssueAsync(Repository sourceRepository, IEnumerable<Issue> bugs);
        Task<bool> ImportIssueAsync(Repository destinationRepository, string fromFilePath);
    }


}
