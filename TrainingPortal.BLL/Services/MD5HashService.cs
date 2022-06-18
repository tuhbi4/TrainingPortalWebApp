using System;
using System.Security.Cryptography;
using System.Text;
using TrainingPortal.BLL.Interfaces;

namespace TrainingPortal.BLL.Services
{
    public class MD5HashService : IHashService
    {
        public string GetHash(string input)
        {
            if (input != null)
            {
                var md5 = MD5.Create();
                var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(input));

                return Convert.ToBase64String(hash);
            }

            return null;
        }
    }
}