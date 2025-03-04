using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility.Validators
{
    internal class LoginValidator : IValidator
    {
        private IValidator _nextValidator;
        public void SetNextValidator(IValidator validator)
        {
            _nextValidator = validator;
        }

        public bool Validate(User user)
        {
            if(String.IsNullOrEmpty(user.Login) || user.Login.Length < 6) 
            {
                Console.WriteLine("логин не удовлетворяет требованиям");
                return false;   
            }

            return _nextValidator?.Validate(user) ?? true;
        }
    }
}
