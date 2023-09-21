using System.Net.Mail;
using System.Text.RegularExpressions;

namespace PhoneBook.Helpers;

internal static class Validation
{
    internal static bool IsValidEmail(string email)
    {
        try
        {
            var addr = new MailAddress(email);
            return addr.Address == email;
        }
        catch
        {
            return false;
        }
    }

    internal static bool IsValidPhone(string phone)
    {
        return Regex.IsMatch(phone, @"^\d{3}-\d{3}-\d{4}$");
    }
}