using DoublyLinkedList.DoublyLinkedListMethods;
namespace DoublyLinkedList.Main
{
    internal class Test
    {
        static void Main() 
        {
            DoublyLinkedListMethods<int> list1 = new();
            list1.AddToEnd(3);
            DoublyLinkedListMethods<int> list2 = new();
            list2.AddToEnd(2);
            list1.InsertCollection(0, list2);
            list1.PrintList();


        }
    }
}
