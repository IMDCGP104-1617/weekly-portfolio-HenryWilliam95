using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio
{
    class Stacks<T>
    {
        private Lists<T> stack;
        private int count; //Shows the size of the stack.

        public int Count 
        {
            get { return count; } //Creates a function that will return count publicly.
        }

        public bool IsEmpty()
        {
            return count == 0; //If count is equal to 0 retun true, if any other value is returned, return false.
        }

        public Stacks() //Constructor of the stack class.
        {
            stack = new Lists<T>();
        }

        ~Stacks() //Deconstructor.
        {
            while (!IsEmpty()) //While it's not empty remove the top item until empty.
            {
                T output; // Output the value of T
                Pop(out output); // Causes the output to be passed by reference.
            }
        }

        public void Push(T data) 
        {
            count++; // Add one to the stack.
            stack.InsertBeginning(data); // Insert data at the top of the stack.
        }

        public bool Pop(out T output)
        {
            output = default(T);

            if (IsEmpty())
            {
                return false;
            }

            output = stack.RemoveBeginning(); //Remove the top item from the stack.

            count--; //Take one from the size of the stack.

            return true; 
        }

        public T Peek() //Allows us to look at the top value of the stack without touching it.
        {
            return stack.Head; //Returns the data contained in the head at the top of the stack.

        }

    }
}
