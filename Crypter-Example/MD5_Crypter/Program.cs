using System;
using System.Security.Cryptography;
using System.Text;

namespace md5_crypter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Çıkış Yapmak İçin 'Q' Basınız!");
            while (true)
            {
                string data = Console.ReadLine();
                if (data.ToLower() == "q")
                {
                    break;
                }
                else
                {
                    MD5 md5 = new MD5CryptoServiceProvider();
                    byte[] byt = Encoding.UTF8.GetBytes(data);
                    byt = md5.ComputeHash(byt);
                    StringBuilder sb = new StringBuilder();
                    foreach (byte item in byt)
                    {
                        sb.Append(item.ToString("x2").ToLower());
                    }
                    Console.WriteLine("MD5 Hash:{0}",sb);
                }
            }
        }
    }
}
