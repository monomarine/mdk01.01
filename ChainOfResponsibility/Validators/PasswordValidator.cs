using ChainOfResponsibility.Validators;
using ChainOfResponsibility;
using System.Text.RegularExpressions;

internal class PasswordValidator : IValidator
{
    private IValidator _nextValidator;
    private static readonly Regex PasswordRegex = new Regex(
        "^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[#*!@]).{8,}$");

    public void SetNextValidator(IValidator validator)
    {
        _nextValidator = validator;
    }

    public bool Validate(User user)
    {
        if (string.IsNullOrEmpty(user.Password))
        {
            Console.WriteLine("Пароль не может быть пустым");
            return false;
        }

        if (!PasswordRegex.IsMatch(user.Password))
        {
            Console.WriteLine("Пароль должен содержать латинские буквы в обоих регистрах, цифры и спецсимволы # * ! @");
            return false;
        }

        return _nextValidator?.Validate(user) ?? true;
    }
}