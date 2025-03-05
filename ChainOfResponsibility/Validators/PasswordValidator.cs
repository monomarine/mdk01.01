using System;
using System.Text.RegularExpressions;

namespace ChainOfResponsibility.Validators
{
    internal class PasswordValidator : IValidator
    {
        private IValidator _nextValidator;
        private static readonly Regex PasswordRegex = new Regex(
            @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[#*!@])[A-Za-z\d#*!@]+$"
        );

        public void SetNextValidator(IValidator validator)
        {
            _nextValidator = validator;
        }

        public bool Validate(User user)
        {
            if (string.IsNullOrEmpty(user.Password) || user.Password.Length < 8)
            {
                Console.WriteLine("Пароль должен содержать не менее 8 символов.");
                return false;
            }

            if (!PasswordRegex.IsMatch(user.Password))
            {
                Console.WriteLine("Пароль должен содержать латинские буквы в обоих регистрах, цифры и специальные символы (# * ! @).");
                return false;
            }

            return _nextValidator?.Validate(user) ?? true;
        }
    }
}
