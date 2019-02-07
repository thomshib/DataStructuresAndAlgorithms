using DataStructuresAndAlgorithms.Tree;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DSTTestProject
{
    [TestClass]
    public class BinaryHeapTests
    {

        private BinaryHeap<int> _heap;
        [TestInitialize]
        public void TestInitialize()
        {
            _heap = new BinaryHeap<int>();
            _heap.Add(9);
            _heap.Add(6);
            _heap.Add(5);
        }

        [TestMethod]
        public void Get()
        {
            var minValue = _heap.Peek();
            var result = _heap.Remove();

            Assert.AreEqual(result, minValue);
        }

        [TestMethod]
        public void Add()
        {
            int value = 2;
            _heap.Add(value);

            var expectedResult = _heap.Peek();
            Assert.AreEqual(expectedResult, value);
        }

        [TestMethod]
        public void CanHandleDuplicateMinValue()
        {
            int value = 2;
            _heap.Add(value);
            _heap.Add(value);

            var expectedResult1 = _heap.Remove();
            var expectedResult2 = _heap.Remove();
            Assert.AreEqual(expectedResult1, value);
            Assert.AreEqual(expectedResult1, value);
        }



    }
}
