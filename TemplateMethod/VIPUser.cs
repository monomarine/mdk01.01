using System;

namespace TemplateMethod
{
    internal class VIPUser : User
    {
        public override void BanUser(User user)
        {
            Console.WriteLine($"VIP пользователь не может забанить {user.Login}");
        }

        public override void PrintInfo()
        {
            Console.WriteLine($"пользователь {Login} - роль \"VIP ПОЛЬЗОВАТЕЛЬ\"");
        }

        public override void SendPicture(string title)
        {
            Console.WriteLine($"VIP пользователь загрузил изображение {title}");
        }

        /// <summary>
        /// Привилегированная жалоба на пользователя
        /// </summary>
        public void MakePriorityComplaint(User user)
        {
            Console.WriteLine($"VIP пользователь {Login} отправил привилегированную жалобу на {user.Login}");
        }
    }
}
