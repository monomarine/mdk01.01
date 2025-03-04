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

        public void SetNextValidator(IValidator validator)
        {
            _nextValidator = validator;
        }

        public bool Validate(User user)
        {
            if (string.IsNullOrEmpty(user.Password))
            {
                Console.WriteLine("Пароль не должен быть пустой");
                return false;
            }

            if (user.Password.Length < 8)
            {
                Console.WriteLine("Пароль должен содержать не менее 8 символов");
                return false;
            }

            if (!user.Password.Any(c => "#*!@".Contains(c)))
            {
                Console.WriteLine("Пароль должен содержать хотя бы один из символов: # * ! @");
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

            return _nextValidator?.Validate(user) ?? true;
        }
    }
}
