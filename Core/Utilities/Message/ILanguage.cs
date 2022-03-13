﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Message
{
    public interface ILanguage
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
    }
}
