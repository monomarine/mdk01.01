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
        private string PasswordPattern = "(?=.*[A-Z])(?=.*[a-z])(?=.*[#*!@])";

        public void SetNextValidator(IValidator validator)
        {
            _nextValidator = validator;
        }

        public bool Validate(User user)
        {
            if (String.IsNullOrEmpty(user.Password) || user.Password.Length < 8)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("пароль не соответствует требуемой длине");
                Console.ForegroundColor = ConsoleColor.White;
                return false;
            }

            if (!Regex.IsMatch(user.Password, PasswordPattern))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("пароль должен содержать спецсимволы (#*!@), заглавные и строчные латинские буквы, цифры");
                Console.ForegroundColor = ConsoleColor.White;
                return false;
            }

            return _nextValidator?.Validate(user) ?? true;
        }
    }

}