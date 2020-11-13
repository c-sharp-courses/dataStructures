using NUnit.Framework;
using System;
using DataStructures;

namespace DataStructures.Tests
{
    public class ArrayListTests
    {
        ArrayList list1 = new ArrayList(new int[] { 1, 2, 3, 4, 5});
        ArrayList list2 = new ArrayList(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 6);
        ArrayList list3 = new ArrayList();


        [TestCase(0,0,4)]
        [TestCase(1,1,4)]
        [TestCase(2,2,20)]
        // добавление значения в конец
        public void AppendTest(int expectedNumber, int actualNumber, int value)
        {
            ArrayList expected = GetListMockAppended(expectedNumber, value);

            ArrayList actual = GetListMock(actualNumber);
            actual.Append(value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(0, 0, 4, 0)]
        [TestCase(1, 1, 19, 2)]
        [TestCase(2, 2, 10, 3)]
        // добавление значения по индексу
        public void InsertTest(int expectedNumber, int actualNumber, int value, int index)
        {
            ArrayList expected = GetListMockInserted(expectedNumber, value, index);

            ArrayList actual = GetListMock(actualNumber);
            actual.Insert(value, index);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, 1)]
        [TestCase(2, 2)]
        [TestCase(3, 3)]
        // удаление из конца
        public void RemoveLastTest(int expectedNumber, int actualNumber)
        {
            ArrayList expected = GetListMockRemovedLast(expectedNumber);

            ArrayList actual = GetListMock(actualNumber);
            actual.RemoveLast();

            Assert.AreEqual(expected, actual);
        }


        [TestCase(1, 1, 1)]
        [TestCase(2, 2, 3)]
        [TestCase(3, 3, 0)]
        // удаление по индексу
        public void RemoveTest(int expectedNumber, int actualNumber, int index)
        {
            ArrayList expected = GetListMockRemoved(expectedNumber);

            ArrayList actual = GetListMock(actualNumber);
            actual.Remove(index);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(0, 0)]
        [TestCase(5, 1)]
        [TestCase(6, 2)]

        // вернуть длину
        public void GetLengthTest(int expected, int actualNumber)
        {
            int actual = GetListMock(actualNumber).GetLength();

            Assert.AreEqual(expected, actual);
        }


        [TestCase(4, 1, 5)]
        [TestCase(3, 2, 4)]
        [TestCase(1, 3, 56)]
        // индекс по значению
        public void GetIndexByValueTest(int expected, int actualNumber, int value)
        {
            int actual = GetListMock(actualNumber).GetIndexByValue(value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, 1, 4, 10)]
        [TestCase(2, 2, 3, 10)]
        [TestCase(3, 3, 0, 10)]
        // изменение по индексу
        public void SetTest(int expectedNumber, int actualNumber, int index, int value)
        {
            ArrayList expected = GetListMockSet(expectedNumber, value);

            ArrayList actual = GetListMock(actualNumber);
            actual.Set(value, index);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, 1)]
        [TestCase(2, 2)]
        [TestCase(3, 3)]
        // реверс
        public void ReverseTest(int expectedNumber, int actualNumber)
        {
            ArrayList expected = GetListMockReversed(expectedNumber);

            ArrayList actual = GetListMock(actualNumber);
            actual.Reverse();

            Assert.AreEqual(expected, actual);
        }


        [TestCase(5, 1)]
        [TestCase(6, 2)]
        [TestCase(56, 3)]

        // максимум
        public void GetMaxTest(int expected, int actualNumber)
        {
            int actual = GetListMock(actualNumber).GetMax();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, 1)]
        [TestCase(1, 2)]
        [TestCase(5, 3)]

        // минимум
        public void GetMinTest(int expected, int actualNumber)
        {
            int actual = GetListMock(actualNumber).GetMin();

            Assert.AreEqual(expected, actual);
        }


        [TestCase(4, 1)]
        [TestCase(5, 2)]
        [TestCase(1, 3)]

        // индекс максимального
        public void GetMaxIndexTest(int expected, int actualNumber)
        {
            int actual = GetListMock(actualNumber).GetMaxIndex();

            Assert.AreEqual(expected, actual);
        }
        
        [TestCase(0, 1)]
        [TestCase(0, 2)]
        [TestCase(0, 3)]

        // индекс минимального
        public void GetMinIndexTest(int expected, int actualNumber)
        {
            int actual = GetListMock(actualNumber).GetMinIndex();

            Assert.AreEqual(expected, actual);
        }


        [TestCase(1, 1)]
        [TestCase(2, 2)]
        [TestCase(3, 3)]
        // сортировка по возр
        public void SortAscendingTest(int expectedNumber, int actualNumber)
        {
            ArrayList expected = GetListMockSortedAscending(expectedNumber);

            ArrayList actual = GetListMock(actualNumber);
            actual.Sort(ascending:true);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, 1)]
        [TestCase(2, 2)]
        [TestCase(3, 3)]
        // сортировка по возр
        public void SortDescendingTest(int expectedNumber, int actualNumber)
        {
            ArrayList expected = GetListMockSortedDescending(expectedNumber);

            ArrayList actual = GetListMock(actualNumber);
            actual.Sort(ascending: false);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, 1, 3)]
        [TestCase(2, 2, 6)]
        [TestCase(3, 3, 11)]
        // сортировка по возр
        public void DeleteFirstByValueTest(int expectedNumber, int actualNumber, int value)
        {
            ArrayList expected = GetListMockDeletedFirstByValue(expectedNumber);

            ArrayList actual = GetListMock(actualNumber);
            actual.DeleteFirstByValue(value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, 1, 3)]
        [TestCase(2, 2, 6)]
        [TestCase(4, 4, 3)]
        // сортировка по возр
        public void DeleteAllByValueTest(int expectedNumber, int actualNumber, int value)
        {
            ArrayList expected = GetListMockDeletedAllByValue(expectedNumber);

            ArrayList actual = GetListMock(actualNumber);
            actual.DeleteAllByValue(value);

            Assert.AreEqual(expected, actual);
        }
                
        [TestCase(1, 1, new int[] {6, 7, 8 })]
        [TestCase(2, 2, new int[] { 6, 7, 8 })]
        [TestCase(3, 3, new int[] { 6, 7, 8 })]
        // добавление массива
        public void AppendArrayTest(int expectedNumber, int actualNumber, int[] values)
        {
            ArrayList expected = GetListMockAppendedMany(expectedNumber);

            ArrayList actual = GetListMock(actualNumber);
            actual.Append(values);

            Assert.AreEqual(expected, actual);
        }
                
        [TestCase(1, 1, new int[] {6, 7, 8 }, 1)]
        [TestCase(2, 2, new int[] { 6, 7, 8 }, 2)]
        [TestCase(3, 3, new int[] { 6, 7, 8 }, 3)]
        // добавление массива
        public void InsertArrayTest(int expectedNumber, int actualNumber, int[] values, int index)
        {
            ArrayList expected = GetListMockInsertedMany(expectedNumber);

            ArrayList actual = GetListMock(actualNumber);
            actual.Insert(values, index);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3}, new int[] { 1, 2, 3, 4, 5 }, 2)]
        [TestCase(new int[] { 1, 2 }, new int[] { 1, 2, 3, 4, 5 }, 3)]
        [TestCase(new int[] { 1}, new int[] { 1, 2, 3, 4, 5 }, 4)]
        public void DeleteLastTest(int[] expectedArray, int[] actualArray, int N)
        {
            ArrayList expected = new ArrayList(expectedArray);
            ArrayList actual = new ArrayList(actualArray);
            actual.DeleteLast(N);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 5)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 10)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 },  -3)]
        public void DeleteLastTestNegative(int[] array, int N)
        {
            ArrayList arrayList = new ArrayList(array);

            Assert.Throws<ArgumentOutOfRangeException>(() => arrayList.DeleteLast(N));
        }

        [TestCase(new int[] { 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5 }, 2, 0)]
        [TestCase(new int[] { 1, 2 }, new int[] { 1, 2, 3, 4, 5 },  3, 2)]
        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 3, 4, 5 }, 1, 4)]
        public void DeleteTest(int[] expectedArray, int[] actualArray, int N, int index)
        {
            ArrayList expected = new ArrayList(expectedArray);
            ArrayList actual = new ArrayList(actualArray);
            actual.Delete(N, index);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 3, 3)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 2, 4)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, -3, 1)]
        public void DeleteTestNegative(int[] array, int N, int index)
        {
            ArrayList arrayList = new ArrayList(array);

            Assert.Throws<ArgumentOutOfRangeException>(() => arrayList.Delete(N, index));
        }
        ArrayList GetListMock(int n)
        {
            switch (n)
            {
                case 0:
                    return new ArrayList();
                case 1:
                    return new ArrayList(new int[] { 1, 2, 3, 4, 5 });
                case 2:
                    return new ArrayList(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 6);
                case 3:
                    return new ArrayList(new int[] { 5, 56, 11 });
                case 4:
                    return new ArrayList(new int[] { 3, 2, 3, 1, 3 });

                default:
                    throw new Exception();
            }
        }
        ArrayList GetListMockInsertedMany(int n)
        {
            switch (n)
            {
                case 1:
                    return new ArrayList(new int[] { 1, 6, 7, 8, 2, 3, 4, 5});
                case 2:
                    return new ArrayList(new int[] { 1, 2, 6, 7, 8, 3, 4, 5, 6 });
                case 3:
                    return new ArrayList(new int[] { 5, 56, 11, 6, 7, 8 });
                default:
                    throw new Exception();
            }
        }
        ArrayList GetListMockAppendedMany(int n)
        {
            switch (n)
            {
                case 0:
                    return new ArrayList();
                case 1:
                    return new ArrayList(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 });
                case 2:
                    return new ArrayList(new int[] { 1, 2, 3, 4, 5, 6, 6, 7, 8});
                case 3:
                    return new ArrayList(new int[] { 5, 56, 11,6,7,8 });
                default:
                    throw new Exception();
            }
        }
        ArrayList GetListMockDeletedAllByValue(int n)
        {
            switch (n)
            {
                case 1:
                    return new ArrayList(new int[] { 1, 2, 4, 5 });
                case 2:
                    return new ArrayList(new int[] { 1, 2, 3, 4, 5 });
                case 3:
                    return new ArrayList(new int[] { 5, 56 });
                case 4:
                    return new ArrayList(new int[] { 2, 1 });

                default:
                    throw new Exception();
            }
        }
        

        ArrayList GetListMockDeletedFirstByValue(int n)
        {
            switch (n)
            {
                case 1:
                    return new ArrayList(new int[] { 1, 2, 4, 5 });
                case 2:
                    return new ArrayList(new int[] { 1, 2, 3, 4, 5 });
                case 3:
                    return new ArrayList(new int[] { 5, 56 });

                default:
                    throw new Exception();
            }
        }

        ArrayList GetListMockSortedAscending(int n)
        {
            switch (n)
            {
                case 1:
                    return new ArrayList(new int[] { 1, 2, 3, 4, 5 });
                case 2:
                    return new ArrayList(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 6);
                case 3:
                    return new ArrayList(new int[] { 5, 11, 56 });

                default:
                    throw new Exception();
            }
        } 
        ArrayList GetListMockSortedDescending(int n)
        {
            switch (n)
            {
                case 1:
                    return new ArrayList(new int[] { 5, 4, 3, 2, 1 });
                case 2:
                    return new ArrayList(new int[] { 6,5,4,3,2,1 });
                case 3:
                    return new ArrayList(new int[] { 56, 11, 5 });

                default:
                    throw new Exception();
            }
        }

        ArrayList GetListMockAppended(int n, int value)
        {
            switch (n)
            {
                case 0:
                    return new ArrayList(new int[] { value });
                case 1:
                    return new ArrayList(new int[] { 1, 2, 3, 4, 5, value });
                case 2:
                    return new ArrayList(new int[] { 1, 2, 3, 4, 5, 6, value });
                default:
                    throw new Exception();
            }
        }
        
        ArrayList GetListMockInserted(int n, int value, int index)
        {
            switch (n)
            {
                case 0:
                    return new ArrayList(new int[] { value });
                case 1:
                    return new ArrayList(new int[] { 1, 2, value, 3, 4, 5});
                case 2:
                    return new ArrayList(new int[] { 1, 2, 3, value, 4, 5, 6});
                default:
                    throw new Exception();
            }
        }
        
        ArrayList GetListMockRemovedLast(int n)
        {
            switch (n)
            {
                case 1:
                    return new ArrayList(new int[] { 1, 2, 3, 4});
                case 2:
                    return new ArrayList(new int[] { 1, 2, 3, 4, 5});
                case 3:
                    return new ArrayList(new int[] { 5, 56 });
                default:
                    throw new Exception();
            }
        }
        ArrayList GetListMockRemoved(int n)
        {
            switch (n)
            {
                case 1:
                    return new ArrayList(new int[] { 1, 3, 4, 5});
                case 2:
                    return new ArrayList(new int[] { 1, 2, 3, 5, 6});
                case 3:
                    return new ArrayList(new int[] { 56, 11 });
                default:
                    throw new Exception();
            }
        }

        ArrayList GetListMockSet(int n, int value)
        {
            switch (n)
            {
                case 1:
                    return new ArrayList(new int[] { 1, 2, 3, 4, value});
                case 2:
                    return new ArrayList(new int[] { 1, 2, 3, value, 5, 6});
                case 3:
                    return new ArrayList(new int[] {value, 56, 11 });
                default:
                    throw new Exception();
            }
        }

        ArrayList GetListMockReversed(int n)
        {
            switch (n)
            {              
                case 1:
                    return new ArrayList(new int[] { 5, 4, 3, 2, 1 });
                case 2:
                    return new ArrayList(new int[] { 6, 5, 4, 3, 2, 1 });
                case 3:
                    return new ArrayList(new int[] { 11, 56, 5 });

                default:
                    throw new Exception();
            }
        }
    }
}