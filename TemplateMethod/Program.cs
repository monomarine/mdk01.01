using TemplateMethod.Tasks;

namespace TemplateMethod
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Admin admin = new Admin();
            Moderator moderator = new Moderator();  
            Guest guest = new Guest();
            VIP vIP = new VIP();

            guest.Login = "testUser";
            moderator.Login = "Moderator121";
            admin.Login = "admin545";
            vIP.Login = "vip77777";

            admin.Work("лого", moderator, guest);
            Console.WriteLine("-----------------------------------");
            moderator.Work("flower" , guest, vIP);
            Console.WriteLine("-----------------------------------");
            guest.Work("car", admin, admin);
            Console.WriteLine("-----------------------------------");
            vIP.Work("cat", admin, vIP);
            vIP.SendReport(guest);
        }
    }
}
