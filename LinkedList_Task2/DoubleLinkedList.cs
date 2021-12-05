namespace LinkedList_Task2
{
    using System;

    public class DoubleLinkedList<T>
    {
        public DoubleLLItem<T> Head { get; set; }
        public DoubleLLItem<T> Tail { get; set; }
        public int Count { get; set; }

        public DoubleLinkedList() { }

        public DoubleLinkedList(T data)
        {
            Init(data);
        }

        public void Add(T data)
        {
            if(Count == 0)
            {
                Init(data);
            }
            else
            {
                var item = new DoubleLLItem<T>(data);
                Tail.Next = item;
                item.Previous = Tail;
                Tail = item;
                Count++;
            }
            
        }

        public void Remove(T data)
        {
            if (Head != null)
            {
                if (Head.Data.Equals(data))
                {
                    Head = Head.Next;
                    Count--;
                    return;
                }

                var current = Head;

                while (current != null)
                {
                    if (current.Data.Equals(data))
                    {
                        current.Previous.Next = current.Next;
                        current.Next.Previous = current.Previous;
                        Count--;
                        return;
                    }

                    current = current.Next;
                }
            }
            else
            {
                throw new InvalidOperationException("List doesn't contain data.It impossible to delete an item.");
            }
        }
        public T Pop()
        {
            var item = Tail;
            Tail = Tail.Previous;
            if (Tail != null)
            {
                Tail.Next = null;
            }
            Count--;
            return item.Data;
        }

        public T Dnqueue()
        {
            var item = Head;
            Head = Head.Next;
            if (Head != null)
            {
                Head.Previous = null;
            }
            Count--;
            return item.Data;
        }

        private void Init(T data)
        {
            var item = new DoubleLLItem<T>(data);
            Head = item;
            Tail = item;
            Count = 1;
        }
    }
}
