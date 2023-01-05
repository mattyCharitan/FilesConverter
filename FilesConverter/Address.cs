using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesConverter
{
    public class Address
    {
        public string Street { get; set; }
        public string City { get; set; }

        public void printAddress()
        {
            Console.WriteLine(Street);
            Console.WriteLine(City);

        }
    }
}
