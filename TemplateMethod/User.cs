using System;

namespace TemplateMethod
{
    internal abstract class User
    {
        private string _login;
        private string _password;

        public string Login
        {
            get => _login;
            set
            {
                if (value.Length < 6)
                    throw new ArgumentException("Длина логина меньше 6 символов");
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
                    throw new ArgumentException("Длина пароля меньше 8 символов");
                else _password = value;
            }
        }

        public abstract void BanUser(User user);
        public abstract void SendPicture(string title);
        public abstract void PrintInfo();

        public virtual void PrivilegedComplaint(User user)
        {
            Console.WriteLine($"{Login} подал привилегированную жалобу на {user.Login}");
        }

        public void Work(string picTitle, User userForBan)
        {
            PrintInfo();
            SendPicture(picTitle);
            BanUser(userForBan);
            PrivilegedComplaint(userForBan);
        }
    }
}
