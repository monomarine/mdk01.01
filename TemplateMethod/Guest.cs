using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethod
{
    internal class Guest : User
    {
        public override void BanUser(User user)
        {
            Console.WriteLine($"не может забанить пользователя {user.Login}"); ;
        }

        public override void PrintInfo()
        {
            Console.WriteLine($"пользователь {Login} - роль \"ГОСТЬ\"");
        }

        public override void SendPicture(string title)
        {
            Console.WriteLine($"не может загрузить изображение");
        }
        public override void SendReport(User user)
        {
            Console.WriteLine($"Гость отправил привилегированную жалобу на пользователя {user.Login}");
        }
    }
}
