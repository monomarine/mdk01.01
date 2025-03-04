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
            vipUser.Login = "VIPUser123";

            admin.Work("лого", moderator);
            Console.WriteLine("-----------------------------------");
            moderator.Work("flower" , guest);
            Console.WriteLine("-----------------------------------");
            guest.Work("car", admin);
            Console.WriteLine("-----------------------------------");
            vipUser.Work("Cat", guest);
        }
    }
}
