using DoublyLinkedList.DoublyLinkedList;
namespace DoublyLinkedList.Main
{
    internal static class Test
    {
        static void Main()
        {
            Console.WriteLine("Create two lists of type int:");
            DoublyLinkedList<int> list1 = new();

            //Adding items to a list
            list1.Add(15); // head -> 15 <- tail
            list1.Add(2); // head -> 15 <-> 2 <- tail

            //Adding items to the beginning of the list
            list1.AddToStart(96); // head -> 96 <-> 15 <-> 2 <- tail
            list1.AddToStart(5);  // head -> 5 <-> 96 <-> 15 <-> 2 <- tail

            //And finally, let's display the list
            list1.PrintList();

            Console.WriteLine();

            //Do the same with the second one and display it
            DoublyLinkedList<int> list2 = new();
            //It's possible to write AddToStart/AddToEnd/AddCollection/InsertItem/InsertCollection methods in a chain
            list2.Add(40).Add(62);
            list2.AddToStart(71).AddToStart(38);
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


            Console.WriteLine("\n\nRemove number with index 3");
            list1.RemoveAt(3);
            list1.PrintList();

            Console.WriteLine("\n\nSort list");
            list1.Sort();
            list1.PrintList();

            Console.WriteLine($"\n\nContains method returns true if item(number 75 in this case) is in the list: {list1.Contains(75)}");

            Console.WriteLine($"\nFind the index of number 4 (it is not in the list): {list1.IndexOf(4)}");
            Console.WriteLine($"\nFind the index of number 62: {list1.IndexOf(62)}");
        }
    }
}
