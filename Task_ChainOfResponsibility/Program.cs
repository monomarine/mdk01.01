using Task_ChainOfResponsibility.Validators;
namespace Task_ChainOfResponsibility
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var emailValidator = new EmailValidator();
            var loginValidator = new LoginValidator();
            var passwordValidator = new PasswordValidator();

            emailValidator.SetNextValidator(loginValidator);
            loginValidator.SetNextValidator(passwordValidator);

            var user = new User
            {
                Email = "example@gmail.com",
                Login = "user123",
                Password = "Password123!"
            };

            bool isValid = emailValidator.Validate(user);

            if (isValid)
            {
                Console.WriteLine("Все данные пользователя валидны");
            }
            else
            {
                Console.WriteLine("Данные пользователя не валидны");
            }
        }
    }
}
