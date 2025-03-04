using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethod
{
    internal class VIPUser : User
    {
        public override void BanUser(User user)
        {
            Console.WriteLine($"не может забанить пользователя {user.Login}");
        }

        public override void PrintInfo()
        {
            Console.WriteLine($"пользователь {Login} - роль \"VIP ПОЛЬЗОВАТЕЛЬ\"");
        }

        public override void SendPicture(string title)
        {
            Console.WriteLine($"VIP пользователь загрузил изображение {title}");
        }

        public override void PrivilegedComplaint(User user)
        {
            Console.WriteLine($"VIP пользователь {Login} отправил привилегированную жалобу на пользователя {user.Login}");
        }
    }
}
