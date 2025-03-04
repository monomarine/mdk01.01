﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethod
{
    internal class Moderator : User
    {
        public override void BanUser(User user)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"не может забанить пользователя {user.Login}");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public override void PrintInfo()
        {
            Console.WriteLine($"пользователь {Login} - роль \"МОДЕРАТОР\"");
        }

        public override void SendPicture(string title)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"пользователь загрузил изображение {title}");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public override void Complain(string message, User user)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"пользователь {Login} не может пожаловаться на {user.Login} по причине \"{message}\"");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
