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
            Console.WriteLine($"не может забанить пользователя {user.Login}");
        }

        public override void PrintInfo()
        {
            Console.WriteLine($"пользователь {Login} - роль \"МОДЕРАТОР\"");
        }

        public override void SendPicture(string title)
        {
            Console.WriteLine($"пользователь загрузил изображение {title}");
        }

        public override void SendPostcard(User user)
        {
            Console.WriteLine($"открытка не может быть отправлена пользователю {Login} - требуется роль \"ВИП\"");
        }

        public override void SendReport(User user)
        {
            Console.WriteLine($"вы не можете отправлять жалобу из-за ограничения роли");
        }
    }
}
