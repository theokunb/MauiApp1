using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.MVVM.Models
{
    internal interface IAuthProvider
    {
        public Task<bool> SingIn(string email, string password);
        public Task<bool> CreateUser(string email, string password);
    }
}
