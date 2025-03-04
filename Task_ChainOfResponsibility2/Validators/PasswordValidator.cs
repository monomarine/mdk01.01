using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Task_ChainOfResponsibility.Validators
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
            if (String.IsNullOrEmpty(user.Password) || user.Password.Length < 8)
            {
                Console.WriteLine("Пароль должен быть не менее 8 символов");
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

            if (!user.Password.Any(c => _specialChars.Contains(c)))
            {
                Console.WriteLine("Пароль должен содержать хотя бы один из специальных символов: #, *, !, @");
                return false;
            }

            return _nextValidator?.Validate(user) ?? true;
        }
    }
}