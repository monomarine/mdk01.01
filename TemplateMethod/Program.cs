namespace TemplateMethod
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Admin admin = new Admin();
            Moderator moderator = new Moderator();  
            Guest guest = new Guest();
            VIP vip = new VIP();

            guest.Login = "testUser";
            moderator.Login = "Moderator121";
            admin.Login = "admin545";
            vip.Login = "vip123";

            admin.Work("лого", moderator, vip);
            Console.WriteLine("-----------------------------------");
            moderator.Work("flower" , guest, vip);
            Console.WriteLine("-----------------------------------");
            guest.Work("car", admin, vip);
            Console.WriteLine("-----------------------------------");
            vip.Work("picture", guest, moderator);
        }
    }
}
