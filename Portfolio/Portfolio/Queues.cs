using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio
{
    class Queues<T>
    {
        private Lists<T> queue;
        private int count; //Variable to show the size of the queue

        public int Count
        {
            get { return count; } //Gets the count and shows it publically
        }

        public bool IsEmpty()
        {
            return count == 0; //If count is equal to 0 retun true, if any other value is returned, return false.
        }

        public Queues() //Constructor of the Queue
        {
            queue = new Lists<T>();
        }

        ~Queues() //Deconstructor of Queue
        {
            while (!IsEmpty())
            {
                T output;
                Dequeue(out output);
            }
        }

        public void Enqueue(T data)
        {
            count++;
            queue.InsertEnd(data); //Insert data at the end of the queue
        }

        public bool Dequeue(out T output)
        {
            output = default(T);

            if (IsEmpty())
            {
                return false; //If returned false the queue is empty
            }

            output = queue.RemoveBeginning(); //Remove the oldest value from the queue (from the start)
            count--; 
            return true;  //Return true shows that something was removed
        }

        public T Peek()
        {
            return queue.Head; //Shows the value at the head without removing it.
        }

        //public T Length()
        //{
        //    return Count;
        //}
    }
}
