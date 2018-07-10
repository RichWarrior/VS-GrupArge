using System;
using System.Security.Cryptography;
using System.Text;

namespace SHA256_Crypter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Çıkış Yapmak İçin 'Q' Basınız!");
            while (true)
            {
                string data = Console.ReadLine();
                if (data.ToLower()=="q")
                {
                    break;
                }else
                {
                    byte[] byt = Encoding.UTF8.GetBytes(data);
                    SHA256Managed sha256 = new SHA256Managed();
                    byt = sha256.ComputeHash(byt);
                    string hash = String.Empty;
                    foreach (byte item in byt)
                    {
                        hash += String.Format("{0:x2}",item.ToString());
                    }
                    Console.WriteLine("SHA256 Hash:{0}",hash);
                }
            }
        }
    }
}
