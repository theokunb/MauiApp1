namespace MauiApp1.MVVM.Models
{
    public abstract class Language
    {
        public abstract string Label { get; }
        public abstract string Email { get; }
        public abstract string Password { get; }
        public abstract string RepeatPassword { get; }
        public abstract string NoAccount { get; }
        public abstract string SignUp { get; }
        public abstract string ForgotPassword { get; }
        public abstract string SignIn { get; }
        public abstract string Warning { get; }
        public abstract string DoYouReallyWantToLeave { get; }
        public abstract string Yes { get; }
        public abstract string No { get; }
        public abstract string IAgreeWith { get; }
        public abstract string TermsOfUserAgreement { get; }
        public abstract string PasswordsDoNotMatch { get; }
        public abstract string Ok { get; }
        public abstract string EmailAlreadyBusy { get; }
        public abstract string Name { get; }
        public abstract string LastName { get; }
        public abstract string Gender { get; }
        public abstract string Male { get; }
        public abstract string Female { get; }
        public abstract string DateOfBirth { get; }
        public abstract string City { get; }
        public abstract string Save { get; }
        public abstract string Login { get; }
        public abstract string Main { get; }
        public abstract string LogOut { get; }
        public abstract string Profile { get; }
        public abstract string DeleteSelectedImage { get; }

        public abstract void Accept(ILanguageVisitor visitor);
    }
}
