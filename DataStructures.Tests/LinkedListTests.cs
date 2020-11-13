using System;
using System.Text;
using DataStructures.LinkedLists;
using NUnit.Framework;

namespace DataStructures.Tests
{
    class LinkedListTests
    {
        // добавление значения в конец
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 1, 2 }, 3)]
        [TestCase(new int[] { 3 }, new int[] { }, 3)]

        public void AppendTest(int[] expectedArray, int[] array, int value)
        {
            LinkedList actual = new LinkedList(array);
            LinkedList expected = new LinkedList(expectedArray);

            actual.Append(value);
            Assert.AreEqual(expected, actual);

        }

        // добавление значения по индексу
        [TestCase(new int[] { 3, 1, 2 }, new int[] { 1, 2 }, 3, 0)]
        [TestCase(new int[] { 1, 4, 2, 3 }, new int[] { 1, 2, 3 }, 4, 1)]
        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 3 }, 4, 3)]
        [TestCase(new int[] { 1 }, new int[] { }, 1, 0)]

        public void InsertTest(int[] expectedArray, int[] array, int value, int index)
        {
            LinkedList actual = new LinkedList(array);
            LinkedList expected = new LinkedList(expectedArray);

            actual.Insert(value, index);
            Assert.AreEqual(expected, actual);

        }

        [TestCase(new int[] { 1, 2, 3 }, 4, 5)]
        [TestCase(new int[] { 1, 2, 3 }, 4, -1)]
        public void InsertTestNegative(int[] array, int value, int index)
        {
            LinkedList list = new LinkedList(array);
            Assert.Throws<ArgumentOutOfRangeException>(() => list.Insert(value, index));
        }



        // удаление из конца
        [TestCase(new int[] { 1, 2 }, new int[] { 1, 2, 3 })]
        [TestCase(new int[] { }, new int[] { 1})]

        public void RemoveLastTest(int[] expectedArray, int[] array)
        {
            LinkedList actual = new LinkedList(array);
            LinkedList expected = new LinkedList(expectedArray);

            actual.RemoveLast();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] {})]
        public void RemoveLastTestNegative(int[] array)
        {
            LinkedList list = new LinkedList(array);
            Assert.Throws<NullReferenceException>(() => list.RemoveLast());
        }


        // удаление по индексу
        [TestCase(new int[] { 1, 2, 4 }, new int[] { 1, 2, 3, 4 }, 2)]
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 1, 2, 3, 4 }, 3)]
        [TestCase(new int[] { 2, 3, 4 }, new int[] { 1, 2, 3, 4 }, 0)]

        public void RemoveTest(int[] expectedArray, int[] array, int index)
        {
            LinkedList actual = new LinkedList(array);
            LinkedList expected = new LinkedList(expectedArray);

            actual.Remove(index);
            Assert.AreEqual(expected, actual);
        }


        [TestCase(new int[] { }, 4, "NullReferenceException")]
        [TestCase(new int[] {1, 2, 3 }, 4, "ArgumentOutOfRangeException")]
        [TestCase(new int[] { 1, 2, 3 }, -2, "ArgumentOutOfRangeException")]
        [TestCase(new int[] { 1, 2, 3 }, 3, "ArgumentOutOfRangeException")]
        public void RemoveTestNegative(int[] array, int index, string exception)
        {
            LinkedList list = new LinkedList(array);
            switch (exception)
            {
                case "NullReferenceException":
                    Assert.Throws<NullReferenceException>(() => list.Remove(index));
                    break;
                case "ArgumentOutOfRangeException":
                    Assert.Throws<ArgumentOutOfRangeException>(() => list.Remove(index));
                    break;
                default:
                    break;
            }
        }

        // индекс по значению
        [TestCase(2, new int[] { 1, 2, 3, 3, 4, }, 3)]
        public void GetIndexTest(int expected, int[] array, int value)
        {
            LinkedList list = new LinkedList(array);
            int actual = list.GetIndexOf(value);
            
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 3, 4, }, 6, "ArgumentOutOfRangeException")]
        [TestCase(new int[] {}, 0, "NullReferenceException")]
        public void GetIndexNegativeTest(int[] array, int value, string exception)
        {
            LinkedList list = new LinkedList(array);
            switch (exception)
            {
                case "NullReferenceException":
                    Assert.Throws<NullReferenceException>(() => list.GetIndexOf(value));
                    break;
                case "ArgumentOutOfRangeException":
                    Assert.Throws<ArgumentOutOfRangeException>(() => list.GetIndexOf(value));
                    break;
                default:
                    break;
            }
        }


        // реверс

        [TestCase(new int[] {5, 4, 3, 2, 1}, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] {4, 3, 2, 1}, new int[] { 1, 2, 3, 4})]
        [TestCase(new int[] { 1 }, new int[] { 1 })]
        [TestCase(new int[] { }, new int[] { })]

        public void ReverseTest(int[] expectedArray, int[] array)
        {
            LinkedList actual = new LinkedList(array);
            LinkedList expected = new LinkedList(expectedArray);

            actual.Reverse();
            Assert.AreEqual(expected, actual);
        }

        // максимум

        [TestCase(4, new int[] { 1, 2, 4, 3, 3, 4})]
        [TestCase(3, new int[] { 3 })]
        public void GetMaxTest(int expected, int[] array)
        {
            LinkedList list = new LinkedList(array);
            int actual = list.GetMax();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { })]
        public void GetMaxNegativeTest(int[] array)
        {
            LinkedList list = new LinkedList(array);
            Assert.Throws<NullReferenceException>(() => list.GetMax());
        }


        // минимум

        [TestCase(1, new int[] { 1, 2, 4, 3, 3, 1, 4 })]
        [TestCase(3, new int[] { 3 })]
        public void GetMinTest(int expected, int[] array)
        {
            LinkedList list = new LinkedList(array);
            int actual = list.GetMin();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { })]
        public void GetMinNegativeTest(int[] array)
        {
            LinkedList list = new LinkedList(array);
            Assert.Throws<NullReferenceException>(() => list.GetMin());
        }


        // поиск индекса максимального элемента

        [TestCase(2, new int[] { 1, 2, 4, 3, 3, 1, 4 })]
        [TestCase(5, new int[] { 1, 2, 4, 5, 3, 7, 4 })]
        [TestCase(0, new int[] { 3 })]
        public void GetMaxIndexTest(int expected, int[] array)
        {
            LinkedList list = new LinkedList(array);
            int actual = list.GetMaxIndex();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { })]
        public void GetMaxIndexNegativeTest(int[] array)
        {
            LinkedList list = new LinkedList(array);
            Assert.Throws<NullReferenceException>(() => list.GetMaxIndex());
        }


        // поиск индекса минимального элемента
        [TestCase(0, new int[] { 1, 2, 4, 3, 3, 1, 4 })]
        [TestCase(4, new int[] { 1, 2, 4, 3, 0, 1, 4 })]
        [TestCase(0, new int[] { 3 })]
        public void GetMinIndexTest(int expected, int[] array)
        {
            LinkedList list = new LinkedList(array);
            int actual = list.GetMinIndex();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { })]
        public void GetMinIndexNegativeTest(int[] array)
        {
            LinkedList list = new LinkedList(array);
            Assert.Throws<NullReferenceException>(() => list.GetMinIndex());
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 7 }, new int[] { 5, 4, 2, 3, 1, 7})]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 7 }, new int[] { 2, 4, 5, 3, 7, 1 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 7 }, new int[] { 4, 2, 5, 1, 7, 3 })]
        [TestCase(new int[] { 1, 1, 2, 3, 4 }, new int[] { 1, 2, 1, 3,4 })]
        [TestCase(new int[] { 1 }, new int[] { 1 })]
        [TestCase(new int[] { }, new int[] { })]

        public void SortAscendingTest(int[] expectedArray, int[] array)
        {
            LinkedList actual = new LinkedList(array);
            LinkedList expected = new LinkedList(expectedArray);

            actual.Sort();
            Assert.AreEqual(expected, actual);
        }

    }
}
