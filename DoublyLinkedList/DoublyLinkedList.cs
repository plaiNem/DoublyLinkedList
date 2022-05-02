namespace DoublyLinkedList.DoublyLinkedList
{
    internal class DoublyLinkedList<T> : ListNode.DoublyLinkedListNode<T>
    {
        internal Node? Head;
        internal Node? Tail;
        internal int Count;
        internal DoublyLinkedList()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }
        public void AddToEnd(T data)
        {
            Node node = new(data);

            if (Count == 0) { Head = node; }
            else
            {
                Tail.Next = node;
                node.Previous = Tail;
            }

            Tail = node;
            Count++;
        }
        public void AddToStart(T data)
        {
            Node node = new(data);
            Node temp = Head;

            Head = node;
            Head.Next = temp;
            if (Count == 0) { Tail = Head; }
            else { temp.Previous = Head; }
            Count++;
        }
        public void AddCollection(IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                AddToEnd(item);
                Count++;
            }
        }
        public void AddCollection(DoublyLinkedList<T> list)
        {
            foreach (var item in list)
            {
                AddToEnd(item);
                Count++;
            }
        }
        public void InsertItem(int index, T data)
        {
            {
                if (index >= Count || index < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(index), "The index is out of bounds!");
                }
                Node node = new(data);
                int currentIndex = 0;
                Node currentItem = Head;
                Node prevItem = null;
                while (currentIndex < index)
                {
                    prevItem = currentItem;
                    currentItem = currentItem.Next;
                    currentIndex++;
                }
                if (index == 0)
                {
                    AddToStart(data);
                }
                else if (index == Count - 1)
                {
                    AddToEnd(data);
                }
                else
                {
                    node.Next = prevItem.Next;
                    prevItem.Next = node;
                    currentItem.Previous = node;
                    node.Previous = currentItem.Previous;
                }
            }

        }
        public void InsertCollection(int index, DoublyLinkedList<T> list)
        {
            foreach (var item in list)
            {
                InsertItem(index, item);
            }
        }
        public void InsertCollection(int index, IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                InsertItem(index, item);
            }
        }
        public bool Remove(T data)
        {
            Node previous = null;
            Node current = Head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    if (previous != null)
                    {
                        previous.Next = current.Next;
                        if (current.Next == null) { Tail = previous; }
                        else { current.Next.Previous = previous; }
                        Count--;
                    }

                    else
                    {
                        Head = Head.Next;
                        Count--;
                        if (Count == 0) { Tail = null; }
                        else { Head.Previous = null; }
                    }
                    return true;
                }

                previous = current;
                current = current.Next;
            }
            return false;
        }
        public int FindIndex(T data)
        {
            int index = 0;
            Node temp = Head;
            while (temp.Data.Equals(data) == false && temp.Next != null)
            {
                index++;
                temp = temp.Next;
            }
            if (temp.Data.Equals(data) == false) { return -1; }
            else { return index; }
        }
        public void Reverse()
        {
            Node temp = null;
            Node current = Head;
            while (current != null)
            {
                temp = current.Previous;
                current.Previous = current.Next;
                current.Next = temp;
                current = current.Previous;
            }
            if (temp != null)
            {
                Head = temp.Previous;
            }
        }
        public void SortList()
        {
            if (Head == null)
            {
                return;
            }
            else
            {
                for (Node current = Head; current.Next != null; current = current.Next)
                {
                    for (Node index = current.Next; index != null; index = index.Next)
                    {
                        if (Comparer<T>.Default.Compare(current.Data, index.Data) > 0)
                        {
                            (current.Data, index.Data) = (index.Data, current.Data);
                        }
                    }
                }
            }
        }
        public void Clearlist()
        {
            foreach (T item in this)
            {
                Remove(item);
            }
        }
        public IEnumerator<T> GetEnumerator()
        {
            Node? current = Head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
        public void PrintList()
        {
            Node first = Head;
            while (first != null)
            {
                Console.Write(first.Data + " ");
                first = first.Next;
            }
        }
    }
}
