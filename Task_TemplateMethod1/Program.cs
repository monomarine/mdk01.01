namespace Task_TemplateMethod1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var user1 = new User("user123", "password123");
            Console.WriteLine(user1);

            var vipUser = new VIPUser("vip_user", "vip_password");
            Console.WriteLine(vipUser);

            user1.SubmitComplaint(vipUser, "Этот пользователь ведет себя неподобающе!");

            vipUser.SubmitPrivilegedComplaint(user1, "Этот пользователь нарушает правила!");

            Console.WriteLine(user1);
        }
    }
}
