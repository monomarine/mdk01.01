using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_ChainOfResponsibility.Validators
{
        internal interface IValidator
        {
            void SetNextValidator(IValidator validator);
            bool Validate(User user);
        }
}
