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
            this.parentNode = par;
            nodeList.Add(this);
        }

        static List<Node> nodeList = new List<Node>();

        public Node leftNode; 
        public Node rightNode;
        public Node parentNode;

        public int Value;

        public bool hasLeftChild()
        {
            return (leftNode != null);
        }

        public bool hasRightChild()
        {
            return (rightNode != null);
        }
        
        public bool hasNoChildren()
        {
            if (leftNode == null && rightNode == null) return true;
            return false;
        }

        public bool hasBothChildren() 
        {
            return (leftNode != null && rightNode != null);
        }

        public void Insert(int newValue)
        {
            if (newValue < Value)
            {
                if (leftNode == null)
                {
                    leftNode = new Node(newValue, this); //Create a new node on the left
                    //Left.Value = newValue; //Stores the values in the left node
                }
                else
                {
                    leftNode.Insert(newValue); //Replace 
                }
            }
            else if (newValue > Value)
            {
                if (rightNode == null)
                {
                    rightNode = new Node(newValue, this);  //Creates a new node on the right
                    //Right.Value = newValue; //Stores the value in the right node
                }
                else
                {
                    rightNode.Insert(newValue); //Replace
                }
            }

        }

        Node Search(int searchValue)
        {
            if (searchValue < Value)
            {
                if (leftNode == null)
                    return null; //If there is no content return null

                return leftNode.Search(searchValue); //Else return the value
            }
            else if (searchValue > Value)
            {
                if (rightNode == null)
                    return null; //If there is no content return null

                return rightNode.Search(searchValue); //Else return the value
            }
            else
            {
                return this;
            }
        }

        public void Delete(int deletion)
        {
            Node startNode = this.Search(deletion);
            if (startNode == null) return;

            //Run this code if this is a leaf node.
            if (startNode.hasNoChildren())
            {
                //Remove reference from the parent to the node being deleted.
                if (startNode.parentNode.leftNode.Value == startNode.Value)
                    startNode.parentNode.leftNode = null;
                //If it is not a left node, check the right side.
                else if
                (startNode.parentNode.rightNode.Value == startNode.Value)
                    startNode.parentNode.rightNode = null;

                //Removes the node by making it null.
                nodeList.Remove(startNode);
                startNode = null;
            }
            //Check if the node to be deleted has a left child.
            else if (startNode.hasLeftChild())
            {
                //If the node has two children run this code.
                if (startNode.hasRightChild())
                {
                    //Makes the tempNode move to the right child, then travel down to take left most node of right tree.
                    Node tempNode = startNode.rightNode;
                    while (tempNode.hasLeftChild())
                    {
                        tempNode = tempNode.leftNode;
                    }
                    //Swap the values the remove the bottom left node. (Which will now be a leaf node)
                    startNode.Value = tempNode.Value;

                    nodeList.Remove(startNode);
                    tempNode.parentNode.leftNode = null;
                }
            
                //Else if there is just one child run this.
                else if (!startNode.hasRightChild())
                {
                    if (startNode.parentNode.hasLeftChild() && startNode.parentNode.leftNode == startNode)
                    {
                        startNode.parentNode.leftNode = startNode.leftNode;
                        startNode.leftNode.parentNode = startNode.parentNode;
                        nodeList.Remove(startNode);
                        startNode = null;
                    }
                    else if (startNode.parentNode.hasRightChild() && startNode.parentNode.rightNode == startNode)
                    {
                        startNode.parentNode.rightNode = startNode.leftNode;
                        startNode.leftNode.parentNode = startNode.parentNode;
                        nodeList.Remove(startNode);
                        startNode = null;
                    }
                }

            }
            //Checks if the node just has a right child.
            else if (startNode.hasRightChild())
            {
                //Checks if the startNode is the left child of its parent
                if (startNode.parentNode.hasLeftChild() && startNode.parentNode.leftNode == startNode)
                {
                    //Makes the parent's left pointer, point to startNodes right child.
                    startNode.parentNode.leftNode = startNode.rightNode;
                    startNode.rightNode.parentNode = startNode.parentNode;
                    nodeList.Remove(startNode);
                    startNode = null;
                }
                //Checks if the startNode is the right child of its parent
                else if (startNode.parentNode.hasRightChild() && startNode.parentNode.rightNode == startNode)
                {
                    //Makes the parent's right pointer, point to startNodes left child.
                    startNode.parentNode.rightNode = startNode.rightNode;
                    startNode.rightNode.parentNode = startNode.parentNode;
                    nodeList.Remove(startNode);
                    startNode = null;
                }
            }
        }
        
        //Prints root, then left side then right side
        public void PreOrderTraverse()
        {
            //Print out the current value (Starts at root)
            Console.WriteLine(this.Value + " ");
            //Checks if there is a left node, if there is it prints that node
            if (this.hasLeftChild())
            {
                //Then checks for another left node, keeps doing this until it reaches the end of the left nodes.
                this.leftNode.PreOrderTraverse();
            }
            //Then it will check the right node of every node it has check on the left side before getting back to the root, then going down that left side then right side.
            if (this.hasRightChild())
            {
                this.rightNode.PreOrderTraverse();
            }
        }

        //Start traversing the left tree, then the right tree then the root.
        public void PostOrderTraverse()
        {
            //Checks if there is a left child, if there is, works down until there is no more left children, then prints that value.
            if (this.hasLeftChild())
            {
                //Moves onto the next node.
                this.leftNode.PostOrderTraverse();
            }
            //Checks if there is a right child, if there is, works down until there is no more right children, then prints that value.
            if (this.hasRightChild())
            {
                //Moves onto the next node.
                this.rightNode.PostOrderTraverse();
            }
            //Prints out the current value.
            Console.WriteLine(this.Value + " ");
        }

        //Prints out the tree in order, starting with left mode node, the left most right node, moving up to the root then down the right.
        public void InOrderTraverse()
        {
            //Checks if there is a left child
            if (this.hasLeftChild())
            {
                //Keep moving down until there are no more left children
                this.leftNode.InOrderTraverse();
            }
            //Print this value out, then check for more left, then print out the right side of that node too.
            Console.WriteLine(this.Value + " ");
            if (this.hasRightChild())
            {
                this.rightNode.InOrderTraverse();
            }
        }

        public void LevelOrderTraverse()
        {

        }
    }
}
