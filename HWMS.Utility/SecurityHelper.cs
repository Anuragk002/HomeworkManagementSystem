using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace HWMS.Utility
{
    public class SecurityHelper
    {
        public static string GenerateSalt()
        {
            int nSalt=123;
            var saltBytes = new byte[nSalt];

            using (var provider = new RNGCryptoServiceProvider())
            {
                provider.GetNonZeroBytes(saltBytes);
            }

            return Convert.ToBase64String(saltBytes);
        }

        public static string HashPassword(string password, string salt)
        {
            int nIterations=4;
            int nHash=10;
            var saltBytes = Convert.FromBase64String(salt);

            using (var rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, saltBytes, nIterations))
            {
                return Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(nHash));
            }
        }
    }
}
