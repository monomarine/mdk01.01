using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethod
{
    internal abstract class User
    { 
        private string _login;
        private string _password;
        public int countReport;

       public string Login
            {
                get => _login;
                set
                {
                    if (value.Length < 6)
                        throw new ArgumentException("длина логина меньше 6 символов");
                    else
                        _login = value;
                }
            }
       public string Password
            {
                get => _password;
                set
                {
                    if (value.Length < 8)
                        throw new ArgumentException("длина пароля меньше 8 символов");
                    else _password = value;
                }
            }

        public abstract void BanUser(User user);
        public abstract void SendPicture(string title);
        public abstract void SendGift(User user);
        public abstract void SendReport(User user);
        public abstract void PrintInfo();
        /// <summary>
        /// шаблонный метод
        /// </summary>
        public void Work(string picTitle, User userForBan, User userForGift, User userReports)
        {
            PrintInfo();
            SendPicture(picTitle);
            BanUser(userForBan);
            SendGift(userForGift);
            Console.WriteLine($"количество репортов у пользователя с ником: {Login} = {userReports.countReport}");
        }
    }
}
