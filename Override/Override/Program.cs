using System;

namespace Override
{
    class Program
    {
        static void Main(string[] args)
        {
            Student st = new Student();
            while (true)
            {
                Console.WriteLine("Çıkmak İçin 'Q' Basınız!\nAd Soyad Giriniz");
                var value = Console.ReadLine().ToLower();
                if (value == "q")
                    break;
                st.Name = value.ToUpper();
                Console.WriteLine("Soyad Giriniz");
                st.Surname = Console.ReadLine();
                Console.WriteLine("Ortalama Giriniz!");
                st.Ort = int.Parse(Console.ReadLine());
                st.State();
            }
        }
    }
}
