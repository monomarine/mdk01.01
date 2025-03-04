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
            if (string.IsNullOrEmpty(user.Password) || user.Password.Length < 8)
            {
                Console.WriteLine("пароль не соответствует требуемой длине");
                return false;
            }

            var onlyLatin = new Regex(@"^[A-Za-z0-9#*!@]+$");
            var hasSpecialChar = new Regex(@"[#*!@]");
            var hasNumber = new Regex(@"[0-9]");
            var hasUpperChar = new Regex(@"[A-Z]");
            var hasLowerChar = new Regex(@"[a-z]");

            if (!onlyLatin.IsMatch(user.Password))
            {
                Console.WriteLine("пароль содержит недопустимые символы");
                return false;
            }

            if (!hasSpecialChar.IsMatch(user.Password))
            {
                Console.WriteLine("пароль должен содержать минимум один из символов #, *, !, @");
                return false;
            }

            if (!hasNumber.IsMatch(user.Password))
            {
                Console.WriteLine("пароль должен содержать минимум одну цифру");
                return false;
            }

            if (!hasUpperChar.IsMatch(user.Password))
            {
                Console.WriteLine("пароль должен содержать минимум одну заглавную латинскую букву");
                return false;
            }

            if (!hasLowerChar.IsMatch(user.Password))
            {
                Console.WriteLine("пароль должен содержать минимум одну строчную латинскую букву");
                return false;
            }

            return _nextValidator?.Validate(user) ?? true;
        }
    }
}
