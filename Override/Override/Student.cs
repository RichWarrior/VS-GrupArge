using System;
using System.Collections.Generic;
using System.Text;

namespace Override
{
    public class Student : BaseStudent
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Ort { get; set; }

        public override void State()
        {
            if (Ort > 70 && Ort < 85)
                Console.WriteLine("Teşekkür");
            else if (Ort >= 85)
                Console.WriteLine("Takdir");
            else
                Console.WriteLine("Düz");
        }
    }
}
