using System;
using System.Text.RegularExpressions;

namespace ChainOfResponsibility.Validators
{
    internal class EmailValidator : IValidator
    {
        private IValidator _nextValidator;
        private static readonly string[] AllowedDomains = { "mail.ru", "yandex.ru", "gmail.com" };

        public void SetNextValidator(IValidator validator)
        {
            _nextValidator = validator;
        }

        public bool Validate(User user)
        {
            if (string.IsNullOrEmpty(user.Email)) return false;

            int atIndex = user.Email.IndexOf("@");
            if (atIndex == -1 || atIndex < 8) return false;

            string domain = user.Email.Substring(atIndex + 1);
            if (Array.IndexOf(AllowedDomains, domain) == -1) return false;

            return _nextValidator?.Validate(user) ?? true;
        }
    }
}

