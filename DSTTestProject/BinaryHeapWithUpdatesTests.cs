using DataStructuresAndAlgorithms.Tree;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace DSTTestProject
{
    [TestClass]
    public class BinaryHeapWithUpdatesTests
    {
        private BinaryHeapWithUpdates<int> _heap;
        [TestInitialize]
        public void TestInitialize()
        {
            _heap = new BinaryHeapWithUpdates<int>();
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
        public void CanDecreaseKeyValue()
        {
            var initialValue = 6;
            var increasedValue = 3;
            var indexBeforeUpdate = _heap.Key(initialValue);
            _heap.Update(initialValue, increasedValue);
            var indexAfterUpdate = _heap.Key(increasedValue);
            var minValue = _heap.Peek();
            Assert.AreEqual(increasedValue, minValue);
            Assert.AreNotEqual(indexBeforeUpdate,indexAfterUpdate);
        }

        [TestMethod]
        public void CanIncreaseKeyValue()
        {
            var initialValue = 5;
            var increasedValue = 10;
            var indexBeforeUpdate = _heap.Key(initialValue);
            _heap.Update(initialValue, increasedValue);
            var indexAfterUpdate = _heap.Key(increasedValue);


            Assert.AreNotEqual(indexBeforeUpdate, indexAfterUpdate);
            
        }
    }
}
