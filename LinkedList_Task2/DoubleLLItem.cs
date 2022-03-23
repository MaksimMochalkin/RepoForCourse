namespace LinkedList_Task2
{
    using System;
    using System.Collections.Generic;
    using System.Text;


    public class DoubleLLItem<T>
    {
        public T Data { get; set; }
        public DoubleLLItem<T> Next { get; set; }
        public DoubleLLItem<T> Previous { get; set; }

        public DoubleLLItem(T data)
        {
            Data = data;
        }
    }
}
