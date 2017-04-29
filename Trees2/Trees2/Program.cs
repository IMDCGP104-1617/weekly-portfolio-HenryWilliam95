using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create a new node
            //Give it a starting value
            Node root = new Node(21, null);
            
            //Insert a bunch of values
            root.Insert(5);
            root.Insert(10);
            root.Insert(4);
            root.Insert(3);
            root.Insert(15);
            root.Insert(24);
            root.Insert(18);
            root.Insert(50);
            root.Insert(13);
            root.Insert(9);

            //Print the tree
            root.printTree();

            //Remove a value
            root.remove(15);
            root.remove(3);
            root.remove(10);

            //Print the tree again
            root.printTree();

            Console.ReadKey();
        }
    }
}
