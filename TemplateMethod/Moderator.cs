using System;

namespace TemplateMethod
{
    internal class Moderator : User
    {
        public override void BanUser(User user)
        {
            Console.WriteLine($"Не может забанить пользователя {user.Login}");
        }

        public override void SendPicture(string title)
        {
            Console.WriteLine($"Пользователь загрузил изображение {title}");
        }

        public override void PrintInfo()
        {
            Console.WriteLine($"Пользователь {Login} - роль \"МОДЕРАТОР\"");
        }
    }
}
