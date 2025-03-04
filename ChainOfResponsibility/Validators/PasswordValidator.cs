using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility.Validators
{
    internal class PasswordValidator : IValidator
    {
        private IValidator _nextValidator;
        private readonly char[] _specialChars = { '#', '*', '!', '@' };

        public void SetNextValidator(IValidator validator)
        {
            _nextValidator = validator;
        }

        public bool Validate(User user)
        {
            if (String.IsNullOrEmpty(user.Password))
            {
                Console.WriteLine("Пароль не может быть пустым.");
                return false;
            }

            if (user.Password.Length < 8)
            {
                Console.WriteLine("Длина пароля должна быть не менее 8 символов.");
                return false;
            }

            if (!user.Password.Any(c => _specialChars.Contains(c)))
            {
                Console.WriteLine("Пароль должен содержать хотя бы один из специальных символов: #, *, !, @.");
                return false;
            }

            if (!user.Password.All(c => IsLatinLetter(c) || char.IsDigit(c) || _specialChars.Contains(c)))
            {
                Console.WriteLine("Пароль должен содержать только латинские символы, цифры и специальные символы.");
                return false;
            }

            if (!user.Password.Any(char.IsDigit))
            {
                Console.WriteLine("Пароль должен содержать хотя бы одну цифру.");
                return false;
            }

            return _nextValidator?.Validate(user) ?? true;
        }

        private bool IsLatinLetter(char c)
        {
            return (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z');
        }
    }
}
