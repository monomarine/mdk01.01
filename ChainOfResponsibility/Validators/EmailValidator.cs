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
            if (atIndex == -1)
            {
                Console.WriteLine("Email должен содержать символ '@'.");
                return false;
            }

            if (atIndex <= 8)
            {
                Console.WriteLine("Длина символов до '@' должна быть не менее 8.");
                return false;
            }

            string domain = user.Email.Substring(atIndex + 1);
            if (domain != "mail.ru" && domain != "yandex.ru" && domain != "gmail.com")
            {
                Console.WriteLine("Доменное имя должно быть одним из: mail.ru, yandex.ru, gmail.com.");
                return false;
            }
            return _nextValidator?.Validate(user) ?? true;
        }
    }
}
