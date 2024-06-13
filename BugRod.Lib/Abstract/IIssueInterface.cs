using BugRod.Lib.Containers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugRod.Lib.Abstract
{
    internal interface IIssueInterface
    { 
    Task AddIssueAsync(string repository, string name, string description);
    Task ModifyIssueAsync(string repository, int issueId, string newName, string newDescription);
    Task CloseIssueAsync(string repository, int issueId);
    Task<IEnumerable<Issue>> ExportIssuesAsync(string repository);
    Task ImportIssuesAsync(string repository, IEnumerable<Issue> issues);
    }
}
