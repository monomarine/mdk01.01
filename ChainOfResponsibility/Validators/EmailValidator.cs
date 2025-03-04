using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility.Validators
{
    internal class EmailValidator : IValidator
    {
        private IValidator _nextValidator;
        public void SetNextValidator(IValidator validator)
        {
            _nextValidator = validator;
        }

        public bool Validate(User user)
        {
            if (String.IsNullOrEmpty(user.Email)) return false;

            
            int atIndex = user.Email.IndexOf('@');

            if (atIndex == -1) {
                Console.WriteLine("не содержит @");
                return false;
            } 
            if (atIndex < 8)
            {
                Console.WriteLine("длина символов до @ - не менее 8");
            } 
            string domain = user.Email.Substring(atIndex + 1);
            if (domain != "mail.ru" && domain != "yandex.ru" && domain != "gmail.com")
            {
                Console.WriteLine("не содкржит нужного домена");
                
            }
            return _nextValidator?.Validate(user) ?? true;
        }
    }
}
