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


        // сортировка по возрастанию
        [TestCase(new int[] { 1, 2, 3, 4, 5, 7 }, new int[] { 5, 4, 2, 3, 1, 7}, true)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 7 }, new int[] { 2, 4, 5, 3, 7, 1 }, true)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 7 }, new int[] { 4, 2, 5, 1, 7, 3 }, true)]
        [TestCase(new int[] { 1, 1, 2, 3, 4 }, new int[] { 1, 2, 1, 3,4 }, true)]
        [TestCase(new int[] { 1 }, new int[] { 1 }, true)]
        [TestCase(new int[] { }, new int[] { }, true)]

        // по убыванию
        [TestCase(new int[] { 7, 5, 4, 3, 2, 1 }, new int[] { 5, 4, 2, 3, 1, 7 }, false)]
        [TestCase(new int[] { 7, 5, 4, 3, 2, 1 }, new int[] { 2, 4, 5, 3, 7, 1 }, false)]
        [TestCase(new int[] { 7, 5, 4, 3, 2, 1 }, new int[] { 4, 2, 5, 1, 7, 3 }, false)]
        [TestCase(new int[] { 4, 3, 2, 1, 1 }, new int[] { 1, 2, 1, 3, 4 }, false)]
        [TestCase(new int[] { 1 }, new int[] { 1 }, false)]
        [TestCase(new int[] { }, new int[] { }, false)]

        public void SortTest(int[] expectedArray, int[] array, bool ascending)
        {
            LinkedList actual = new LinkedList(array);
            LinkedList expected = new LinkedList(expectedArray);

            actual.Sort(ascending);
            Assert.AreEqual(expected, actual);
        }

        // удаление по значению первого
        [TestCase(new int[] { 5, 4, 3, 1, 7 }, new int[] { 5, 4, 4, 3, 1, 7 }, 4)]
        [TestCase(new int[] { 2, 1, 3, 4 }, new int[] { 1, 2, 1, 3, 4 }, 1)]
        [TestCase(new int[] { 1, 2, 1, 3 }, new int[] { 1, 2, 1, 3, 4 }, 4)]
        [TestCase(new int[] { }, new int[] { 1 }, 1)]

        public void DeleteFirstByValueTest(int[] expectedArray, int[] array, int value)
        {
            LinkedList actual = new LinkedList(array);
            LinkedList expected = new LinkedList(expectedArray);

            actual.DeleteFirstByValue(value);
            Assert.AreEqual(expected, actual);
        }


        [TestCase(new int[] { }, 67, "InvalidOperationException")]
        [TestCase(new int[] { 1, 2, 3 }, 67, "ArgumentOutOfRangeException")]
        public void DeleteFirstByValueNegativeTest(int[] array, int value, string exception)
        {
            LinkedList list = new LinkedList(array);
            switch (exception)
            {
                case "InvalidOperationException":
                    Assert.Throws<InvalidOperationException>(() => list.DeleteFirstByValue(value));
                    break;
                case "ArgumentOutOfRangeException":
                    Assert.Throws<ArgumentOutOfRangeException>(() => list.DeleteFirstByValue(value));
                    break;
                default:
                    break;
            }
        }

        // удаление по значению всех
        [TestCase(new int[] { 5, 3, 1, 7 }, new int[] { 5, 4, 4, 3, 1, 7 }, 4)]
        [TestCase(new int[] { 2, 3, 4 }, new int[] { 1, 2, 1, 1, 1, 3, 4 }, 1)]
        [TestCase(new int[] { 2, 3, 4 }, new int[] { 1, 2, 1, 3, 4, 1, 1}, 1)]
        [TestCase(new int[] { }, new int[] { 1, 1, 1 }, 1)]

        public void DeleteAllByValueTest(int[] expectedArray, int[] array, int value)
        {
            LinkedList actual = new LinkedList(array);
            LinkedList expected = new LinkedList(expectedArray);

            actual.DeleteAllByValue(value);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { }, 67, "InvalidOperationException")]
        [TestCase(new int[] { 1, 2, 3 }, 67, "ArgumentOutOfRangeException")]
        public void DeleteAllByValueNegativeTest(int[] array, int value, string exception)
        {
            LinkedList list = new LinkedList(array);
            switch (exception)
            {
                case "InvalidOperationException":
                    Assert.Throws<InvalidOperationException>(() => list.DeleteAllByValue(value));
                    break;
                case "ArgumentOutOfRangeException":
                    Assert.Throws<ArgumentOutOfRangeException>(() => list.DeleteAllByValue(value));
                    break;
                default:
                    break;
            }
        }


        // добавление массива в конец

        [TestCase(new int[] { 1, 2, 2, 3 }, new int[] { 1, 2 }, new int[] {2, 3})]
        [TestCase(new int[] { 4, 5 }, new int[] { }, new int[] { 4, 5})]
        [TestCase(new int[] { 4, 5 }, new int[] {4, 5 }, new int[] {})]
        [TestCase(new int[] { }, new int[] { }, new int[] { })]
        public void AppendArrayTest(int[] expectedArray, int[] array, int[] values)
        {
            LinkedList actual = new LinkedList(array);
            LinkedList expected = new LinkedList(expectedArray);

            actual.Append(values);
            Assert.AreEqual(expected, actual);

        }

        // добавление массива по индексу
        [TestCase(new int[] { 1, 4, 5, 2, 3 }, new int[] { 1, 2, 3 }, new int[] {4, 5}, 1)]
        [TestCase(new int[] { 1, 2, 4, 5, 3 }, new int[] { 1, 2, 3 }, new int[] { 4, 5 }, 2)]
        [TestCase(new int[] { 2, 3, 1 }, new int[] { 1 }, new int[] { 2, 3 }, 0)]

        public void InsertArrayTest(int[] expectedArray, int[] array, int[] values, int index)
        {
            LinkedList actual = new LinkedList(array);
            LinkedList expected = new LinkedList(expectedArray);

            actual.Insert(values, index);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2 }, new int[] { 1, 2, 3}, 5)]
        [TestCase(new int[] { 1, 2 }, new int[] { 1, 2, 3 }, -1)]
        public void InsertArrayTestNegative(int[] array, int[] values, int index)
        {
            LinkedList list = new LinkedList(array);
            Assert.Throws<ArgumentOutOfRangeException>(() => list.Insert(values, index));
        }



        // удаление из конца N элементов
        [TestCase(new int[] { 1 }, new int[] { 1, 2, 3, 4, 5 }, 4)]
        [TestCase(new int[] { 1, 2 }, new int[] { 1, 2, 3, 4, 5 }, 3)]
        [TestCase(new int[] { }, new int[] { 1, 2, 3, 4, 5 }, 5)]

        public void DeleteLastTest(int[] expectedArray, int[] array, int N)
        {
            LinkedList actual = new LinkedList(array);
            LinkedList expected = new LinkedList(expectedArray);

            actual.DeleteLast(N);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3 }, 4)]
        public void DeleteLastNegativeTest(int[] array, int N)
        {
            LinkedList list = new LinkedList(array);
            Assert.Throws<ArgumentOutOfRangeException>(() => list.DeleteLast(N));
        }

        // удаление из по индексу N элементов
        [TestCase(new int[] { 1, 2, 7}, new int[] { 1, 2, 3, 4, 5, 6, 7 }, 4, 2)]
        [TestCase(new int[] { 5, 6, 7 }, new int[] { 1, 2, 3, 4, 5, 6, 7 }, 4, 0)]
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 1, 2, 3, 4, 5, 6, 7 }, 4, 3)]

        public void DeleteTest(int[] expectedArray, int[] array, int N, int index)
        {
            LinkedList actual = new LinkedList(array);
            LinkedList expected = new LinkedList(expectedArray);

            actual.Delete(N, index);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4 }, 3, 2)]
        public void DeleteNegativeTest(int[] array, int N, int index)
        {
            LinkedList list = new LinkedList(array);
            Assert.Throws<ArgumentOutOfRangeException>(() => list.Delete(N, index));
        }
    }
}
