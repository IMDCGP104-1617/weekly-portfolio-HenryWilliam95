using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    class LinkedList
    {
        public class Node
        {
            public object Content;
            public Node Next;
        }

        private Node head;

        public LinkedList()
        {
            head = null;
        }

        public void InsertBeginning(object content)
        {
            Node newNode = new Node();
            newNode.Content = content;

            if (head == null)
            {
                head = newNode;
            }
            else
            {
                newNode.Next = head;
                head = newNode;
            }
        }
    }
}
