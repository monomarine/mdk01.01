using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_TemplateMethod
{
    internal class BannedState : IState
    {
        public void SendMessage(string message)
        {
            Console.WriteLine("пользователь попытался отправить сообщение");
        }

        public override string ToString()
        {
            return "бан";
        }
    }
}
