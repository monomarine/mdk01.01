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
                Login = "546",
                Password = "password46545",
                Email = "testemail@mail.ru"
            };

            User user1 = new User
            {
                Login = "qwerty",
                Password = "password!",
                Email = "testemail"
            };
            User user2 = new User
            {
                Login = "qwerty",
                Password = "password",
                Email = "testemail"
            };

            loginValidator.SetNextValidator(emailValidator);
            emailValidator.SetNextValidator(passwordValidator);


            loginValidator.Validate(user);
            loginValidator.Validate(user1);
            passwordValidator.Validate(user1);
            emailValidator.Validate(user1);
            loginValidator.Validate(user2);
            passwordValidator.Validate(user2);
            emailValidator.Validate(user2);


        }
    }
}
