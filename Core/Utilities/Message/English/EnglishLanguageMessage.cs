namespace Core.Utilities.Message.English
{
    public class EnglishLanguageMessage : ILanguageMessage
    {
        public string SuccessAdd => "Add is successful";

        public string SuccessDelete => "Delete is successful";

        public string SuccessUpdate => "Update is successful";

        public string FailureAdd => "Add is unsuccessful";

        public string FailureUpdate => "Update is unsuccessful";

        public string FailureDelete => "Delete is unsuccessful";

        public string SuccessGet => "Get is successful";

        public string FailureGet => "Not Found";

        public string UnAuthorize => "Authorize Denied";

        public string UserNotFound => "User not found";

        public string RoleNotFound => "Role not found";

        public string SuccessCreateToken => "Token create successful";

        public string PasswordIsWrong => "Password is wrong";
        public string LoginSuccess => "Login is successful";

        public string UserAlreadyExists => "User already exists";
        public string FailureRegister => "Register is unsuccessful";
        public string SuccessRegister => "Register is successful";

        public string SuccessList => "Listing Successful";

        public string FailureList => "Listing Unsuccessful";

        public string FailEmailConfirm => "Please verify your email";

        public string ShouldBeLeastTwoAnswer => "Should be least two answer";

        public string PleaseCheckEnteredAnswers => "Please check entered answers";

        public string ShouldBeTrueAnswer => "Should be true answer";

        public string CannotShouldMoreThanOneTrueAnswer => "Cannot should more than one true answer";
    }
}
