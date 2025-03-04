using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace ChainOfResponsibility.Validators
{
    internal class EmailValidator : IValidator
    {
        private IValidator _nextValidator;
        private readonly string[] allowedDomains = { "mail.ru", "yandex.ru", "gmail.com" };

        public void SetNextValidator(IValidator validator)
        {
            _nextValidator = validator;
        }

        public bool Validate(User user)
        {
            if (string.IsNullOrEmpty(user.Email))
            {
                Console.WriteLine("Email не может быть пустым");
                return false;
            }

            int atIndex = user.Email.IndexOf('@');
            if (atIndex < 8)
            {
                Console.WriteLine("Часть email до @ должна содержать минимум 8 символов");
                return false;
            }

            string domain = user.Email.Substring(atIndex + 1);
            if (!allowedDomains.Contains(domain))
            {
                Console.WriteLine("Неверный домен email");
                return false;
            }

            return _nextValidator?.Validate(user) ?? true;
        }
    }

    
}
