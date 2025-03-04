using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ChainOfResponsibility.Validators
{
    internal class PasswordValidator : IValidator
    {
        private IValidator _nextValidator;
        private readonly string specialChars = "#*!@";

        public void SetNextValidator(IValidator validator)
        {
            _nextValidator = validator;
        }

        public bool Validate(User user)
        {
            if (string.IsNullOrEmpty(user.Password) || user.Password.Length < 8)
            {
                Console.WriteLine("Пароль не соответствует требуемой длине (минимум 8 символов)");
                return false;
            }

            if (!user.Password.Any(char.IsUpper))
            {
                Console.WriteLine("Пароль должен содержать хотя бы одну заглавную букву");
                return false;
            }

            if (!user.Password.Any(char.IsLower))
            {
                Console.WriteLine("Пароль должен содержать хотя бы одну строчную букву");
                return false;
            }

            if (!user.Password.Any(char.IsDigit))
            {
                Console.WriteLine("Пароль должен содержать хотя бы одну цифру");
                return false;
            }

            if (!user.Password.Any(c => specialChars.Contains(c)))
            {
                Console.WriteLine("Пароль должен содержать хотя бы один спецсимвол из # * ! @");
                return false;
            }

            if (!Regex.IsMatch(user.Password, "^[a-zA-Z0-9#*!@]+$"))
            {
                Console.WriteLine("Пароль должен содержать только латинские буквы, цифры и спецсимволы # * ! @");
                return false;
            }

            return _nextValidator?.Validate(user) ?? true;
        }
    }
}
