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
            if(!user.Email.Contains("@")) return false;

            var emailParts = user.Email.Split('@');
            if (emailParts[0].Length < 8) return false;

            string[] validDomains = { "mail.ru", "yandex.ru", "gmail.com" };
            string domain = emailParts.Length > 1 ? emailParts[1] : "";
            if (!validDomains.Contains(domain)) return false;

            return _nextValidator?.Validate(user) ?? true;
        }
    }
}
