using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethod
{
    internal class VIP : User
    {
        public override void BanUser(User user)
        {
            Console.WriteLine($"не может забанить пользователя {user.Login}"); ;
        }

        public override void SendPicture(string title)
        {
            Console.WriteLine($"не может загрузить изображение");
        }

        public override void SendGift(User user)
        {
            Console.WriteLine($"Вы отправили подарок пользователю: {Login}");
        }

        public override void PrintInfo()
        {
            Console.WriteLine($"пользователь {Login} - роль \"ВИП\"");
        }

        public override void SendReport(User user)
        {
            Console.WriteLine($"был отправлен репорт на пользователя с ником: {Login}");
           
            user.countReport++;

            if (user.countReport > 5) 
            {
            BanUser(user);
            }
        }
    }
}
