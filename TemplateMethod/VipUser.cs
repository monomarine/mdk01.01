using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethod
{
    internal class VipUser : User
    {
        public override void BanUser(User user)
        {
            Console.WriteLine(" VIP-пользователь не может звблокировать другого пользователя");
        }
        public override void PrintInfo()
        {
            Console.WriteLine($"пользователь {Login} - \"VIP-пользователь\"");
        }
        public override void SendPicture(string title)
        {
            Console.WriteLine($"пользователь отправил изображение - {title}");
        }
        public override void ReportUser(User user)
        {
            Console.WriteLine($"пользователь подал жалобу на пользователя {user.Login}");
        }
    }
}
