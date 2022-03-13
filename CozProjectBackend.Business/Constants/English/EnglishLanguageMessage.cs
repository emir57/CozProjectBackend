using Core.Utilities.Message;
using System;
using System.Collections.Generic;
using System.Text;

namespace CozProjectBackend.Business.Constants.English
{
    public class EnglishLanguageMessage : ILanguage
    {
        public string SuccessAdd => "Add is successful";

        public string SuccessDelete => "Delete is successful";

        public string SuccessUpdate => "Update is successful";

        public string FailureAdd => "Add is unsuccessful";

        public string FailureUpdate => "Update is unsuccessful";

        public string FailureDelete => "Delete is unsuccessful";

        public string SuccessGet => "Get is successful";

        public string FailureGet => "Get is unsuccessful";

        public string UnAuthorize => "Authorize Denied";

        public string UserNotFound => "User not found";

        public string RoleNotFound => "Role not found";

        public string SuccessCreateToken => "Token create successful";
    }
}
