namespace TemplateMethod
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Admin admin = new Admin();
            Moderator moderator = new Moderator();  
            Guest guest = new Guest();

            guest.Login = "testUser";
            moderator.Login = "Moderator121";
            admin.Login = "admin545";

            admin.Work("лого", moderator);
            Console.WriteLine("-----------------------------------");
            moderator.Work("flower" , guest);
            Console.WriteLine("-----------------------------------");
            guest.Work("car", admin);
        }
    }
}
