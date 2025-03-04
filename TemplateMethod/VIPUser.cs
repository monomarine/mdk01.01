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
            Console.WriteLine($"VIP пользователь не имеет прав на бан других пользователей");
        }

        public override void PrintInfo()
        {
            Console.WriteLine($"Пользователь {Login} - роль \"VIP\"");
        }

        public override void SendPicture(string title)
        {
            Console.WriteLine($"VIP пользователь загрузил изображение {title}");
        }

        public override void SendReport(User user)
        {
            Console.WriteLine($"VIP пользователь отправил привилегированную жалобу на пользователя {user.Login}");
        }
    }

}
