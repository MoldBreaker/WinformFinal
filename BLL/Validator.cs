using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BLL
{
    public class Validator
    {
        public static bool IsValidEmail(string email)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            return regex.Match(email).Success;
        } 

        public static bool IsValidPhone(string phone)
        {
            Regex regex = new Regex(@"^(?:\+84|0)(?:3[2-9]|5[2689]|7[0|6-9]|8[1-9]|9[0-9])\d{7}$");
            return regex.Match(phone).Success;
        }
    }
}
