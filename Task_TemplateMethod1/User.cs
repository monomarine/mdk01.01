using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_TemplateMethod1;

namespace Task_TemplateMethod1
{
    internal class User
    {
#pragma warning disable
        private string _login;
        private string _password;

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

        #region StatePattern
        private IState currentState;
        public void SendMessage(string message) =>
            currentState.SendMessage(message);

        public User(string login, string password)
        {
            Login = login;
            Password = password;
            currentState = new ActiveState();
        }

        public void ChangeState(IState state) => currentState = state;
        #endregion

        public override string ToString()
        {
            return $"пользователь с логином {Login} находится в состоянии {currentState}";
        }

        public void SubmitComplaint(User targetUser, string complaint)
        {
            if (targetUser == null)
            {
                throw new ArgumentNullException(nameof(targetUser), "Целевой пользователь не может быть null");
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Пользователь {Login} подал жалобу на пользователя {targetUser.Login}:");
            Console.WriteLine(complaint);
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine($"Жалоба на пользователя {targetUser.Login} была отправлена администратору.");
        }
    }
}
