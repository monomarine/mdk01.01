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
        private string[] _domains = { "mail.ru", "yandex.ru", "gmail.com" };

        public void SetNextValidator(IValidator validator)
        {
            _nextValidator = validator;
        }

        public bool Validate(User user)
        {
            if (string.IsNullOrEmpty(user.Email))
            {
                Console.WriteLine("Email не должен быть пустой");
                return false;
            }

            if (!user.Email.Contains("@"))
            {
                Console.WriteLine("Email должен содержать символ '@'");
                return false;
            }

            var mailSplit = user.Email.Split('@');
            if (mailSplit[0].Length < 8)
            {
                Console.WriteLine("Длина почты до '@' должна содержать не менее 8 символов");
                return false;
            }

            if (!_domains.Contains(mailSplit[1]))
            {
                Console.WriteLine("Домен почты должен быть mail.ru, yandex.ru или gmail.com");
                return false;
            }

            return _nextValidator?.Validate(user) ?? true;
        }
    }
}
