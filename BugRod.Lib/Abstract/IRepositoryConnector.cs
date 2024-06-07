using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BugRod.Lib.Containers;

namespace BugRod.Lib.Abstract
{
    internal interface IRepositoryConnector
    {
        // General
        Task<OperationStatus> ConnectToService(Repository repository);
        Task<OperationStatus> DisconnectService(Repository repository);

        // Manage
        Task<OperationStatus> AddIssue(Repository repository, Issue bug);
        Task<OperationStatus> ModifyIssue(Repository repository, Issue bug);
        Task<OperationStatus> CloseIssue(Repository repository, Issue bug);
        Task<IEnumerable<OperationStatus>> ExportIssue(Repository sourceRepository, IEnumerable<Issue> bugs);
        Task<IEnumerable<OperationStatus>> ImportIssue(Repository destinationRepository, File fromFile);
    }

    enum OperationStatus : byte
    {
        Success = 1,
        Fail    = 2
    }
}
