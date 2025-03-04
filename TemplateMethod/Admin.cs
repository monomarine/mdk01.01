using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethod
{
    internal class Admin : User
    {
        public override void BanUser(User user)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"пользователь {user.Login} был забанен");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public override void SendPicture(string title)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"было загружено изображение {title}");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public override void PrintInfo()
        {
            Console.WriteLine($"пользователь {Login} - роль \"АДМИН\"");
        }

        public override void Complain(string message, User user)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"пользователь {Login} не может пожаловаться на {user.Login} по причине \"{message}\"");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}