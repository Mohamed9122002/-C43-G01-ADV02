using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Cryptography;
using System.Collections;
using System;
using static System.Net.Mime.MediaTypeNames;
using System.Net.NetworkInformation;
using System.Xml.Linq;
using Microsoft.VisualBasic;

namespace AssignmentSession02C_Advanced
{
    internal class Program
    {
        public static bool IsBalanced(string input)
        {
            Stack<char> stack = new Stack<char>();
            foreach (char ch in input)
            {
                if (ch == '(' || ch == '{' || ch == '[')
                {
                    stack.Push(ch);
                } else if (ch == ')' || ch == '}'|| ch == ']' )
                {
                    char open = stack.Pop();
                    if (
                        (ch == ')' && open == '(') || 
                        ( ch == '}' && open == '{' ) ||
                        (ch == ']' && open == '[')
                        )
                        return true;
                }
            }
           return stack.Count == 0;
        }
        public static void PushAndSearch(Stack<int> stack, int traget)
        {
            int[] arrary =  stack.ToArray();
            Array.Sort(arrary);
            int index = Array.BinarySearch(arrary, traget);
            Console.WriteLine(index);
            // ليه؟ index = -1 
            // 
            if (index >= 0)
                Console.WriteLine($"Target was found successfully and the count = {index+1}");
            else
                Console.WriteLine("Target was not found");
        }
        public static int[] Intersection(int[] numbers1 , int[] numbers2)
        {
            Array.Sort(numbers1);
            Array.Sort(numbers2);
            List<int> result = new List<int>();
            
            int i = 0;
            int j = 0;
            while (i < numbers1.Length && j < numbers2.Length)
            {
                if (numbers1[i] == numbers2[j])
                {
                    result.Add(numbers1[i]);
                    i++;
                    j++;
                }
                else if (numbers1[i] < numbers2[j])
                {
                    i++;
                }
                else
                {
                    j++;
                }
            }
            return result.ToArray();
        }

        public static List<int> FindNumbers(ArrayList numbers, int target)
        {
            int currentSum = 0;
            int start = 0;
            List<int> result = new List<int>();

            for (int i = 0; i < numbers.Count; i++)
            {
                currentSum += (int)numbers[i];

                while (currentSum > target && start <= i)
                {
                    currentSum -= (int)numbers[start];
                    start++;
                }

                if (currentSum == target)
                {
                    for (int j = i; j <= j; j++)
                    {
                        result.Add((int)numbers[i]);
                    }
                    return result;
                }
            }

            return result;
        }
        public static Queue<int> ReverseKElements(Queue<int> queue, int k)
        {
            if (queue is null || k <= 0 || k > queue.Count)
            {
                return queue;
            }
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < k; i++)
            {
                stack.Push(queue.Dequeue());
            }
            while (stack.Count > 0)
            {
                queue.Enqueue(stack.Pop());
            }
            for (int i = 0; i < queue.Count - k; i++)
            {
                queue.Enqueue(queue.Dequeue());
            }
            return queue;
        }
            static void Main(string[] args)
        {
            #region Question01
            //1.Given an array  consists of  numbers with size N and number of queries, in each
            //    query you will be given an integer X, and you should print
            //    how many numbers in array that is greater than  X
            //
            //List<int > numbersQueries = new List<int> {11,5,3};
            // int number;
            // Console.WriteLine("Please Enter Number");
            // do
            // {
            //     Console.WriteLine("Please Enter a valid number");     
            // } while (!int.TryParse(Console.ReadLine(),out  number ));

            // int count = 0;
            // for (int i = 0; i < numbersQueries.Count; i++)
            // {
            //     if (numbersQueries[i] > number)
            //     {
            //        count++;
            //    Console.WriteLine($"Count ${count}");
            //    }
            //}

            #endregion

            #region Question02
            //2.Given a number N and an array of N numbers.Determine if it's palindrome or not.
            //int number;
            //do
            //{
            //    Console.WriteLine("Please Enter Counter Element Valid");
            //}
            //while (!int.TryParse(Console.ReadLine(),out number ));
            //List<int> numbers = new List<int>();
            //Console.WriteLine("Enter List Element numbers ");
            //for (int i = 0; i < number; i++)
            //{
            //    numbers.Add(int.Parse(Console.ReadLine() ?? "0"));
            //}
            //bool palindrome = false;
            //for (int i = 0; i < number /2 ; i++)
            //{
            //    if (numbers[i] == numbers[number - i -1 ])
            //    {   
            //        palindrome = true;
            //        break;
            //    }
            //}
            //if ( palindrome)
            //    Console.WriteLine("yes");
            //else
            //    Console.WriteLine("No");


            #endregion

            #region Question03
            //3.Given a Queue, implement a function to reverse the elements of a 
            //    queue using a stack
            //Queue<int> q = new Queue<int>();
            //q.Enqueue(1);
            //q.Enqueue(2);
            //q.Enqueue(3);
            //Console.WriteLine("Before Queue Reverse");
            //foreach(int item in q)
            //{
            //    Console.WriteLine(item);
            //}
            //Stack<int> Stack = new Stack<int>();
            //while (q.Count > 0)
            //{
            //   Stack.Push(q.Dequeue());
            //}
            //////foreach (int item in Stack)
            //////{
            //////    Console.WriteLine(item);
            //////}
            //while (Stack.Count > 0)
            //{
            //    q.Enqueue(Stack.Pop());
            //}
            //Console.WriteLine("After Queue Reverse");
            //foreach (int item in q)
            //{
            //    Console.WriteLine(item);
            //}

            #endregion
            #region Question04
            //4.Given a Stack, implement a function to check if a string of parentheses is balanced using a stack
            //Console.Write("Enter a string of parentheses: ");
            //string input = Console.ReadLine();

            //if (IsBalanced(input))
            //    Console.WriteLine("Balanced");
            //else
            //    Console.WriteLine("Not Balanced");
            #endregion
            #region Question05
            //5.Given an array, implement a function to remove duplicate elements from an array
            //int[] numbers = { 1, 1,2, 3,3, 4, 5, 6, 7, 8, 9, 1, 2, 3, 4 };
            // List<int> distinctNumbers = new List<int>();
            // foreach (int number in numbers)
            // {
            //     if (!distinctNumbers.Contains(number))
            //     {
            //         distinctNumbers.Add(number);
            //     }
            // }
            // foreach (int number in distinctNumbers)
            // {
            //     Console.WriteLine(number);
            // }

            #endregion
            #region Question06
            //6.Given an array list , implement a function to remove all odd numbers from it.

            //List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            //List<int> evenNumbers = new List<int>();
            //foreach (int number in numbers)
            //{
            //    if (number % 2 == 0)
            //    {
            //        evenNumbers.Add(number);
            //    }
            //}
            //foreach (int number in evenNumbers)
            //{
            //    Console.WriteLine(number);
            //}
            #endregion

            #region Question07
            //Implement a queue that can hold different data types.
            //And insert the following data:
            //Queue queue = new Queue();
            //queue.Enqueue(1);
            //queue.Enqueue("Apple");
            //queue.Enqueue(5.28);
            //Console.WriteLine("---------------");
            // Must Be Use Keyword Var not Use Int throw InvalidCastException 
            //foreach (int item in queue)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion
            #region Quesion08
            //Create a function that pushes a series of integers onto a stack. 
            //    Then, search for a target integer in the stack.
            //    If the target is found, print a message indicating that 
            //    the target was found how many elements were checked before finding the
            //    target(“Target was found successfully and the count = 5”)
            //    .If the target is not found, print a message indicating that
            //        the target was not found(“Target was not found”).
            //Note : take the target as input from the user
            // 
            //Stack<int> stack = new Stack<int>();
            //Console.WriteLine("Please Enter Numbers push on the Stack ");
            //string [] input = Console.ReadLine().Split();
            //foreach (var item in input)
            //{
            //    stack.Push(int.Parse(item));
            //}
            //Console.WriteLine("------");
            //foreach (int item in stack)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine("Please Enter The Target Integer To Search  ");
            //int NumberSearch = int.Parse(Console.ReadLine());
            //PushAndSearch(stack, NumberSearch);
            #endregion
            #region Question09
            //Given two arrays, find their intersection.Each element in the
            //    result should appear as many times as it shows in both arrays
            //int[] nums2 = { 2,1 };
            //int[] nums1 = { 1,  2, 1 };


            //int[] result = Intersection(nums1, nums2);


            //Console.WriteLine("Intersection of arrays:");
            //foreach (int num in result)
            //{
            //    Console.Write(num + " ");
            //}

            #endregion

            #region Question10
            //Given an ArrayList of integers and a target sum, find if there is a 
            //    contiguous sub list that sums up to the target.
            //ArrayList = 1,2,3,4,5
            // عايز ارجع ارقام مجموعها 12
            //ArrayList numbers = new ArrayList { 1, 2, 3, 4, 5 };
            //int target = 12;
            //List<int> sublist = FindNumbers(numbers, target);

            //if (sublist.Count > 0)
            //{
            //    Console.WriteLine("Contiguous sublist that sums up to the target:");
            //    foreach (int num in sublist)
            //    {
            //        Console.Write(num + " ");
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("No contiguous sublist found that sums up to the target.");
            //}
            #endregion

            #region Question11
            //11.Given a queue reverse first K elements of a queue, keeping the remaining elements in the same order
            // input -> [1,2,3,4,5,6]
            // k = 3
            // output -> [3,2,1,4,5,6]
            //Queue<int> queue = new Queue<int>([ 1, 2, 3, 4, 5 ]);
            //int k = 3;

            //Queue<int> reversedQueue = ReverseKElements(queue, k);

            //Console.WriteLine("Reversed Queue:");
            //foreach (int item in reversedQueue)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion
        }
    }
}
