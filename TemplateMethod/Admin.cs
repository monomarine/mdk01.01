using System;

namespace TemplateMethod
{
    internal class Admin : User
    {
        public override void BanUser(User user)
        {
            Console.WriteLine($"Пользователь {user.Login} был забанен");
        }

        public override void SendPicture(string title)
        {
            Console.WriteLine($"Было загружено изображение {title}");
        }

        public override void PrintInfo()
        {
            Console.WriteLine($"Пользователь {Login} - роль \"АДМИН\"");
        }
    }
}
