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
            if (String.IsNullOrEmpty(user.Password) || user.Password.Length < 8)
            {
                Console.WriteLine("Пароль должен содержать минимум 8 символов.");
                return false;
            }

            if (!Regex.IsMatch(user.Password, @"[A-Z]"))
            {
                Console.WriteLine("Пароль должен содержать хотя бы одну заглавную букву.");
                return false;
            }

            if (!Regex.IsMatch(user.Password, @"[a-z]"))
            {
                Console.WriteLine("Пароль должен содержать хотя бы одну строчную букву.");
                return false;
            }

            if (!Regex.IsMatch(user.Password, @"\d"))
            {
                Console.WriteLine("Пароль должен содержать хотя бы одну цифру.");
                return false;
            }

            if (!Regex.IsMatch(user.Password, @"[#*!@]"))
            {
                Console.WriteLine("Пароль должен содержать хотя бы один спецсимвол (# * ! @).");
                return false;
            }

            return _nextValidator?.Validate(user) ?? true;
        }
    }
}
