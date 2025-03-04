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
        private readonly string[] _allowedDomains = { "mail.ru", "yandex.ru", "gmail.com" };

        public void SetNextValidator(IValidator validator)
        {
            _nextValidator = validator;
        }

        public bool Validate(User user)
        {
            if (String.IsNullOrEmpty(user.Email)) return false;

            int atIndex = user.Email.IndexOf('@');
            if (atIndex == -1 || atIndex < 8) return false;

            string domain = user.Email.Substring(atIndex + 1);
            if (!_allowedDomains.Contains(domain)) return false;

            return _nextValidator?.Validate(user) ?? true;
        }
    }
}
