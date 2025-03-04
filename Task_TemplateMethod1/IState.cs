using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_TemplateMethod1
{
    internal interface IState
    {
        void SendMessage(string message);
    }
}
