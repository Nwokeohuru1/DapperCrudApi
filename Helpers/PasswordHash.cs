using System.Security.Cryptography;
using System.Text;

namespace DapperCrudApi.Helpers
{
    public class PasswordHash
    {
      public static string HashPass(string UserPassword)
        {
            using var sha = SHA256.Create();
            byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(UserPassword));
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                stringBuilder.Append(bytes[i]);
            }
            return stringBuilder.ToString();



            ////var sha = SHA256.Create();
            ////byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password));

            ////StringBuilder stringbuilder = new StringBuilder();
            ////for (int i = 0; i < bytes.Length; i++)
            ////{
            ////    stringbuilder.Append(bytes[i].ToString("x2"));
            ////}
            ////return stringbuilder.ToString();
            // return Convert.ToBase64String(hashedPassword);
        }
    }
}
