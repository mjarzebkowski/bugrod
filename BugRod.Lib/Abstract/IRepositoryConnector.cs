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
        Task<OperationStatus> ConnectToService(Repository repository);
        Task<OperationStatus> DisconnectService(Repository repository);

        //Show
        Task<IEnumerable<Issue>> GetIssues();

        // Manage
        Task<OperationStatus> AddIssue(Repository repository, Issue bug);
        Task<OperationStatus> ModifyIssue(Repository repository, Issue bug);
        Task<OperationStatus> CloseIssue(Repository repository, Issue bug);
        Task<IEnumerable<OperationStatus>> ExportIssue(Repository sourceRepository, IEnumerable<Issue> bugs);
        Task<IEnumerable<OperationStatus>> ImportIssue(Repository destinationRepository, string fromFilePath);
    }


}
