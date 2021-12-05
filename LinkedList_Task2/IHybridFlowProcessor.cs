namespace LinkedList_Task2
{
    public interface IHybridFlowProcessor<T>
    {
        void Push(T data);
        T Pop();
        void Enqueue(T data);
        T Dnqueue();
    }
}
