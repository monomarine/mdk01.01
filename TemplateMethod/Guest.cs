﻿using System;

namespace TemplateMethod
{
    internal class Guest : User
    {
        public override void BanUser(User user)
        {
            Console.WriteLine($"Не может забанить пользователя {user.Login}");
        }

        public override void SendPicture(string title)
        {
            Console.WriteLine("Не может загрузить изображение");
        }

        public override void PrintInfo()
        {
            Console.WriteLine($"Пользователь {Login} - роль \"ГОСТЬ\"");
        }
    }
}
