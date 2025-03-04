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
            if (String.IsNullOrEmpty(user.Email))
            {
                Console.WriteLine("Email не может быть пустым.");
                return false;
            }

            if (!user.Email.Contains("@"))
            {
                Console.WriteLine("Email должен содержать символ '@'.");
                return false;
            }

            var atIndex = user.Email.IndexOf('@');
            var localPart = user.Email.Substring(0, atIndex);
            var domain = user.Email.Substring(atIndex + 1);

            if (localPart.Length < 8)
            {
                Console.WriteLine("Длина символов до '@' должна быть не менее 8.");
                return false;
            }

            if (!_allowedDomains.Contains(domain))
            {
                Console.WriteLine("Доменное имя должно быть одним из: mail.ru, yandex.ru, gmail.com.");
                return false;
            }

            return _nextValidator?.Validate(user) ?? true;
        }
    }
}
