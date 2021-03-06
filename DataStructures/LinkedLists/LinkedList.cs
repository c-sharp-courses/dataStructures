﻿using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace DataStructures.LinkedLists
{
    public class LinkedList
    {
        public int Length { get; set; }

        private Node _root;

        public LinkedList()
        {
            Length = 0;
        }

        public int this[int index]
        {
            get
            {
                Node tmp = _root;
                for (int i = 1; i < index; i++)
                {
                    tmp = tmp.Next;
                }
                return tmp.Value;
            }

            set
            {
                Node tmp = _root;
                for (int i = 1; i < index; i++)
                {
                    tmp = tmp.Next;
                }
                tmp.Value = value;
            }
        }

        public LinkedList(int value)
        {
            Length = 1;
            _root = new Node(value);
        }

        public LinkedList(int[] values)
        {
            if (values.Length == 0)
            {
                Length = 0;
                _root = null;
            }
            else
            {
                _root = new Node(values[0]);
                Node tmp = _root;

                for (int i = 1; i < values.Length; i++)
                {
                    tmp.Next = new Node(values[i]);
                    tmp = tmp.Next;
                }
                Length = values.Length;
                tmp.Next = null;
                // dfgadfgadg;
            }
        }

        //добавление в конец
        public void Append(int value)
        {
            if (Length == 0)
            {
                _root = new Node(value);
            }
            else
            {
                Node last = Get(Length - 1);
                Node newNode = new Node(value);
                last.Next = newNode;
            }
            Length++;
        }

        // добавление по индексу
        public void Insert(int value, int index)
        {
            if (index < 0 || index > Length)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (index == 0)
            {
                Push(value);
            }
            else
            {
                Node inserted = new Node(value);
                Node previous = Get(index - 1);
                inserted.Next = previous.Next;
                previous.Next = inserted;
            }
            Length++;
        }

        // добавление значения в начало
        public void Push(int value)
        {
            Node next = _root;
            _root = new Node(value);
            _root.Next = next;
        }

        // удаление из конца
        public void RemoveLast()
        {
            if (Length == 0)
            {
                throw new NullReferenceException("The list is empty, nothing to remove");
            }
            else
            {
                if (Length == 1)
                {
                    _root = null;
                }
                else
                {
                    Node newLast = Get(Length - 2);
                    newLast.Next = null;
                }
                Length--;
            }

        }

        public void Remove(int index)
        {
            if(Length == 0)
            {
                throw new NullReferenceException("The list is empty, nothing to remove");
            }
            if (index < 0 || index >= Length)
            {
                throw new ArgumentOutOfRangeException("index must be in 0..Length-1");
            }
            else
            {
                if(index == 0)
                {
                    _root = _root.Next;
                }
                else
                {
                    Node previous = Get(index - 1);
                    previous.Next = previous.Next.Next;
                }
                Length--;
            }
        }

        // индекс по значению
        public int GetIndexOf(int value)
        {
            if(Length == 0)
            {
                throw new NullReferenceException("The list is empty");
            }
            Node tmp = _root;
            int index = 0;
            while(tmp != null)
            {
                if (tmp.Value == value)
                {
                    return index;
                }
                tmp = tmp.Next;
                index++;
            }
            throw new ArgumentOutOfRangeException("The value is not present in the list");
        }

        // реверс

        public void Reverse()
        {
            if (Length != 0 && Length != 1)
            {
                int value = _root.Value;
                Remove(0);
                if (_root.Next != null)
                {
                    Reverse();
                }
                Append(value);
            }   
        }

        // максимум

        public int GetMax()
        {
            if(Length == 0)
            {
                throw new NullReferenceException("The list is empty");
            }

            Node node = _root;
            int max = node.Value;
            while(node.Next != null)
            {
                node = node.Next;
                if(node.Value > max)
                {
                    max = node.Value;
                }
            }
            return max;
        }
        
        // минимум

        public int GetMin()
        {
            if(Length == 0)
            {
                throw new NullReferenceException("The list is empty");
            }

            Node node = _root;
            int min = node.Value;
            while(node.Next != null)
            {
                node = node.Next;
                if(node.Value < min)
                {
                    min = node.Value;
                }
            }
            return min;
        }

        // индекс максимального
        public int GetMaxIndex()
        {
            if (Length == 0)
            {
                throw new NullReferenceException("The list is empty");
            }
            int count = 0;
            int maxIndex = 0;
            Node node = _root;

            int max = node.Value;
            while (node.Next != null)
            {
                node = node.Next;
                count++;
                if (node.Value > max)
                {
                    max = node.Value;
                    maxIndex = count;
                }
            }
            return maxIndex;
        }

        // индекс минимального
        public int GetMinIndex()
        {
            if (Length == 0)
            {
                throw new NullReferenceException("The list is empty");
            }
            int count = 0;
            int minIndex = 0;
            Node node = _root;

            int min = node.Value;
            while (node.Next != null)
            {
                node = node.Next;
                count++;
                if (node.Value < min)
                {
                    min = node.Value;
                    minIndex = count;
                }
            }
            return minIndex;
        }


        public override bool Equals(object obj)
        {
            LinkedList list = (LinkedList)obj;

            if(Length != list.Length)
            {
                return false;
            }

            Node tmp = _root;
            Node tmp1 = list._root;

            for(int i = 0; i < Length; i++)
            {
                if(tmp.Value != tmp1.Value)
                {
                    return false;
                }
                tmp = tmp.Next;
                tmp1 = tmp1.Next;
            }
            return true;
        }

        public override string ToString()
        {
            string s = "";

            if (_root != null)
            {
                Node tmp = _root;

                while (tmp != null)
                {
                    s += tmp.Value + " ";
                    tmp = tmp.Next;
                }
            }
            return s;
        }

        // сортировка ascending=true  - по возрастанию, ascending=false - по убыванию

        public void Sort(bool ascending = true)
        {
            Node tail = _root;
            Node beforeTail = tail;

            if (_root == null )
                return;

            while (tail.Next != null)
            {
                Node tmp = tail;
                Node min = tail;
                Node beforeMin = tail;

                while(tmp.Next != null)
                {
                    if ((tmp.Next.Value < min.Value && ascending)
                        ||(tmp.Next.Value > min.Value && !ascending))
                    {
                        beforeMin = tmp;
                        min = tmp.Next;
                    }
                    tmp = tmp.Next;
                }
               
                if (tail != min)
                {
                    beforeMin.Next = min.Next;
                    min.Next = tail;
                    if(tail != _root)
                    {
                        beforeTail.Next = min;
                    }
                    else
                    {
                        _root = min;
                    }
                    beforeTail = min;
                }
                else
                {
                    beforeTail = tail;
                    tail = tail.Next;
                }
            }
        }

        // удаление по значению первого
        public void DeleteFirstByValue(int value)
        {
            if(_root == null)
            {
                throw new InvalidOperationException();
            }
            if(_root.Value == value)
            {
                _root = _root.Next;
                Length--;
                return;
            }

            Node tmp = _root;
            while(tmp.Next != null)
            {
                if(tmp.Next.Value == value)
                {
                    tmp.Next = tmp.Next.Next;
                    Length--;
                    return;
                }
                tmp = tmp.Next;
            }
            throw new ArgumentOutOfRangeException("The value is not present in the list");
        }

        // удаление по значению всех
        public void DeleteAllByValue(int value)
        {
            if (_root == null) throw new InvalidOperationException();

            bool isPresent = false;

            while(_root.Value == value)
            {
                _root = _root.Next;
                Length--;
                if (_root == null) return;
            }

            Node tmp = _root;
            while (tmp.Next != null)
            {
                while(tmp.Next.Value == value)
                {
                    isPresent = true;
                    tmp.Next = tmp.Next.Next;
                    Length--;
                    if (tmp.Next == null) return;
                }
                tmp = tmp.Next;
            }

            if(!isPresent)
                throw new ArgumentOutOfRangeException("The value is not present in the list");
        }

        // добавление массива в конец

        public void Append(int[] values)
        {
            LinkedList appendedList = new LinkedList(values);

            if (Length == 0)
            {
                _root = appendedList._root;
            }
            else
            {
                Node last = Get(Length - 1);
                last.Next = appendedList._root;
            }
            Length += values.Length;
        }

        // добавление массива в начало

        public void Push(int[] values)
        {
            if(values.Length != 0)
            {
                LinkedList pushedList = new LinkedList(values);
                Node last = pushedList.Get(values.Length - 1);
                last.Next = _root;
                _root = pushedList._root;
                Length += values.Length;
            }
            
        }

        // добавление массива по индексу

        public void Insert(int[] values, int index)
        {
            if(values.Length == 0)
            {
                return;
            }
            if (index < 0 || index > Length)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (index == 0)
            {
                Push(values);
            }
            else
            {
                LinkedList inserted = new LinkedList(values);
                Node previous = Get(index - 1);
                Node lastInserted = inserted.Get(values.Length - 1);
                lastInserted.Next = previous.Next;
                previous.Next = inserted._root;
                Length += values.Length;
            }
        }

        public void DeleteLast(int N)
        {
            if(Length < N)
            {
                throw new ArgumentOutOfRangeException("N must not be more than length");
            }
            if(Length == N)
            {
                _root = null;
                Length = 0;
            }
            else
            {
                Node newLast = Get(Length - N - 1);
                newLast.Next = null;
                Length -= N;
            }
        }

        public void Delete(int N, int index)
        {
            if (N <= 0 || index < 0) throw new ArgumentOutOfRangeException("Must be positive");

            if (index + N > Length) throw new ArgumentOutOfRangeException();

            if (index == 0)
            {
                _root = Get(N);
            }
            else
            {
                Node beforeIndex = Get(index - 1);
                beforeIndex.Next = Get(index + N);
            }
            Length -= N;
        }

        private Node Get(int n)
        {
            if(Length < n || n < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                Node tmp = _root;
                for(int i = 0; i < n; i++)
                {
                    tmp = tmp.Next;
                }
                return tmp;
            }

        }
    }
}
