namespace TemplateMethod
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Admin admin = new Admin();
            Moderator moderator = new Moderator();
            Guest guest = new Guest();
            VIPUser vip = new VIPUser();

            guest.Login = "testUser";
            moderator.Login = "Moderator121";
            admin.Login = "admin545";
            vip.Login = "vipUser99";

            Console.WriteLine("------- Работа пользователей --------");
            admin.Work("лого", moderator);
            Console.WriteLine("-----------------------------------");
            moderator.Work("flower", guest);
            Console.WriteLine("-----------------------------------");
            guest.Work("car", admin);
            Console.WriteLine("-----------------------------------");
            vip.Work("car", guest);
            Console.WriteLine("===================================");

            Console.WriteLine("\n========== Жалобы ==========");
            vip.Complain(admin);
            guest.Complain(moderator);
        }
    }
}
