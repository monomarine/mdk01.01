using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethod
{
    internal class Guest : User
    {
        public override void BanUser(User user)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"не может забанить пользователя {user.Login}"); 
            Console.ResetColor();
        }

        public override void PrintInfo()
        {
            Console.WriteLine($"пользователь {Login} - роль \"ГОСТЬ\"");
        }

        public override void SendPicture(string title)
        {
            Console.WriteLine($"не может загрузить изображение");
        }

        public override void Complaint(User user)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Гость не может подавать жалобы.");
            Console.ResetColor();
        }
    }
}
