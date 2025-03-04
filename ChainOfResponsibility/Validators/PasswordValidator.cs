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
        private readonly char[] _specialSymbols = { '#', '!', '*', '@' };
        private readonly char[] _numbers = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        private string cutPassword;
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
            if (user.Password.IndexOfAny(_specialSymbols) < 0)
            {
                Console.WriteLine("пароль не содержит спец. символов");
                return false;
            };

            cutPassword = user.Password.Replace("#", "")
               .Replace("!", "")
               .Replace("@", "")
               .Replace("*", "");
            if (user.Password.IndexOfAny(_numbers) < 0)
            {
                Console.WriteLine("пароль не содержит цифр");
                return false;
            };

            cutPassword = Regex.Replace(cutPassword, "[0-9]", "");
            if (Regex.IsMatch(cutPassword, "[^a-zA-Z]"))
            {
                Console.WriteLine("пароль содержит не только латинские символы");
                return false;
            };

            return _nextValidator?.Validate(user) ?? true;
        }
    }
}
