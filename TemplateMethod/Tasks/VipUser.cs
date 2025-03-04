using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethod.Tasks
{
    internal class VipUser : User
    {
        public override void BanUser(User user)
        {
            Console.WriteLine($"не может забанить пользователя {user.Login}"); ;
        }

        public override void PrintInfo()
        {
            Console.WriteLine($"пользователь {Login} - роль \"VIP-Пользователь\"");
        }

        public override void SendPicture(string title)
        {
            Console.WriteLine($"не может загрузить изображение");
        }

        public override void SendKiss(User user)
        {
            Console.WriteLine($"отправлен поцелуй пользователю {user.Login}");
        }

        public override void SendReport(User user)
        {
            user.count++;
            if (user.count == 10)
                user.BanUser(user);
            Console.WriteLine($"отправлен репорт пользователю {user.Login}");
        }
    }
}
