namespace LinkedList_Task1.Tests
{
    using NUnit.Framework;
    using Shouldly;

    public class LinkedListTests
    {
        private LinkedList<int> list;

        [SetUp]
        public void Setup()
        {
            list = new LinkedList<int>();
        }

        [Test]
        public void Test1()
        {
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);
            list.Add(6);
            list.Count.ShouldBe(6);

            list.AddAt(4, 7);
            list.Count.ShouldBe(7);

            list.Remove(7);
            list.Count.ShouldBe(6);

            list.RemoveAt(2, 6);
            list.Count.ShouldBe(3);

            var result = list.ElementAt(2);
            result.ShouldBe(2);

            foreach (var item in list)
            {
                var temp = item;
            }

        }
    }
}