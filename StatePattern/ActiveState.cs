using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern
{
    /// <summary>
    /// активный пользователь - может отправлять сообщения
    /// </summary>
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
