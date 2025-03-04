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
        private List<string> _domains = new List<string> { "mail.ru", "yandex.ru", "gmail.com" };

        public void SetNextValidator(IValidator validator)
        {
            _nextValidator = validator;
        }

        public bool Validate(User user)
        {
            if (string.IsNullOrEmpty(user.Email))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("email не может быть пустым");
                Console.ForegroundColor = ConsoleColor.White;
                return false;
            }

            if (!user.Email.Contains("@"))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("email должен содержать @");
                Console.ForegroundColor = ConsoleColor.White;
                return false;
            }

            string[] parts = user.Email.Split('@');

            string localPart = parts[0];
            string domain = parts[1];

            if (localPart.Length < 8)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("локальная часть email должна быть не менее 8 символов");
                Console.ForegroundColor = ConsoleColor.White;
                return false;
            }

            if (!_domains.Contains(domain))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"домен {domain} не разрешен");
                Console.ForegroundColor = ConsoleColor.White;
                return false;
            }

            return _nextValidator?.Validate(user) ?? true;
        }
    }
}
