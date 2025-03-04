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
            Console.WriteLine($"Не может забанить пользователя {user.Login}");
        }

        public override void PrintInfo()
        {
            Console.WriteLine($"Пользователь {Login} - роль \"МОДЕРАТОР\"");
        }

        public override void SendPicture(string title)
        {
            Console.WriteLine($"Пользователь загрузил изображение {title}");
        }

        public override void ReportUser(User user)
        {
            Console.WriteLine($"Модератор {Login} не может отправить привилегированную жалобу на {user.Login}, так как не является VIP-пользователем");
        }
    }
}
