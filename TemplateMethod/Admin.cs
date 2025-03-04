using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethod
{
    internal class Admin : User
    {
        public override void BanUser(User user)
        {
            Console.WriteLine($"пользователь {user.Login} был забанен");
        }

        public override void SendPicture(string title)
        {
            Console.WriteLine($"было загружено озображение {title}");
        }

        public override void PrintInfo()
        {
            Console.WriteLine($"пользователь {Login} - роль \"АДМИН\"");
        }
        public override void ReportUser(User user)
        {
            Console.WriteLine($"админ {Login} отправил привелегированную жалобу на пользователя {user.Login}");
        }
    }
}
