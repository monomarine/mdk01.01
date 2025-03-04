using ChainOfResponsibility.Validators;

namespace ChainOfResponsibility
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EmailValidator emailValidator = new EmailValidator();
            PasswordValidator passwordValidator = new PasswordValidator();
            LoginValidator loginValidator = new LoginValidator();

            User user = new User
            {
                Login = "User123",
                Password = "P@ssw0rd",  
                Email = "validemail@gmail.com"  
            };

            loginValidator.SetNextValidator(emailValidator);
            emailValidator.SetNextValidator(passwordValidator);

            bool isValid = loginValidator.Validate(user);
            Console.WriteLine(isValid ? "Пользователь успешно прошел валидацию." : "Валидация не пройдена.");

        }
    }
}
