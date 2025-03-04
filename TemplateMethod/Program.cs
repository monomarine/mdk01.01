namespace TemplateMethod
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Admin admin = new Admin { Login = "admin545" };
            Moderator moderator = new Moderator { Login = "Moderator121" };
            Guest guest = new Guest { Login = "testUser" };
            VIPUser vipUser = new VIPUser { Login = "VIP123" };

            Console.WriteLine("===== Админ выполняет действия =====");
            admin.Work("лого", moderator, guest);
            Console.WriteLine("-----------------------------------");

            Console.WriteLine("===== Модератор выполняет действия =====");
            moderator.Work("flower", guest, admin);
            Console.WriteLine("-----------------------------------");

            Console.WriteLine("===== Гость выполняет действия =====");
            guest.Work("car", admin, vipUser);
            Console.WriteLine("-----------------------------------");

            Console.WriteLine("===== VIP-пользователь выполняет действия =====");
            vipUser.Work("premium_art", guest, moderator);
            Console.WriteLine("-----------------------------------");
        }
    }
}
