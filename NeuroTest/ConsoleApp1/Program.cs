using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            sled dab = new sled();
            dab.retr();
            Console.ReadKey();
        }
    }
    abstract class nas
    {
        string ret()
        {
            return null;
        }
    }
    class sled:nas
    {
        public string retr()
        {
            return Console.WriteLine(""); ;
        }
    }
}
