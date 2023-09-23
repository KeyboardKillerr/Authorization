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
        public (string, string, string?, string?) Regin(string? login, string? password, string? confirm)
        {
            if (string.IsNullOrEmpty(login))
            {
                return ("False", "Имя пользователя не введено.", null, null);
            }
            if (string.IsNullOrEmpty(password))
            {
                return ("False", "Пароль не введён.", null, null);
            }
            if (string.IsNullOrEmpty(confirm))
            {
                return ("False", "Пароль подтверждения не введён.", null, null);
            }

            login = login.Trim();
            password = password.Trim();
            confirm = confirm.Trim();

            if (!Filter.CheckLogin(login))
            {
                return ("False", "Имя пользователя введено неправильно.", User.GetHashString(password), User.GetHashString(confirm));
            }
            if (data.dm.User.Items.FirstOrDefault(u => u.Login == login) != default)
            {
                return ("False", "Пользователь с таким именем уже существует.", User.GetHashString(password), User.GetHashString(confirm));
            }
            if (!Filter.CheckPassword(password, confirm))
            {
                return ("False", "Пароль введён неправильно.", User.GetHashString(password), User.GetHashString(confirm));
            }
            User newUser = new User();
            newUser.Login = login.Trim();
            newUser.Password = User.GetHashString(password);
            data.dm.User.UpdateAsync(newUser);
            return ("True", "", User.GetHashString(password), User.GetHashString(confirm));
        }
    }
}
