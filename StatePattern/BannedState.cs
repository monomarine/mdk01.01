using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern
{/// <summary>
/// состояние бана - пользователь не отправляет сообщение но есть уведомление
/// о попытке
/// </summary>
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
