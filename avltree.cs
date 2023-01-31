using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bs_tree;
using Node;
using Binary_tree;

namespace AVL_binary_trees
{
    class AVLTree<T> : BSTree<T> where T : IComparable
    {
        public new void RemoveItem(T item)
        {
            removeItem(item, ref root);
        }
        private void removeItem(T item, ref Node<T> tree)
        {
            if (tree == null)
            {
                return;
            }
            if (item.CompareTo(tree.Data) < 0)
            {
                removeItem(item, ref tree.Left);
            }
            if (item.CompareTo(tree.Data) > 0)
            {
                removeItem(item, ref tree.Left);
            }
            if (item.CompareTo(tree.Data) == 0)
            {
                if (tree.Left == null & tree.Right != null)
                {
                    tree = tree.Right;
                    tree.BalanceFactor = Height(tree.Left) - Height(tree.Right);
                    if (tree.BalanceFactor <= -2)
                    {
                        rotateLeft(ref tree);
                    }
                    if (tree.BalanceFactor >= 2)
                    {
                        rotateRight(ref tree);
                    }
                }
                else if (tree.Right == null & tree.Left != null)
                {
                    tree = tree.Left;
                    tree.BalanceFactor = Height(tree.Left) - Height(tree.Right);
                    if (tree.BalanceFactor <= -2)
                    {
                        rotateLeft(ref tree);
                    }
                    if (tree.BalanceFactor >= 2)
                    {
                        rotateRight(ref tree);
                    }
                }
                else if (tree.Right != null & tree.Left != null)
                {
                    T newRoot = LeastItem(tree.Right);
                    tree.Data = newRoot;
                    removeItem(newRoot, ref tree.Right);

                }
                else
                {
                    tree = null;
                }
            }

        }
        public new void InsertItem(T item)
        {
            insertItem(item, ref root);
        }
        private void insertItem(T item, ref Node<T> tree)
        {
            if (tree == null)
            {
                tree = new Node<T>(item);
                tree.Occurence++;
            }
            else if (item.CompareTo(tree.Data) < 0)
            {
                insertItem(item, ref tree.Left);
            }
            else if (item.CompareTo(tree.Data) > 0)
            {
                insertItem(item, ref tree.Right);
            }
            tree.BalanceFactor = Height(tree.Left) - Height(tree.Right); // this is what makes the tree an AVL tree, the node mus be either 1,0 or -1
            if (tree.BalanceFactor <= -2)
            {
                rotateLeft(ref tree);
            }
            if (tree.BalanceFactor >= 2)
            {
                rotateRight(ref tree);
            }

        }
        private void rotateLeft(ref Node<T> tree)
        {
            if (tree.Right.BalanceFactor > 0)  //double rotate
                rotateRight(ref tree.Right);
            else
            {
                Node<T> oldroot = tree; // is current tree
                Node<T> newroot = tree.Right; // right hand side of the tree is the new tree
                oldroot.Right = newroot.Left; // so anything on the left had side of the tree will become on the right hand side of the old tree, so that the left hand side doesn't disappear
                newroot.Left = oldroot;// new roots left hand side is now the old root
                tree = newroot;
            }
        }
        private void rotateRight(ref Node<T> tree)
        {
            if (tree.Left.BalanceFactor < 0)  //double rotate
                rotateLeft(ref tree.Left);
            else
            {
                Node<T> oldroot = tree;
                Node<T> newroot = tree.Left;
                oldroot.Left = newroot.Right;
                newroot.Right = oldroot;
                tree = newroot;

            }
        }
        public void Increment (T item) // increments the occurence, if it is in the tree
        {
            increment (root,item);
        }
        private void increment(Node<T> tree, T item)
        {
            if (tree != null)// if tree is null, return false
            {
                if (item.CompareTo(tree.Data) == 0)
                {
                    tree.Occurence++; // increment the occurance in the node class
                }
                if (item.CompareTo(tree.Data) < 0)
                {
                    increment(tree.Left, item); //if ditem is smaller than data, go into left tree
                }
                if (item.CompareTo(tree.Data) > 0)
                {
                    increment(tree.Right, item);//if ditem is greater than data, go into right tree
                }
            }
        }
        public new int Contains(T item) // changed so that it returns a number , instead of a boolean 
        {
            return contain(root, item);
        }

        private int contain(Node<T> tree, T item)
        {
            if (tree != null)// if tree is null, return 0
            {
                if (item.CompareTo(tree.Data) == 0)
                {
                    return tree.Occurence;//if data is same as item, return the occurence of the node
                }
                if (item.CompareTo(tree.Data) < 0)
                {
                    return contain(tree.Left, item); //if ditem is smaller than data, go into left tree
                }
                if (item.CompareTo(tree.Data) > 0)
                {
                    return contain(tree.Right, item);//if ditem is greater than data, go into right tree
                }
            }
            return 0;
        }
    }

}
