namespace DoublyLinkedList.ListNode
{
    internal  class DoublyLinkedListNode<T>
    {
        internal class Node
        {
            public Node? Next { get; set; }
            public Node? Previous { get; set; }
            public T Data { get; set; }
            public Node(T data)
            {
                Next = null;
                Data = data;
            }
        }
    }
}
