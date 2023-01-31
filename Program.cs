using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Node;
using Binary_tree;
using Bs_tree;
using AVL_binary_trees;

namespace exercise_2_Taskc
{
    class Program
    {
        static void Main(string[] args)
        {
            bool end = false;
            AVLTree<string> mytree = new AVLTree<string>(); //  create a new Binary Search Tree

            while (end != true)// whilst user hasn't entered end
            {
                Console.WriteLine("add,contains,preorder,end");//print comands
                Console.WriteLine("Please choose the following options");
                string ans = Console.ReadLine();//take the input of the user in
                ans.ToLower();//convert all to lower case
                if (ans == "add") //if add
                {
                    Console.WriteLine("please enter the STRING you want to add to the tree");
                    string word = Console.ReadLine();//take in users answer
                    if (word.Length != 0)// check if word is empty
                    {
                        if (mytree.Contains(word) > 0)
                        {
                            mytree.Increment(word);//insert word into tree
                        }
                        else if (mytree.Contains(word) == 0)
                        {
                            mytree.InsertItem(word);//insert word into tree
                        }
                    }
                    else
                    {
                        Console.WriteLine("Error");//print error message
                    }
                }
                else if (ans == "preorder")
                {
                    string buffer = "";
                    mytree.PreOrder(ref buffer); ;
                    Console.WriteLine(buffer);
                }
                else if (ans == "contains")
                {
                    Console.WriteLine("please enter the STRING you want to search for");
                    string word = Console.ReadLine();//take in users answer
                    if (word.Length != 0)// check if word is empty
                    {
                        if (mytree.Contains(word) == 0)
                        {
                            Console.WriteLine("Item isn't in the tree");
                        }
                        else if (mytree.Contains(word) > 0)
                        {
                            Console.WriteLine("amount of "+ word+" : " + mytree.Contains(word).ToString());
                        }
                    }
                    else
                    {
                        Console.WriteLine("Error");//print error message
                    }
                }
                else if (ans == "end")
                {
                    end = true;
                    Console.WriteLine("Goodbye!");
                }
                else
                {
                    Console.WriteLine("Error");
                }
            }
        }
    }
}