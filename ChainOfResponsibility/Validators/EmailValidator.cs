using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility.Validators
{
    internal class EmailValidator : IValidator
    {
        private IValidator _nextValidator;
        public void SetNextValidator(IValidator validator)
        {
            _nextValidator = validator;
        }

        public bool Validate(User user)
        {
            if (String.IsNullOrEmpty(user.Email))
            {
                Console.WriteLine("email не должен быть пустым");
                return false;
            }
            if (user.Email.Contains("@"))
            {
                string[] split = user.Email.Split("@");
                if (split[0].Length < 8 )
                {
                    Console.WriteLine("количесвто символов до @ должно быть не меньше 8");
                    return false;
                }
                else
                {
                    if (split[1] != "mail.ru")
                    {
                        Console.WriteLine("доменное имя не является \"mail.ru\"");
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }
            return _nextValidator?.Validate(user) ?? true;
        }
    }
}
