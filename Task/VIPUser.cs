using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_TemplateMethod
{
    internal class VIPUser : User
    {
        public VIPUser(string login, string password) : base(login, password)
        {
        }

        public void SubmitPrivilegedComplaint(User targetUser, string complaint)
        {
            if (targetUser == null)
            {
                throw new ArgumentNullException(nameof(targetUser), "Целевой пользователь не может быть null");
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"VIP пользователь {Login} подал привилегированную жалобу на пользователя {targetUser.Login}:");
            Console.WriteLine(complaint);
            Console.ForegroundColor = ConsoleColor.White;
            targetUser.ChangeState(new BannedState());
            Console.WriteLine($"Пользователь {targetUser.Login} был заблокирован.");
        }
    }
}