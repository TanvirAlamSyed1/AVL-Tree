using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Node
{
    class Node<T> where T : IComparable
    {
        private T data;
        private int balanceFactor = 0;
        private int occurance = 0; // added to record the amount of an item in the tree
        public Node<T> Left, Right;
        public Node(T item)
        {
            data = item;
            Left = null;
            Right = null;
        }
        public T Data
        {
            set { data = value; }
            get { return data; }
        }
        public int BalanceFactor
        {
            get { return balanceFactor; }
            set { balanceFactor = value; }
        }
        public int Occurence
        {
            get { return occurance; }
            set { occurance = value; }
        }
    }
}
