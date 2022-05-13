using MauiApp1.Helpers;

namespace MauiApp1.MVVM.Models
{
    internal class Localizator
    {
        private Localizator()
        {
            languages = new List<Language>()
            {
                new LanguageRU(),
                new LanguageEU()
            };

            var lastLanguage = Preferences.Get(Strings.Language, string.Empty);
            if (string.IsNullOrEmpty(lastLanguage))
                SelectedLanguage = languages.First();
            else
                SelectedLanguage = languages.Find(element => element.Label.Equals(lastLanguage));
        }

        private Language selectedLanguage;
        private List<Language> languages;
        private LanguageVisitor visitor;
        private static Localizator instance = new Localizator();


        public static Localizator Instance => instance;
        public IEnumerable<Language> Languages
        {
            get
            {
                foreach (var language in languages)
                {
                    yield return language;
                }
            }
        }
        public Language SelectedLanguage
        {
            get => selectedLanguage;
            set
            {
                selectedLanguage = value;
                visitor = new LanguageVisitor(selectedLanguage);
            }
        }


    }
}
