using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Inherance
{
    public class Lion:Animal
    {
        public Lion()
        {
            Console.WriteLine("This is childConstructor");
        }
        public int  Mane { get; set; }

    }
}
