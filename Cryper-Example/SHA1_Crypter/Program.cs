using System;
using System.Security.Cryptography;
using System.Text;

namespace SHA1_Crypter
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
                    using (SHA1Managed sha1 = new SHA1Managed())
                    {
                        var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(data));
                        var sb = new StringBuilder(hash.Length*2);
                        foreach (byte b in hash)
                        {
                            sb.Append(b.ToString("X2"));
                        }
                        Console.WriteLine("SHA1 Hash:"+sb.ToString());
                    }
                }
            }
        }
    }
}
