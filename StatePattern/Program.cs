namespace StatePattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            User user1 = new User("testUser", "pas545646ss");
            Console.WriteLine(user1);
            user1.SendMessage("Hello!");

            user1.ChangeState(new BannedState());
            user1.SendMessage("Hello!");

            user1.ChangeState(new SuspendedState());
            user1.SendMessage("Hello!");
        }
    }
}
