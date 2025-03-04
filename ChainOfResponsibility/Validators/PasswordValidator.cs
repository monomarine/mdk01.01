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
                Console.WriteLine("пароль не соответствует требуемой длине");
                return false;
            }

            if (!user.Password.Any(c => "#*!@".Contains(c)))
            {
                Console.WriteLine("Пароль должен содержать хотя бы один спецсимвол (#, *, !, @).");
                return false;
            }

            if (!user.Password.Any(c => char.IsLetter(c) && char.IsLetterOrDigit(c)))
            {
                Console.WriteLine("Пароль должен содержать только латинские буквы.");
                return false;
            }

            if (!user.Password.Any(char.IsDigit))
            {
                Console.WriteLine("Пароль должен содержать хотя бы одну цифру.");
                return false;
            }

            return _nextValidator?.Validate(user) ?? true;
        }
    }
}
