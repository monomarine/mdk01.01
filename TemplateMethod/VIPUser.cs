using System;

namespace TemplateMethod
{
    internal class VIPUser : User
    {
        public override void BanUser(User user)
        {
            Console.WriteLine($"ВИП пользователь {Login} не может забанить {user.Login}");
        }

        public override void PrintInfo()
        {
            Console.WriteLine($"пользователь {Login} - роль \"ВИП\"");
        }

        public override void SendPicture(string title)
        {
            Console.WriteLine($"ВИП пользователь {Login} загрузил изображение \"{title}\"");
        }
    }
}
