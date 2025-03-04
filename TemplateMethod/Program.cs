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
            VipUser vip = new VipUser();

            guest.Login = "testUser";
            moderator.Login = "Moderator121";
            admin.Login = "admin545";
            vip.Login = "VIPKAIF";

            admin.Work("лого", moderator,guest,moderator);
            Console.WriteLine("-----------------------------------");
            moderator.Work("flower" , guest, guest,admin);
            Console.WriteLine("-----------------------------------");
            guest.Work("car", admin, vip,vip);
            Console.WriteLine("-----------------------------------");
            vip.Work("chess",admin, admin,guest);

        }
    }
}
