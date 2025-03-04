using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility.Validators
{
    internal class PasswordValidator : IValidator
    {
        private IValidator _nextValidator;
        private readonly List<char> _specialChars = new List<char> { '#', '*', '!', '@' };

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

            if (!user.Password.Any(c => _specialChars.Contains(c)))
            {
                Console.WriteLine("Пароль должен содержать хотя бы один специальный символ: #, *, !, @.");
                return false;
            }

            if (!user.Password.Any(char.IsUpper) || !user.Password.Any(char.IsLower))
            {
                Console.WriteLine("Пароль должен содержать латинские символы в верхнем и нижнем регистре.");
                return false;
            }

            if (!user.Password.Any(char.IsDigit))
            {
                Console.WriteLine("Пароль должен содержать числа.");
                return false;
            }

            return _nextValidator?.Validate(user) ?? true;
        }
    }
}