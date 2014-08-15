using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Rest.Core.Utility
{
    public class Encrypt
    {
        public static string RandomStr(int length)
        {
            var Words = @"ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789@#$%^&=+\|<>?,/[]{}:;'`~".ToCharArray();
            var lenght = Words.Count();
            Random random = new Random((int)DateTime.Now.Ticks);
            string result = string.Empty;
            for (int i = 0; i < length; i++)
            {
                result += Words[random.Next(lenght)];
            }
            return result;
        }

        public static string EncryptPassword(string password, string salt)
        {
            if (salt == null) return password;
            SHA256 algorithm = SHA256Managed.Create();
            StringBuilder passwordBuilder = new StringBuilder();
            char[] param1 = password.ToCharArray();
            char[] param2 = salt.ToCharArray();
            for (int i = 0; i < Math.Min(param1.Length, param2.Length); i++)
            {
                passwordBuilder.Append(param1[i]);
                passwordBuilder.Append(param2[i]);
            }
            if (param1.Length < param2.Length)
            {
                for (int i = param1.Length; i < param2.Length; i++)
                    passwordBuilder.Append(param2[i]);
            }
            if (param2.Length < param1.Length)
            {
                for (int i = param2.Length; i < param1.Length; i++)
                    passwordBuilder.Append(param1[i]);
            }
            byte[] data = Encoding.UTF8.GetBytes(passwordBuilder.ToString());
            byte[] encrypted = algorithm.ComputeHash(data);
            return Convert.ToBase64String(encrypted);
        }
    }
}