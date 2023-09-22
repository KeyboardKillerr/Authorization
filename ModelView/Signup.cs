using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RequisitesFilter;
using System.Linq;
using DataModel.Entities;
using Azure.Core;

namespace ModelView
{
    public class Signup
    {
        private Data data { get; init; }
        public Signup()
        {
            data = Data.Get();
        }
        public (string, string) Regin(string? login, string? password, string? confirm)
        {
            if (!Filter.CheckLogin(login))
            {
                return ("False", "Имя пользователя введено неправильно.");
            }
            if (data.dm.User.Items.FirstOrDefault(u => u.Login == login) != default)
            {
                return ("False", "Пользователь с таким именем уже существует."); ;
            }
            if (!Filter.CheckPassword(password, confirm))
            {
                return ("False", "Пароль введён неправильно.");
            }
            User newUser = new User();
            newUser.Login = login.Trim();
            newUser.Password = User.GetHashString(password.Trim());
            data.dm.User.UpdateAsync(newUser);
            return ("True", "");
        }
    }
}
