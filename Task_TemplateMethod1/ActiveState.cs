using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_TemplateMethod1
{
    internal class ActiveState : IState
    {
        public void SendMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public override string ToString()
        {
            return "активный режим";
        }
    }
}
