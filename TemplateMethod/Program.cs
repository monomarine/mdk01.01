using System;

namespace TemplateMethod
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Admin admin = new Admin { Login = "Admin545" };
            Moderator moderator = new Moderator { Login = "Moderator121" };
            Guest guest = new Guest { Login = "testUser" };
            VIPuser vipUser = new VIPuser { Login = "VIPUser99" };

            admin.Work("лого", moderator);
            Console.WriteLine("-----------------------------------");
            moderator.Work("flower", guest);
            Console.WriteLine("-----------------------------------");
            guest.Work("car", admin);
            Console.WriteLine("-----------------------------------");
            vipUser.Work("exclusiveArt", admin);
        }
    }
}
