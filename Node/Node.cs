namespace DoublyLinkedList
{
    public  class DoublyLinkedList<T>
    {
        private class Node
        {
            public Node(T data)
            {
                next = null;
                Data = data;
            }

            private Node? next;
            public Node? Next
            {
                get { return next; }
                set { next = value; }
            }

            public Node? previos;
            public Node? Previous
            {
                get { return previos; }
                set { previos = value; }
            }
            private T data;

            public T Data
            {
                get { return data; }
                set { data = value; }
            }

        }
        
        private Node? head;
        private Node? tail;
        int Count;
        public DoublyLinkedList()
        {
            head = null;
            tail = null;
            Count = 0;
        }
        public void AddToEnd(T data)
        {
            Node node = new(data);

            if (Count == 0) { head = node; }
            else
            {
                tail.Next = node;
                node.Previous = tail;
            }

            tail = node;
            Count++;
        }
        public void AddToStart(T data)
        {
            Node node = new(data);
            Node temp = head;

            head = node;
            head.Next = temp;
            if (Count == 0) { tail = head; }
            else { temp.Previous = head; }
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
                Count++;
                if (index >= Count || index < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(index), "The index is out of bounds!");
                }
                Node node = new(data);
                int currentIndex = 0;
                Node currentItem = head;
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
            Node current = head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    if (previous != null)
                    {
                        previous.Next = current.Next;
                        if (current.Next == null) { tail = previous; }
                        else { current.Next.previos = previous; }
                        Count--;
                    }

                    else
                    {
                        head = head.Next;
                        Count--;
                        if (Count == 0) { tail = null; }
                        else { head.previos = null; }
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
            Node temp = head;
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
            Node current = head;
            while (current != null)
            {
                temp = current.Previous;
                current.Previous = current.Next;
                current.Next = temp;
                current = current.Previous;
            }
            if (temp != null)
            {
                head = temp.Previous;
            }
        }
        public void SortList()
        {
            if (head == null)
            {
                return;
            }
            else
            {
                for (Node current = head; current.Next != null; current = current.Next)
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
            Node? current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
        public void PrintList()
        {
            Node first = head;
            while (first != null)
            {
                Console.Write(first.Data + " ");
                first = first.Next;
            }
        }
    }
}