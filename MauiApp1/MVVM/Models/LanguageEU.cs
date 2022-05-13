
namespace MauiApp1.MVVM.Models
{
    public class LanguageEU : Language
    {
        public override string Label => "EN";

        public override string Email => "email";

        public override string Password => "password";

        public override string ForgotPassword => "forgot password?";

        public override string NoAccount => "no account?";

        public override string SignUp => "sing up";

        public override string SignIn => "sign in";

        public override string Warning => "warning";

        public override string DoYouReallyWantToLeave => "do you really want to leave?";

        public override string Yes => "yes";

        public override string No => "no";

        public override string IAgreeWith => "i agree with";

        public override string TermsOfUserAgreement => "terms of user agreement";

        public override string RepeatPassword => "repeat password";

        public override string PasswordsDoNotMatch => "passwords do not match";

        public override string Ok => "ok";

        public override string EmailAlreadyBusy => "email already busy";

        public override string Name => "name";

        public override string LastName => "lastname";

        public override string Gender => "gender";

        public override string Male => "male";

        public override string Female => "female";

        public override string DateOfBirth => "bday";

        public override string City => "city";

        public override string Save => "save";

        public override string Login => "Log in";

        public override string Main => "main";

        public override string LogOut => "log out";

        public override string Profile => "profile";

        public override Language Accept(ILanguageVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}
