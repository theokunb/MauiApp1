using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.MVVM.Models
{
    public interface ILanguageVisitor
    {
        Language Visit(LanguageRU languageRU);
        Language Visit(LanguageEU languageEU);
    }
}
