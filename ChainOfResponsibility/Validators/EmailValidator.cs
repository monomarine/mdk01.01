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

            if (!user.Email.Contains("@"))
            {
                Console.WriteLine("Email должен содержать @");
                return false;
            }

            var parts = user.Email.Split('@');
            if (parts[0].Length < 8)
            {
                Console.WriteLine("Длина имени пользователя в Email должна быть не менее 8 символов");
                return false;
            }

            if (!Array.Exists(allowedDomains, domain => domain == parts[1]))
            {
                Console.WriteLine("Доменное имя должно быть mail.ru, yandex.ru или gmail.com");
                return false;
            }

            return _nextValidator?.Validate(user) ?? true;
        }
    }
}
