using System;
using System.Runtime.Serialization.Formatters;

namespace DataStructures
{
    public class ArrayList
    {
        public int Length { get; private set; }

        private int[] _array;
        private int _TrueLength
        {
            get
            {
                return _array.Length;
            }
        }

        public ArrayList()
        {
            _array = new int[1];
            Length = 0;
        }

        public ArrayList(int[] array)
        {
            Length = array.Length;
            _array = new int[Length];
            Array.Copy(array, _array, Length);
        }
        
        public ArrayList(int[] array, int length)
        {
            Length = length;
            _array = new int[array.Length];
            Array.Copy(array, _array, length);
        }


        // добавление значения в конец
        public void Append(int value)
        {
            if (_TrueLength <= Length)
            {
                IncreaseLength();
            }
            _array[Length] = value;
            Length++;
        }

        //добавление значения по индексу

        public void Insert(int value, int index)
        {
            if(index > Length)
            {
                throw new Exception("index should must not be more than length");
            }
            else
            {
                if (_TrueLength <= Length)
                {
                    IncreaseLength();
                }

                for(int i = Length; i > index; i--)
                {
                    _array[i] = _array[i - 1];
                }
                _array[index] = value;
                Length++;
            }
        }
        // добавление значения в начало

        public void Push(int value)
        {
            Insert(value, 0);
        }


        // удаление из конца одного элемента
        public void RemoveLast()
        {
            if(_TrueLength >= 2 * Length)
            {
                DecreaseLength();
            }
            Length--;
        }

        // добавление значения в начало

        public void RemoveFirst()
        {
            Remove(0);
        }


        // удаление по индексу одного элемента

        public void Remove(int index)
        {
            if (index > Length)
            {
                throw new Exception("index should must not be more than length");
            }
            else
            {
                if (_TrueLength >= 2 * Length)
                {
                    DecreaseLength();
                }
                for (int i = index; i < Length - 1; i++)
                {
                    _array[i] = _array[i + 1];
                }
                Length--;
            }
        }


        // вернуть длину

        public int GetLength()
        {
            return Length;
        }

        // доступ по индексу
        public int Get(int index)
        {
            if (index < Length && index >= 0)
                return _array[index];
            else
                throw new Exception("Index out of range");
        }

        // индекс по значению 
        public int GetIndexByValue(int value)
        {
            for (int i = 0; i < Length; i++)
            {
                if (_array[i] == value)
                    return i;
            }
            throw new Exception("The value is not present in the list");
        }

        // изменение по индексу

        public void Set(int value, int index)
        {
            if (index < Length && index >= 0)
                _array[index] = value;
            else
                throw new Exception("Index out of range");
        }

        // реверс

        public void Reverse()
        {
            int middle = (1 + Length) / 2;
            int temp;

            for(int i = 0; i < middle; i++)
            {
                temp = _array[i];
                _array[i] = _array[Length - i - 1];
                _array[Length - i - 1] = temp;
            }
        }



        // поиск значения максимального элемента
        
        public int GetMax()
        {
            int max = _array[0];
            for (int i = 1; i < Length; i++)
            {
                if (max < _array[i])
                    max = _array[i];
            }
            return max;
        }
        
        // поиск значения минимального элемента
        
        public int GetMin()
        {
            int min = _array[0];
            for (int i = 1; i < Length; i++)
            {
                if (min > _array[i])
                    min = _array[i];
            }
            return min;
        }

        // поиск индекс максимального элемента

        public int GetMaxIndex()
        {
            int maxIndex = 0;
            for (int i = 1; i < Length; i++)
            {
                if (_array[maxIndex] < _array[i])
                    maxIndex = i;
            }
            return maxIndex;
        }

        // поиск индекс минимального элемента

        public int GetMinIndex()
        {
            int minIndex = 0;
            for (int i = 1; i < Length; i++)
            {
                if (_array[minIndex] > _array[i])
                    minIndex = i;
            }
            return minIndex;
        }

        // сортировка ascending=true  - по возрастанию, ascending=false - по убыванию
        public void Sort(bool ascending=true)
        {
            int temp;
         
            if (ascending)
            {
                int min_index;

                for (int i = 0; i < Length - 1; i++)
                {
                    min_index = i;

                    for (int j = i + 1; j < Length; j++)
                    {
                        if (_array[j] < _array[min_index])
                        {
                            min_index = j;
                        }
                    }

                    // swapping elements
                    temp = _array[min_index];
                    _array[min_index] = _array[i];
                    _array[i] = temp;
                }
            }
            else
            {
                int max_index;

                for (int i = 0; i < Length - 1; i++)
                {
                    max_index = i;

                    for (int j = i + 1; j < Length; j++)
                    {
                        if (_array[j] > _array[max_index])
                        {
                            max_index = j;
                        }
                    }

                    // swapping elements
                    temp = _array[max_index];
                    _array[max_index] = _array[i];
                    _array[i] = temp;
                }
            }
        }

        // удаление по значению первого
        
        public void DeleteFirstByValue(int value)
        {
            for (int i = 0; i < Length; i++)
            {
                if (_array[i] == value)
                {
                    Remove(i);
                    return;
                }
            }
            throw new Exception("The value is not present in the list");
        }


        // удаление по значению всех
        public void DeleteAllByValue(int value)
        {
            bool isPresent = false;

            for (int i = 0; i < Length; i++)
            {
                if (_array[i] == value)
                {
                    Remove(i);
                    isPresent = true;
                }
            }
            if (!isPresent)
            {
                throw new Exception("The value is not present in the list");
            }
        }



        // добавление массива в конец
        public void Append(int[] elements)
        {

            if (Length + elements.Length >= _TrueLength)
            {
                IncreaseLength(elements.Length);
            }
            for (int i = 0; i < elements.Length; i++)
            {
                _array[Length + i] = elements[i];
            }        
            Length += elements.Length;
        }

        // добавление массива по индексу
        public void Insert(int[] elements, int index)
        {

            if (Length + elements.Length >= _TrueLength)
            {
                IncreaseLength(elements.Length);
            }
            for (int i = Length - 1; i >= index; i--)
            {
                _array[i + elements.Length] = _array[i];
            } 
            
            for (int i = 0; i < elements.Length; i++)
            {
                _array[index + i] = elements[i];
            }
           
            Length += elements.Length;
        }

        // добавление массива в начало
        public void Push(int[] elements)
        {
            Insert(elements, 0);
        }

        // удаление из конца N элементов
        public void DeleteLast(int N)
        {
            if (N >= Length)
                throw new ArgumentOutOfRangeException("Must be less then the length");
            if (N <= 0)
                throw new ArgumentOutOfRangeException("Must be positive");

            if (_TrueLength > 2 * (Length - N))
                DecreaseLength(N);
            Length -= N;
        }

        // удаление из начала N элементов
        public void DeleteFirst(int N)
        {
            Delete(N, 0);
        }

        // удаление по индексу N элементов
        public void Delete(int N, int index)
        {            
            if (N < 0 || index < 0)
                throw new ArgumentOutOfRangeException("Must be positive");

            if (index + N > Length)
            {
                throw new ArgumentOutOfRangeException();
            }

            for (int i = index + N; i < Length; i++)
            {
                _array[i - N] = _array[i];
            }

            if(_TrueLength > 2 * (Length - N))
                DecreaseLength(N);

            Length -= N;
        }

        
        public int this[int i]
        {
            get
            {
                if (i >= 0 && i < Length)
                    return _array[i];
                else
                    throw new IndexOutOfRangeException();
            }
            set
            {
                if (i >= 0 && i < Length)
                    _array[i] = value;
                else
                    throw new IndexOutOfRangeException();
            }
        }
        private void IncreaseLength(int number = 1)
        {
            int newLength = _TrueLength;
            while (newLength <= Length + number)
            {
                newLength = newLength * 4 / 3 + 1;
            }

            int[] newArray = new int[newLength];
            Array.Copy(_array, newArray, _TrueLength);

            _array = newArray;
        } 
        
        private void DecreaseLength(int number = 1)
        {
            int newLength = _TrueLength;
            while (newLength >= 2 * (Length - number))
            {
                newLength = newLength * 2 / 3;
            }

            int[] newArray = new int[newLength];
            Array.Copy(_array, newArray, Length - number);

            _array = newArray;
        }

        public override bool Equals(object obj)
        {
            ArrayList arrayList = (ArrayList)obj;

            if (Length != arrayList.Length)
            {
                return false;
            }
            else
            {
                for (int i = 0; i < Length; i++)
                {
                    if (_array[i] != arrayList._array[i])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
