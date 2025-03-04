namespace TemplateMethod;

internal class VIP : User
{
    public override void BanUser(User user)
    {
        Console.WriteLine($"Пользователь {user.Login} был забанен VIP пользователем {Login}");
    }

    public override void PrintInfo()
    {
        Console.WriteLine($"Пользователь {Login} роль - \"VIP пользователь\"");
    }

    public override void SendPicture(string title)
    {
        Console.WriteLine($"было загружено озображение {title}");
    }
}