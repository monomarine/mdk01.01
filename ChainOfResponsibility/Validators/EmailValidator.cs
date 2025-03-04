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
        private string[] _domains = { "mail.ru", "yandex.ru", "gmail.com " };
        public void SetNextValidator(IValidator validator)
        {
            _nextValidator = validator;
        }

        public bool Validate(User user)
        {
            if (String.IsNullOrEmpty(user.Email)) return false;
            if (!user.Email.Contains("@")) return false;

            return _nextValidator?.Validate(user) ?? true;
            var parts = user.Email.Split('@');
            if (parts[0].Length < 8)
            {
                Console.WriteLine("Email должен содержать \"mail.ru\", \"yandex.ru\", \"gmail.com \"");
                return false;
            }
            return _nextValidator?.Validate(user) ?? true;
        }
    }
}
