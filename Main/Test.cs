﻿using DoublyLinkedList.DoublyLinkedListMethods;
namespace DoublyLinkedList.Main
{
    internal class Test
    {
        static void Main() 
        {
            Console.WriteLine("Create two lists of type int:");
            DoublyLinkedListMethods<int> list1 = new();

            //Adding items to a list"
            list1.AddToEnd(15);
            list1.AddToEnd(2);

            //Adding items to the beginning of the list
            list1.AddToStart(96);
            list1.AddToStart(5);

            //And finally, let's display the list
            list1.PrintList();

            //Do the same with the second one and display it
            DoublyLinkedListMethods<int> list2 = new();
            list2.AddToEnd(40);
            list2.AddToEnd(62);
            list2.AddToStart(71);
            list2.AddToStart(38);
            list2.PrintList();

            Console.WriteLine("\n\nReverse first list:");
            list1.Reverse();
            list1.PrintList();

            Console.WriteLine("\n\nLet's insert the first list into the second, starting with index '2' and display the result:");
            list1.InsertCollection(2, list2);
            list1.PrintList();

            Console.WriteLine("\n\nRemove number 40");
            list1.Remove(40);
            list1.PrintList();

            Console.WriteLine("\n\nSort list");
            list1.SortList();
            list1.PrintList();

            Console.WriteLine($"\nFind the index of number 4 (it is not in the list): {list1.FindIndex(4)}");
            Console.WriteLine($"\nFind the iindex of number 62: {list1.FindIndex(62)}");
        }
    }
}
