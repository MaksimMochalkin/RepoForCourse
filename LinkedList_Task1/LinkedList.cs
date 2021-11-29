namespace LinkedList_Task1
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class LinkedList<T> : IEnumerable
    {
        public Item<T> Head { get; private set; }

        public Item<T> Tail { get; private set; }

        public int Count { get; private set; }

        public LinkedList()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        public LinkedList(T data)
        {
            Init(data);
        }

        public void Add(T data)
        {
            if (Tail != null)
            {
                var item = new Item<T>(data);
                Tail.Next = item;
                Tail = item;
                Count++;
            }
            else
                Init(data);
        }

        public void AddAt(T target, T data)
        {
            if (Head != null)
            {
                var current = Head;
                while(current != null)
                {
                    if (current.Data.Equals(target))
                    {
                        var item = new Item<T>(data);
                        item.Next = current.Next;
                        current.Next = item;
                        Count++;
                        return;
                    }
                    else
                    {
                        current = current.Next;
                    }
                }
            }
            else
            {
                Init(target);
                Add(data);
            }
        }

        public void Remove(T data)
        {
            if (Head != null)
            {
                if(Head.Data.Equals(data))
                {
                    Head = Head.Next;
                    Count--;
                    return;
                }

                var current = Head.Next;
                var previous = Head;

                while(current != null)
                {
                    if (current.Data.Equals(data))
                    {
                        previous.Next = current.Next;
                        Count--;
                        return;
                    }

                    previous = current;
                    current = current.Next;
                }
            }
            else
            {
                throw new InvalidOperationException("List doesn't contain data.It impossible to delete an item.");
            }
        }

        public void RemoveAt(T start, T end)
        {
            if (Head != null)
            {
                if (Head.Data.Equals(start))
                {
                    var endItem = Head.Next;
                    while(endItem != null)
                    {
                        if(endItem.Data.Equals(end))
                        {
                            Head.Next = endItem;
                            return;
                        }
                        endItem = endItem.Next;
                        Count--;
                    }
                }

                var startItem = Head.Next;
                while(startItem != null)
                {
                    if (startItem.Data.Equals(start))
                    {
                        var nextItem = startItem.Next;
                        while (nextItem != null)
                        {
                            if (nextItem.Data.Equals(end))
                            {
                                startItem.Next = nextItem;
                                return;
                            }

                            nextItem = nextItem.Next;
                            Count--;
                        }
                    }

                    startItem = startItem.Next;
                }
            }
            else
            {
                throw new InvalidOperationException("List doesn't contain data.It impossible to delete an item.");
            }
        }

        public T ElementAt(T data)
        {
            if (Head != null)
            {
                if (Head.Data.Equals(data))
                {
                    return Head.Data;
                }

                var current = Head;
                while(current != null)
                {
                    if (current.Data.Equals(data))
                        return current.Data;

                    current = current.Next;
                }

                return default(T);
            }
            else
            {
                throw new InvalidOperationException("List doesn't contain data.");
            }
        }

        public IEnumerator GetEnumerator()
        {
            return new LinkedLIstEnumerator<T>(Head);
            //var current = Head;
            //while(current != null)
            //{
            //    return current.Data;
            //    current = current.Next;
            //}

            //return null;
        }
        private void Init(T data)
        {
            var item = new Item<T>(data);
            Head = item;
            Tail = item;
            Count = 1;
        }
    }

    public class LinkedLIstEnumerator<T> : IEnumerator<Item<T>>
    {
        private Item<T> head;

        public Item<T> Current { get; private set; }

        object IEnumerator.Current => Current;

        public LinkedLIstEnumerator(Item<T> item)
        {
            Current = item;
            head = item;
        }
        public void Dispose()
        {
            
        }

        public bool MoveNext()
        {
            if(Current.Next != null)
            {
                Current = Current.Next;
                return true;
            }

            return false;
        }

        public void Reset()
        {
            Current = head;
        }
    }
}
