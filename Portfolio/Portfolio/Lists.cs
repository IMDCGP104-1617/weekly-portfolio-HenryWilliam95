using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio
{
    class Lists<T> //Makes a template list class
    {
        public class Node
        {
            public T Data; // Makes a data template.
            public Node Next; // Is a pointer to point to the next node.
        }

        private Node head; // Is what we are looking at.
        private int count = 0; //This shows where we are in the list and how big it is.

        public T Head
        {
            get { return head.Data; } //When Head is called returns head.Data.
        }

        public int Count
        {
            get { return count; } // When Count is called returns the count.
        }

        public void List()
        {
            head = null;  //Creates the start of the list to be null.
        }

        ~List()
        {

        }

        public void InsertBeginning(T data)
        {
            Node newNode = new Node(); //Creates a new node.
            newNode.Data = data; // Place the data into new node.
            if (head == null) // Check if the head is null.
            {
                head = newNode; // If it's not, then new node becomes the head.
            }
            else //Make the new node the head.
            {
                newNode.Next = head; //If the head is not null, name new node the head, and move old head to the next position.
                head = newNode; //The new node becomes the head.
            }
            count++; //Add 1 to the count.
        }

        public T RemoveBeginning() // Returns the value of T (Template)
        {
            T ret = default(T); // Template return = default template

            if (head != null) // If the head isn't null 
            {
                ret = head.Data; //return the data in the head.
                if (head.Next == null) //If head doesn't point to anything.
                {
                    head = null; //Head is null, emptying list.
                }
                else
                {
                    head = head.Next; //If there is another node, make that node the head.
                }
            }
            count--; //Take one from the count.
            return ret; //Return the value of ret.
        }

        public void InsertAfter(int count, T data) //Want the function to hold the data of the count and data.  Allows you to InsertAfter (5,8) position 5 with data 8.
        {
            Node newNode = new Node { Data = data }; //Makes a new node making a variable of Data.
            Node current = head; // Assign the current node to the head.
            int counter = 0; // Assigning a counter.
            while (current != null) // Check that the node we are in contains some data
            {
                if (counter == count || current.Next == null) //Check the counter is the same as the position of the list || check if the next one is empty, so data can be put in.
                {
                    newNode.Next = current.Next; //Places the new node after the current node.
                    current.Next = newNode; //Places data in the newNode.
                    counter++; //Add one to the counter

                    break; // Takes you out of the while loop, stops an infinate loop.
                }
            }

            current = current.Next;

        }

        public T RemoveAfter(int count)
        {
            T ret = default(T); // Template return = default template

            Node current = head; //Assign current node to head.
            int counter = 0; //Assign a counter.

            while (current.Next != null) //Check that the next node contains data.
            {
                if (current.Next != null) //If the next node contains data, do this.
                {
                    ret = current.Next.Data; //Assign the data of the next node to ret.
                    current.Next = current.Next.Next; //Remove the next node and assign the pointer to the node after that.
                    counter--; //Take one from the count.
                }

                break; //Takes you out the while loop, stops an infinate loop.
            }

            current = current.Next; //Assign current to the next node.

            return ret;
        }


    }
}
