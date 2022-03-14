using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Message
{
    public interface ILanguageMessage
    {
        string SuccessAdd { get; }
        string SuccessDelete { get;}
        string SuccessUpdate { get;}

        string FailureAdd { get;}
        string FailureUpdate { get;}
        string FailureDelete { get;}

        string SuccessGet { get;}
        string FailureGet { get;}

        string UnAuthorize { get;}

        string UserNotFound { get; }
        string RoleNotFound { get; }

        string SuccessCreateToken { get; }
        string PasswordIsWrong { get; }
        string LoginSuccess { get; }

        string UserAlreadyExists { get; }
        string FailureRegister { get; }
        string SuccessRegister { get; }
    }
}
