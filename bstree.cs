using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Node;
using Binary_tree;

namespace Bs_tree
{
    class BSTree<T> : BinTree<T> where T : IComparable
    {  //root declared as protected in Parent Class – Binary Tree
        public BSTree()
        {
            root = null;
        }

        public void InsertItem(T item)
        {
            insertItem(item, ref root);// goes into the recursive function
        }
        private void insertItem(T item, ref Node<T> tree)
        {
            if (tree == null)
            {
                tree = new Node<T>(item);
            }
            else if (item.CompareTo(tree.Data) < 0)
            {
                // if the data is less than the current root data
                insertItem(item, ref tree.Left);// go to the left side and carry on searching
            }
            else if (item.CompareTo(tree.Data) > 0)
            {
                //if data is greater than the current root node
                insertItem(item, ref tree.Right);// go to the right hand side of the tree

            }

        }
        public void RemoveItem(T item)
        {
            removeItem(item, ref root);
        }
        private void removeItem(T item, ref Node<T> tree)
        {
            if (tree == null)
            {
                return;
            }
            if (item.CompareTo(tree.Data) < 0)//if item is less than current root data
            {
                removeItem(item, ref tree.Left);//move to the left hand side of the tree
            }
            if (item.CompareTo(tree.Data) > 0)//if item is greater than current root data
            {
                removeItem(item, ref tree.Left);//move to the right hand side of the tree
            }
            if (item.CompareTo(tree.Data) == 0)//if it does equal the data we are looking for
            {
                if (tree.Left == null & tree.Right != null)//if left is null and right isn't
                {
                    tree = tree.Right;//the right node replaces current node
                }
                else if (tree.Right == null & tree.Left != null)//if right is null and left isn't
                {
                    tree = tree.Left;//the left node replaces current node
                }
                else if (tree.Left == null & tree.Right == null)
                {
                    T newRoot = LeastItem(tree.Right);
                    tree.Data = newRoot;
                    removeItem(newRoot, ref tree.Right);

                }
            }
        }
        public T LeastItem(Node<T> tree)
        {
            if (tree.Left == null)
            {
                return (tree.Data);
            }
            else
            {
                return LeastItem(tree.Left);
            }
        }
        public int FindHeight()
        {
            return Height(root);
        }
        protected int Height(Node<T> tree)
        {
            if (tree == null)
            {
                return -1;
            }
            else
            {
                int leftHeight = Height(tree.Left);// this keeps on iterating until it hits the very last tree, which will send back the height of the left hand side
                int rightHeight = Height(tree.Right); //this keeps on iterating until it hits the very last tree, which will send back the height of the right hand side
                if (leftHeight > rightHeight)
                {
                    return leftHeight + 1;
                }
                else
                {
                    return rightHeight + 1;
                }

            }
        }
        public int Count()
        {
            return count(root);
        }
        private int count(Node<T> tree)
        {
            int c = 1;             //Node itself should be counted
            if (tree == null)
                return 0;
            else
            {
                c += count(tree.Left);
                c += count(tree.Right);
                return c;
            }
        }

        public Boolean Contains(T item)
        {
            return contain(root, item);
        }

        private bool contain(Node<T> tree, T item)
        {
            if (tree != null)// if tree is null, return false
            {
                if (item.CompareTo(tree.Data) == 0)
                {
                    return true;//if data is same as item, return true
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
            return false;
        }
    }

}
