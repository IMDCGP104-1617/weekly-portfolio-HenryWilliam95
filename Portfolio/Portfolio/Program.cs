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
           #region Lists Tests
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
            #endregion

           #region Stack Tests
            Stacks<int> stack = new Stacks<int>();
            stack.Push(8);
            stack.Push(3);
            stack.Push(5);
            stack.Push(6);
            stack.Push(10);
            stack.Push(2);
            stack.Peek();
            while (!stack.IsEmpty())
            {
                int output;
                stack.Pop(out output);
                Console.WriteLine(output);
            }
            #endregion 

           #region Queue Tests
            Queues<int> queue = new Queues<int>();
            queue.Enqueue(5);
            queue.Enqueue(8);
            queue.Enqueue(3);
            queue.Enqueue(9);

            while (!queue.IsEmpty())
            {
                int output;
                queue.Dequeue(out output);
                Console.WriteLine(output);
            }
            #endregion
        }
    }
}
