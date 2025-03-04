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
        public void SetNextValidator(IValidator validator)
        {
            _nextValidator = validator;
        }

        public bool Validate(User user)
        {
            if (String.IsNullOrEmpty(user.Password) || user.Password.Length < 8)
            {
                Console.WriteLine("Пароль не соответствует требуемой длине.");
                return false;
            }

            var specialCharacters = new HashSet<char> { '#', '*', '!', '@' };
            var hasSpecialChar = user.Password.Any(c => specialCharacters.Contains(c));
            if (!hasSpecialChar)
            {
                Console.WriteLine("Пароль должен содержать хотя бы один специальный символ: #, *, !, @.");
                return false;
            }

            var hasUpperCase = user.Password.Any(char.IsUpper);
            var hasLowerCase = user.Password.Any(char.IsLower);
            if (!hasUpperCase || !hasLowerCase)
            {
                Console.WriteLine("Пароль должен содержать латинские символы в верхнем и нижнем регистре.");
                return false;
            }

            var hasDigit = user.Password.Any(char.IsDigit);
            if (!hasDigit)
            {
                Console.WriteLine("Пароль должен содержать хотя бы одну цифру.");
                return false;
            }

            return _nextValidator?.Validate(user) ?? true;
        }
    }
}
