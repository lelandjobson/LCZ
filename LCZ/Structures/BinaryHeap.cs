using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Structures
{
    internal class BinaryHeap<T>
    {
        private int[] _arr;
        private T[] _elements;

        public int Size => _size;
        private int _size;

        public BinaryHeap(int size)
        {
            _arr = new int[size + 1];
            _elements = new T[size + 1];
            _size = 0;
        }

        public int Peek => _size == 0 ? 0 : _arr[1];

        public void Insert(int value, T element)
        {
            if(_size < 0) { return; } // I don't know why this is.

            _arr[_size + 1] = value;
            _elements[_size + 1] = element;

            _size++;

            HeapifyBottomToTop(_size);
        }

        public bool Contains(T value)
        {
            foreach(var e in _elements)
            {
                if (e.Equals(value)) { return true; }
            }
            return false;
        }

        public (int, T) Pop()
        {
            if(_size == 0) { return (-1,default(T)); } // Could throw exception as well..

            int val = _arr[1];
            T elem = _elements[1];

            _size--;
            return (val,elem);

        }

        void HeapifyTopToBottom(int index)
        {
            int left = index * 2;
            int right = (index * 2) + 1;
            int curValue = _arr[index];
            T curElement = _elements[index];

            int smallestChild = 0;

            // If there are no children below this node, then we've reached the end.
            if (_size < left) { return; }
            if(_size == left)
            {
                // If this value is greater than the left, then push it down
                if(curValue > _arr[left])
                {
                    _arr[index] = _arr[left];
                    _arr[left] = curValue;
                    _elements[index] = _elements[left];
                    _elements[left] = curElement;
                }
            }
            // If size > left
            else
            {
                smallestChild = _arr[left] < _arr[right] ? left : right;
                // If this value is greater than the child, then push it down (swap)
                if(curValue > _arr[smallestChild])
                {
                    _arr[index] = _arr[smallestChild];
                    _arr[smallestChild] = curValue;
                    _elements[index] = _elements[smallestChild];
                    _elements[smallestChild] = curElement;
                }
            }
            HeapifyTopToBottom(smallestChild);
        }

        void HeapifyBottomToTop(int index)
        {
            int parent = index / 2;
            // Root = no need
            if (index <= 1) {  return; }
            // If value is smaller than parent, swap
            if(_arr[index] < _arr[parent])
            {
                int tmp = _arr[index];
                T etmp = _elements[index];

                _arr[index] = _arr[parent];
                _arr[parent] = tmp;
                _elements[index] = _elements[parent];
                _elements[parent] = etmp;
            }
            HeapifyBottomToTop(parent);
        }

        public override string ToString()
        {
            string result = "";
            foreach(var value in _arr) { result += (value + " " + "\n"); }
            return result;
        }
    }
}
