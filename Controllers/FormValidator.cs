using System.Text.RegularExpressions;
using AuthAPI.Models;

namespace AuthAPI.Controllers
{
    public static class FormValidator
    {
        public static bool IsValid(string mail, string password)
        {
            Regex regex = new("^[A-Za-z\\d]{8,}$");
            Match match = regex.Match(password);

            if(!match.Success)
                return false;

            regex = new("^\\w+[-+\\.\\w]*[\\w]@[a-z]{4,}[\\.][a-z]{2,3}$");

            match = regex.Match(mail);

            if (!match.Success)
                return false;


            return true;
        }
    }
}
