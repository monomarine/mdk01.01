namespace TemplateMethod
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Admin admin = new Admin();
            Moderator moderator = new Moderator();
            Guest guest = new Guest();
            VIPUser vipUser = new VIPUser();

            guest.Login = "testUser";
            moderator.Login = "Moderator121";
            admin.Login = "admin545";
            vipUser.Login = "vipUser123";

            admin.Work("лого", moderator, guest);
            Console.WriteLine("-----------------------------------");
            moderator.Work("flower", guest, admin);
            Console.WriteLine("-----------------------------------");
            guest.Work("car", admin, moderator);
            Console.WriteLine("-----------------------------------");
            vipUser.Work("art", guest, admin);
        }
    }
}
