using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees2
{
    class Node
    {

        public Node(int value, Node par)
        {
            this.Value = value;
            this.parent = par;
            nodeList.Add(this);
        }
        public Node()
        { }

        static List<Node> nodeList = new List<Node>();

        public Node Left; 
        public Node Right;
        public Node parent;

        public bool hasLeftChild()
        {
            return (Left != null);
        }

        public bool hasRightChild()
        {
            return (Right != null);
        }
        
        public bool hasNoChildren()
        {
            if (Left == null && Right == null) return true;
            return false;
        }

        public bool hasBothChildren() 
        {
            return (Left != null && Right != null);
        }

        public int Value;

        public void Insert(int newValue)
        {
            if (newValue < Value)
            {
                if (Left == null)
                {
                    Left = new Node(newValue, this); //Create a new node on the left
                    //Left.Value = newValue; //Stores the values in the left node
                }
                else
                {
                    Left.Insert(newValue); //Replace 
                }
            }
            else if (newValue > Value)
            {
                if (Right == null)
                {
                    Right = new Node(newValue, this);  //Creates a new node on the right
                    //Right.Value = newValue; //Stores the value in the right node
                }
                else
                {
                    Right.Insert(newValue); //Replace
                }
            }

        }

        Node Search(int searchValue)
        {
            if (searchValue < Value)
            {
                if (Left == null)
                    return null; //If there is no content return null

                return Left.Search(searchValue); //Else return the value
            }
            else if (searchValue > Value)
            {
                if (Right == null)
                    return null; //If there is no content return null

                return Right.Search(searchValue); //Else return the value
            }
            else
            {
                return this;
            }
        }

        void Delete(int deletion, Node parent)
        {
            Node startNode = this.Search(deletion);
            if (startNode == null) return;

            //Run this code if this is a leaf node.
            if (startNode.hasNoChildren()) {
                //Remove reference from the parent to the node being deleted.
                if (startNode.parent.Left.Value == startNode.Value)
                    startNode.parent.Left = null;
                //If it is not a left node, check the right side.
                else if
                (startNode.parent.Right.Value == startNode.Value)
                    startNode.parent.Right = null;

                //Removes the node by making it null.
                Node.nodeList.Remove(startNode);
                startNode = null;
            }
            //Check if the node to be deleted has a left.
            else if (startNode.hasLeftChild()) 
            {
                //If the node has two children run this code.
                if (startNode.hasRightChild()) {

                }
                //Else if there is just one child run this.
                else if (!startNode.hasRightChild()) 
                {
                    
                }

            } 
            //Checks if the node just has a right child.
            else if (startNode.hasRightChild()) 
            {
                 
            }








            if (deletion == Value) //Checks if this is the correct value.
            {
                if (Left == null && Right == null) //Checks if the children are null.
                {
                    if (parent.Right == this) //If the value we are looking at is on the left of its parent
                        parent.Right = null; //Delete the right child
                    else
                        parent.Left = null; //If the child is not on the right, delete the left child

                    return;
                }

                else if (Left != null && Right != null)
                {

                }

                else
                {
                    bool isLeft = (parent.Left == this); //Checks if this is the parents left node

                    if (Left != null) //Checks if the left is not null, so therefore the child is on the left.
                    {
                        if (isLeft) //If it is, check which node to replace.
                            parent.Left = Left; 
                        else
                            parent.Right = Left;
                    }
                    else
                    {
                        if (!isLeft) //Checks if the child is on the right 
                            parent.Left = Right;
                        else
                            parent.Right = Right;
                    }
                }
            }

        }


        public void remove(int toDelete)
        {

            Node startNode = this.Search(toDelete);
            if (startNode == null) return;

            //If I have no children

            if (startNode.hasNoChildren())
            {
                //Make our parents refference to us null
                if (startNode.parent.Left.Value == startNode.Value) startNode.parent.Left = null;
                else if (startNode.parent.Right.Value == startNode.Value) startNode.parent.Right = null;

                //make startnode null
                Node.nodeList.Remove(startNode);
                startNode = null;
            }
            //If WE have a left child...
            else if (startNode.hasLeftChild())
            {
                //TempRef refers to OUR left child...
                Node tempRef = startNode.Left;

                //If this child has a Right Child...
                while (tempRef.hasRightChild())
                {
                    //This now becomes temp Ref
                    tempRef = tempRef.Right;

                    //Keep looping until there is no more right child
                }
                //Once we have found the highest child...

                //If this isnt YET the value...
                if (tempRef.Value != toDelete)
                {

                }

                //--
                //Swap our values with tempRef...

                //Remember our values
                int tempVal = startNode.Value;
                Node tempRight = startNode.Right;
                Node tempLeft = startNode.Left;

                //Our values become tempRef values
                startNode.Value = tempRef.Value;
                startNode.Right = tempRef.Right;
                startNode.Left = tempRef.Left;

                //tempRef values become our old values
                tempRef.Value = tempVal;
                tempRef.Right = tempRight;
                tempRef.Left = tempLeft;

                //Delete tempRef;
                nodeList.Remove(tempRef);
                tempRef = null;
            }
        }

        public void printTree()
        {
            Console.WriteLine("Printing each value in tree (no particular order): ");
           foreach(Node node in Node.nodeList)
            {
                Console.WriteLine("\t" + node.Value);
            }
        }
    }
}
