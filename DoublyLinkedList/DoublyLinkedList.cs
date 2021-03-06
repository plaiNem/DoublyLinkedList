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
        public DoublyLinkedList<T> Add(T data)
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
            return this;
        }
        public DoublyLinkedList<T> AddToStart(T data)
        {
            Node node = new(data);
            Node temp = Head;

            Head = node;
            Head.Next = temp;
            if (Count == 0) { Tail = Head; }
            else { temp.Previous = Head; }
            Count++;
            return this;
        }
        public DoublyLinkedList<T> AddCollection(IEnumerable<T> collection)
        {
            foreach (T data in collection)
            {
                Add(data);
            }
            return this;
        }
        public DoublyLinkedList<T> AddCollection(DoublyLinkedList<T> list)
        {
            foreach (T data in list)
            {
                Add(data);
            }
            return this;
        }
        public DoublyLinkedList<T> Insert(int index, T data, string message)
        {

            if (index >= Count || index < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(index), message);
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
                return AddToStart(data);
            }
            else if (index == Count - 1)
            {
                return Add(data);
            }
            else
            {
                node.Next = prevItem.Next;
                prevItem.Next = node;
                currentItem.Previous = node;
                node.Previous = currentItem.Previous;
                Count++;
                return this;
            }
        }
        public DoublyLinkedList<T> InsertCollection(int index, DoublyLinkedList<T> list)
        {
            foreach (T data in list)
            {
                Insert(index, data, "The index is out of bounds!");
            }
            return this;
        }
        public DoublyLinkedList<T> InsertCollection(int index, IEnumerable<T> collection)
        {
            foreach (T data in collection)
            {
                Insert(index, data, "The index is out of bounds!");
            }
            return this;
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
        public bool RemoveAt(int index)
        {
            int marker = 0;
            Node previous = null;
            Node current = Head;
            while (current != null)
            {
                if (marker == index)
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

                marker++;
                previous = current;
                current = current.Next;
            }
            return false;
        }

        public int IndexOf(T data)
        {
            Node temp = Head;
            int index = 0;
            while (temp != null)
            {
                if (temp.Data.Equals(data)) return index;
                temp = temp.Next;
                index++;
            }
            return -1;
        }
        public bool Contains(T data)
        {
            if (IndexOf(data) == -1) return false;
            else return true;
        }

        public void Reverse()
        {
            Node temp = Head;
            Node node = temp.Next;
            temp.Next = null;
            temp.Previous = node;
            while (node != null)
            {
                node.Previous = node.Next;
                node.Next = temp;
                temp = node;
                node = node.Previous;
                Head = temp;
            }
        }
        public void Sort()
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

        public void Clear()
        {
            foreach (T data in this)
            {
                Remove(data);
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
            Node temp = Head;
            while (temp != null)
            {
                Console.Write(temp.Data + " ");
                temp = temp.Next;
            }
        }
    }
}
