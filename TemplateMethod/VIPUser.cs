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
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"VIP-пользователь {Login} не имеет права банить других.");
            Console.ResetColor();
        }

        public override void SendPicture(string title)
        {
            Console.WriteLine($"VIP-пользователь загрузил изображение {title}");
        }

        public override void PrintInfo()
        {
            Console.WriteLine($"Пользователь {Login} - роль \"VIP\"");
        }

        public override void Complaint(User user)
        {
            Console.WriteLine($"VIP-пользователь {Login} подал жалобу на пользователя {user.Login}");
        }
    }
}
