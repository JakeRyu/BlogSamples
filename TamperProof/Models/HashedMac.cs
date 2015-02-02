using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace TamperProof.Models
{
    public class HashedMac
    {
        public static byte[] ComputeHash(string key, string value)
        {
            byte[] secretKey = Convert.FromBase64String(key);
                
            using (HMACSHA256 hmac = new HMACSHA256(secretKey))
            {
                return hmac.ComputeHash(Encoding.UTF8.GetBytes(value));
            }
        }
    }
}