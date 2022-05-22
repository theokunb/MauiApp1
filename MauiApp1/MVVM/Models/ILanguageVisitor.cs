﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.MVVM.Models
{
    public interface ILanguageVisitor
    {
        void Visit(LanguageRU languageRU);
        void Visit(LanguageEU languageEU);
    }
}
