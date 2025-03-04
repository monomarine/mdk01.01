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
                Login = "546243",
                Password = "asdsaads1ad1!asdsad21321!",
                Email = "pochtaqw@mail.ru"
            };

            loginValidator.SetNextValidator(emailValidator);
            emailValidator.SetNextValidator(passwordValidator);

            loginValidator.Validate(user);
        }
    }
}
