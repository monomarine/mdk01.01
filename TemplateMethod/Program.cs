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
            vipUser.Login = "vipUser228";

            admin.Work("лого", moderator, moderator, "спам");
            Console.WriteLine("-----------------------------------");
            moderator.Work("flower", guest, guest, "флуд");
            Console.WriteLine("-----------------------------------");
            guest.Work("car", admin, admin, "использование читов");
            Console.WriteLine("-----------------------------------");
            vipUser.Work("house", guest, guest, "оскорбление администрации");
        }
    }
}
