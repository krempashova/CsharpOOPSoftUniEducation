using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Inherance
{
    public class Animal
    {

        public Animal()
        {
            Console.WriteLine("this is base -Parentconstructor");
        }
        public string  Name { get; set; }
        public int Age { get; set; }
        public int kilograms { get; set; }
    }
}
