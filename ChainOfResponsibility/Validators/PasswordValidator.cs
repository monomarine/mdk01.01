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
            else if(!user.Password.Contains("#") && 
                !user.Password.Contains("*") &&
                !user.Password.Contains("!") &&
                !user.Password.Contains("@"))
            {
                Console.WriteLine("пароль должен содержать спецсимволы");
                return false;
            }
            else if (!user.Password.Any(char.IsLower))
            {
                Console.WriteLine("Пароль должен содержать хотя бы одну строчную букву");
                return false;
            }
            else if (!user.Password.Any(char.IsUpper))
            {
                Console.WriteLine("Пароль должен содержать хотя бы одну заглавную букву");
                return false;
            }
            else if (!user.Password.Any(char.IsDigit))
            {
                Console.WriteLine("Пароль должен содержать хотя бы одну цифру");
                return false;
            }
            return _nextValidator?.Validate(user) ?? true;
        }
    }
}
