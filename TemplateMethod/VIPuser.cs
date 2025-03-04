using System;

namespace TemplateMethod
{
    internal class VIPuser : User
    {
        public override void BanUser(User user)
        {
            Console.WriteLine($"Не может забанить пользователя {user.Login}");
        }

        public override void SendPicture(string title)
        {
            Console.WriteLine($"VIP-пользователь загрузил изображение {title}");
        }

        public override void PrintInfo()
        {
            Console.WriteLine($"Пользователь {Login} - роль \"VIP\"");
        }
    }
}
