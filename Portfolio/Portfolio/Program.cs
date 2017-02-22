using Portfolio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Portfolio
{
    class Program
    {
        static void Main(string[] args)
        {
            Lists<int> Lists = new Lists<int>();

            Lists.InsertBeginning(5);
            Lists.InsertBeginning(8);
            Lists.InsertBeginning(1);

            Lists.InsertAfter(4, 7);
            Lists.InsertAfter(4, 3);
            Lists.InsertAfter(2, 9);

            Lists.RemoveBeginning();

            Lists.RemoveAfter(2);

            

            Console.WriteLine(Lists.Count);


        }

        //public void InsertBeginning(T)
        //{
        //    
        //}
    }
}
