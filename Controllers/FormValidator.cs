using System.Text.RegularExpressions;

namespace AuthAPI.Controllers
{
    public static class FormValidator
    {
        public static bool IsValid(string str)
        {
            Regex regex = new("^[A-Za-z\\d]{8,}$");
            Match match = regex.Match(str);

            if(!match.Success)
                return false;

            return true;
        }
    }
}
