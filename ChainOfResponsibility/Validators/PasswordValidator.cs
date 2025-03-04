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

            bool hasUpper = false;
            bool hasLower = false;
            bool hasNumber = false;
            bool hasSpecial = false;
            string Specials = "#@!@";

            foreach (char c in user.Password)
            {
                if (char.IsUpper(c))
                    hasUpper = true;
                if (char.IsLower(c))
                    hasLower = true;
                if (char.IsNumber(c))
                    hasNumber = true;
                if (Specials.Contains(c))
                    hasSpecial = true;
            }
            if (!hasUpper)
            {
                Console.WriteLine("Пароль должен содержать символы в верхнем регистре");
                return false;
            }
            if (!hasLower)
            {
                Console.WriteLine("Пароль должен содержать символы в нижнем регистре");
                return false;
            }
            if (!hasNumber)
            {
                Console.WriteLine("Пароль должен содержать числа");
                return false;
            }
            if (!hasSpecial)
            {
                Console.WriteLine("Пароль должен содержать специальые символы (# * ! @)");
                return false;
            }
            return _nextValidator?.Validate(user) ?? true;
        }
    }
}
