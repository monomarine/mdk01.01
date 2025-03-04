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
            vip.Login = "VIPUser222";

            admin.Work("лого", moderator, vip);
            Console.WriteLine("-----------------------------------");
            moderator.Work("flower", guest, admin);
            Console.WriteLine("-----------------------------------");
            guest.Work("car", admin, moderator);
            Console.WriteLine("-----------------------------------");
            vip.Work("ghghg", guest, admin);
        }
    }
}
