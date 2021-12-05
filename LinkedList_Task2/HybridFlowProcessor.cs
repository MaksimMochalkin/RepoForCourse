using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedList_Task2
{
    public class HybridFlowProcessor<T> : IHybridFlowProcessor<T>
    {
        private DoubleLinkedList<T> _list;

        public int Count { get { return _list.Count;} }

        public HybridFlowProcessor()
        {
            _list = new DoubleLinkedList<T>();
        }
        public T Dnqueue()
        {
            return _list.Dnqueue();
        }

        public void Enqueue(T data)
        {
            _list.Add(data);
        }

        public T Pop()
        {
            return _list.Pop();
        }

        public void Push(T data)
        {
            _list.Add(data);
        }
    }
}
