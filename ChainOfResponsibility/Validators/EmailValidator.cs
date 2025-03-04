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
            string[] emailstr = user.Email.Split("@");
            if (String.IsNullOrEmpty(user.Email))
            {
                Console.WriteLine("email не может быть пустым");
                return false;
            }
            if (!user.Email.Contains('@'))
            {
                Console.WriteLine("email должен содержать символ @");
                return false;
            }
            if (emailstr[0].Length < 8)
            {
                Console.WriteLine("длина до @ меньше 8");
                return false;
            }
            if (!(emailstr[1].Equals("mail.ru") || emailstr[1].Equals("yandex.ru") || emailstr[1].Equals("gmail.com")))
            {
                Console.WriteLine("доменное имя не содержит mail.ru или yandex.ru или gmail.com");
                return false;
            }
            

            return _nextValidator?.Validate(user) ?? true;
        }
    }
}
