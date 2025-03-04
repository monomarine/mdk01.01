using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern
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
        private IState currentState; // текущее состояние пользователя
        public void SendMessage(string message)=>
            currentState.SendMessage(message);

        public User(string login, string password)
        {
            Login=login;
            Password=password;
            currentState = new ActiveState();
        }

        public void ChangeState(IState state)=> currentState = state;
        #endregion

        public override string ToString()
        {
            return $"пользователь с логином {Login} находится в состоянии {currentState}";
        }
    }
}
