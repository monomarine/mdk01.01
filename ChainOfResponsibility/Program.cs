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
                Login = "armanchik",
                Password = "paaaaaaaDS1aaaa!",
                Email = "tes@@33425345f34t4tf4gt54gvgvftv45yh365tdtv54g6tf3"
            };

            loginValidator.SetNextValidator(emailValidator);
            emailValidator.SetNextValidator(passwordValidator);

            loginValidator.Validate(user);
            passwordValidator.Validate(user);
            emailValidator.Validate(user);
        }
    }
}
