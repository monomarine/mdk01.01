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
            vIP.Login = "zxcGhoul7";
            vIP.Password = "qwerty66";

            admin.Work("лого", moderator, guest, admin);
            Console.WriteLine("-----------------------------------");
            vIP.SendReport(guest);
            vIP.SendReport(guest);
            vIP.SendReport(guest);
            admin.Work("лого", moderator, guest, guest);
            Console.WriteLine("-----------------------------------");
            vIP.SendReport(guest);
            vIP.SendReport(guest);
            vIP.SendReport(guest);
            admin.Work("лого", moderator, guest, guest);
            Console.WriteLine("-----------------------------------");


        }
    }
}
