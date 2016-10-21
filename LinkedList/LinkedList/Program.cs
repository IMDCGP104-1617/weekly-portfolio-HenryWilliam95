using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList list = new LinkedList();
            list.InsertBeginning(32);
            list.InsertBeginning(64);
            list.InsertBeginning(128);
            list.InsertBeginning(256);
        }
    }
}
