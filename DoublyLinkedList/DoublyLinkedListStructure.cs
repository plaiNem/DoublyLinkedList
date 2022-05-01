namespace DoublyLinkedList.DoublyLinkedListStructure
{
    internal class DblyLnkLstStructure<T> : ListNode.DoublyLinkedListNode<T>
    {
        internal Node? Head;
        internal Node? Tail;
        internal int Count;
        internal DblyLnkLstStructure()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }       
    }
}
