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
        private readonly HashSet<string> _allowedDomains = new HashSet<string> { "mail.ru", "yandex.ru", "gmail.com" };
        public void SetNextValidator(IValidator validator)
        {
            _nextValidator = validator;
        }

        public bool Validate(User user)
        {
            if (String.IsNullOrEmpty(user.Email)) return false;

            if (!user.Email.Contains("@")) return false;

            var parts = user.Email.Split('@');
            if (parts.Length != 2) return false;

            var localPart = parts[0];
            var domain = parts[1];

            if (localPart.Length < 8) return false;

            if (!_allowedDomains.Contains(domain)) return false;

            return _nextValidator?.Validate(user) ?? true;
        }
    }
}
