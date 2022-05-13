using MauiApp1.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.MVVM.Models
{
    internal class LanguageVisitor : ILanguageVisitor
    {
        public LanguageVisitor(Language language)
        {
            language.Accept(this);
        }

        public Language Visit(LanguageRU languageRU)
        {
            Preferences.Set(Strings.Language, languageRU.Label);
            return languageRU;
        }

        public Language Visit(LanguageEU languageEU)
        {
            Preferences.Set(Strings.Language, languageEU.Label);
            return languageEU;
        }
    }
}
