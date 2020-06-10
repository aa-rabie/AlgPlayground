﻿using AlgPlayGroundApp.DataStructures;
using System;
using AlgPlayGroundApp.Extensions;
using AlgPlayGroundApp.Helpers;
using AlgPlayGroundApp.Sorting;

namespace AlgPlayGroundApp
{
    class Program
    {
        static void Main(string[] args)
        {
            TestQuickSort();
        }

        private static void TestArray()
        {
            Array<string> arr = new Array<string>(4);
            arr.Add("a");
            arr.Add("b");
            arr.Add("c");
            arr.Add("d");
            arr.Add("e");
            arr.Add("f");
            arr.RemoveAt(5);
            arr.RemoveAt(2);
            Console.WriteLine(arr.IndexOf("d"));
            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }
        }

        private static void TestLinkedList()
        {
            var list = new LinkedList<int>();
            for (int i = 0; i < 10; i++)
            {
                list.AddLast(i * 10);
            }

            Console.WriteLine("List Values");
            Console.WriteLine($"[{string.Join(',',list.ToArray())}]");

            GetKthFromEnd(list, 2);
            GetKthFromEnd(list, 0);
            GetKthFromEnd(list, 1);
            GetKthFromEnd(list, 10);
            GetKthFromEnd(list, 4);
            GetKthFromEnd(list, -4);

            Console.ReadLine();

            void GetKthFromEnd(LinkedList<int> linkedList, int k)
            {
                var val = linkedList.GetKthFromTheEnd(k);
                Console.WriteLine($"{k} node from the end value is {val}");
            }
        }

        static void TestReveseString(string input)
        {
            var reversed = input.ReverseUsingStack();
            Console.WriteLine($"input: {input}, reversed: {reversed}");
        }

        static void TestBalancedExpressionChecker()
        {
            var checker = new ExpressionChecker();
            var input = "(1 + 2)";
            var balanced = checker.IsBalanced(input);
            Console.WriteLine($"Expression: '{input}' , Is Balanced: {balanced}");

            // 2nd case
            input = "(1 + 2";
            balanced = checker.IsBalanced(input);
            Console.WriteLine($"Expression: '{input}' , Is Balanced: {balanced}");

            // 3rd case
            input = "((1 + 2)";
            balanced = checker.IsBalanced(input);
            Console.WriteLine($"Expression: '{input}' , Is Balanced: {balanced}");

            // 4th case
            input = "(1 + 2>";
            balanced = checker.IsBalanced(input);
            Console.WriteLine($"Expression: '{input}' , Is Balanced: {balanced}");

            // 5th case
            input = ")1 + 2(";
            balanced = checker.IsBalanced(input);
            Console.WriteLine($"Expression: '{input}' , Is Balanced: {balanced}");

            // 6th case
            input = "";
            balanced = checker.IsBalanced(input);
            Console.WriteLine($"Expression: '{input}' , Is Balanced: {balanced}");

            // 7th case
            input = "[1 , 6]";
            balanced = checker.IsBalanced(input);
            Console.WriteLine($"Expression: '{input}' , Is Balanced: {balanced}");
        }

        static void TestStack()
        {
            try
            {
                var st = new Stack<int>();
                for (int i = 1; i < 11; i++)
                {
                    st.Push(i * 10);
                }
                Console.WriteLine(st);
                Console.WriteLine($"stack size : {st.Count}");
                var top = st.Pop();
                Console.WriteLine(st);
                Console.WriteLine($"Top: {top}, stack size : {st.Count}");
                Console.WriteLine($"stack size : {st.Count}");
                top = st.Peek();
                Console.WriteLine(st);
                Console.WriteLine($"Top: {top}, stack size : {st.Count}");
                Console.WriteLine($"stack size : {st.Count}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void TestPriorityQueue()
        {
            var queue = new PriorityQueue<int>(3);
            queue.Add(6);
            queue.Add(7);
            queue.Add(2);
            queue.Add(4);
            Console.WriteLine(queue);
            queue.Remove();
            queue.Remove();
            Console.WriteLine(queue);
            queue.Remove();
            queue.Remove();
            Console.WriteLine(queue.IsEmpty);

        }

        static void TestCharFinder()
        {
            var finder = new CharFinder();
            var ch = finder.FindFirstNonRepeating("a green apple");
            Console.WriteLine($"First non repeating char: {ch}");

            ch = finder.FindFirstRepeating("a green apple");
            Console.WriteLine($"First repeating char: {ch}");
        }

        static void TestBinarySearchTree()
        {
            var tree = new BinarySearchTree<int>();
            tree.Insert(7);
            tree.Insert(4);
            tree.Insert(1);
            tree.Insert(9);
            tree.Insert(10);
            tree.Insert(8);
            tree.Insert(6);
            //tree.Insert(-15);
            //tree.Insert(-50);
            //tree.Insert(30);

            //Console.WriteLine($"{tree.Contains(8)}");
            //Console.WriteLine($"{tree.Contains(-20)}");
            //BinarySearchTreeTraversalHelper traversalHelper = new BinarySearchTreeTraversalHelper();

            //Console.WriteLine("Testing Traversing - InOrder Reversed method - using recursion");
            //traversalHelper.TraverseInOrderReversed(tree.Root, Console.WriteLine);
            //Console.WriteLine("Testing Traversing - PostOrder method - using recursion");
            //traversalHelper.TraversePostOrder(tree.Root, Console.WriteLine);

            Console.WriteLine($"Tree Height: {tree.Height()}");
            Console.WriteLine($"Empty Tree Height: {new BinarySearchTree<int>().Height()}");

            Console.WriteLine($"Tree Min Val - Tree processed As Normal Binary Tree: {tree.CalculateMinAsBinaryTree()}");
            Console.WriteLine($"Tree Min Val - Tree processed As Binary Search Tree: {tree.CalculateMinAsBinarySearchTree()}");
        }

        private static void TestQuickSort()
        {
            var sort = new QuickSort<int>();
            Console.WriteLine("array with many elements");
            int[] array = new[] {7, 5, -5, 3, 0, 9, 4, 2, 1};
            Print(array);
            sort.Sort(array);
            Console.WriteLine("after quick sort");
            Print(array);

            Console.WriteLine("array size : 2");
            array = new[] { 7, 5 };
            Print(array);
            sort.Sort(array);
            Console.WriteLine("after quick sort");
            Print(array);

            Console.WriteLine("array size : 0");
            array = new int[0];
            Print(array);
            sort.Sort(array);
            Console.WriteLine("after quick sort");
            Print(array);
        }

        private static void Print(int[] array)
        {
            int length = array.Length;
            for (int i = 0; i < length; ++i)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
