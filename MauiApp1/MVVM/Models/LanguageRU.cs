
namespace MauiApp1.MVVM.Models
{
    public class LanguageRU : Language
    {
        public override string Label => "RUS";

        public override string Email => "почта";

        public override string Password => "пароль";

        public override string ForgotPassword => "забыли пароль?";

        public override string NoAccount => "нет учетной записи?";

        public override string SignUp => "регистрация";

        public override string SignIn => "войти";

        public override string Warning => "внимание";

        public override string DoYouReallyWantToLeave => "вы действительно хотите выйти?";

        public override string Yes => "да";

        public override string No => "нет";

        public override string IAgreeWith => "я соглашаюсь с";

        public override string TermsOfUserAgreement => "условиями пользовательского соглашения";

        public override string RepeatPassword => "повтор пароля";

        public override string PasswordsDoNotMatch => "пароли не совпадают";

        public override string Ok => "ок";

        public override string EmailAlreadyBusy => "почта уже занята";

        public override string Name => "имя";

        public override string LastName => "фамилия";

        public override string Gender => "пол";

        public override string Male => "мужской";

        public override string Female => "женский";

        public override string DateOfBirth => "дата рождения";

        public override string City => "город";

        public override string Save => "сохранить";

        public override string Login => "авторизация";

        public override string Main => "главная";

        public override string LogOut => "выйти";

        public override string Profile => "профиль";

        public override string DeleteSelectedImage => "удалить выбранное изображение?";

        public override void Accept(ILanguageVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
