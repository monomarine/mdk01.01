using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethod
{
    internal class VIP: User
    {
        public override void BanUser(User user)
        {
            Console.WriteLine($"не может забанить пользователя {user.Login}");
        }

        public override void PrintInfo()
        {
            Console.WriteLine($"пользователь {Login}, статус - \"VIP\"");
        }

        public override void Complaint(User user)
        {
            Console.WriteLine($"подана жалоба на пользователя: {user.Login}");
        }

        public override void SendPicture(string title)
        {
            Console.WriteLine($"пользователь добавил изображение {title}");
        }
    }
}
