using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugRod.Lib.Containers
{
    public enum OperationStatus : byte
    {
        Success = 1,
        Fail = 2
    }

    public enum AuthenticationType : byte
    {
        Token = 1,
        LoginPassword = 2,
    }

    public enum RepositoryType
    {
        GitLab = 1,
        GitHub = 2,
        //Bitbucket = 3,
        // ...etc
    }
}
