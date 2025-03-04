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
            if (atIndex == -1 || atIndex < 8) return false;

            string domain = user.Email[(atIndex + 1)..]; // Получаем домен после @
            string[] allowedDomains = { "mail.ru", "yandex.ru", "gmail.com" };

            if (!allowedDomains.Contains(domain)) return false;

            return _nextValidator?.Validate(user) ?? true;
        }
    }
}
