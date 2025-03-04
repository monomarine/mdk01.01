using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethod.Tasks
{
    internal class VIP : User
    {
        public override void BanUser(User user)
        {
            Console.WriteLine($"пользователь {user.Login} не может быть заблокирован из-за ограничений вашей роли");
        }

        public override void PrintInfo()
        {
            Console.WriteLine($"пользователь {Login} - роль \"ВИП\"");
        }

        public override void SendPicture(string title)
        {
            Console.WriteLine($"невозможно загрузить изображение из-за ограничений роли {title}");
        }

        public override void SendPostcard(User user)
        {
            Console.WriteLine($"открытка отправлена пользователю {Login} - роль \"ВИП\"");
        }

        public override void SendReport(User user)
        {
            user.ReportCount++;

            if (user.ReportCount == 10)
                BanUser(user);
        }

    }
}
