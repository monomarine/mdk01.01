using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethod
{
    internal class Moderator : User
    {
        public override void BanUser(User user)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"не может забанить пользователя {user.Login}");
            Console.ResetColor();
        }

        public override void PrintInfo()
        {
            Console.WriteLine($"пользователь {Login} - роль \"МОДЕРАТОР\"");
        }

        public override void SendPicture(string title)
        {
            Console.WriteLine($"пользователь загрузил изображение {title}");
        }

        public override void Complaint(User user)
        {
            Console.WriteLine($"Модератор {Login} подал жалобу на пользователя {user.Login}");
        }
    }
}
