namespace LinkedList_Task2.Tests
{
    using NUnit.Framework;
    using Shouldly;

    public class DoubleLinkedListTests
    {
        private HybridFlowProcessor<int> processor;

        [SetUp]
        public void Setup()
        {
            processor = new HybridFlowProcessor<int>();
        }

        [Test]
        public void Test1()
        {
            processor.Push(1);
            processor.Push(2);
            processor.Push(3);
            processor.Count.ShouldBe(3);
            processor.Pop().ShouldBe(3);
            processor.Pop().ShouldBe(2);
            processor.Pop().ShouldBe(1);
            processor.Count.ShouldBe(0);

            processor.Enqueue(1);
            processor.Enqueue(2);
            processor.Enqueue(3);
            processor.Count.ShouldBe(3);
            processor.Dnqueue().ShouldBe(1);
            processor.Dnqueue().ShouldBe(2);
            processor.Dnqueue().ShouldBe(3);
            processor.Count.ShouldBe(0);
        }
    }
}