using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Structures
{
    public class LRUCache
    {
        private int capacity = 0;
        private LinkedList<int[]> list = new LinkedList<int[]>();
        private Dictionary<int, LinkedListNode<int[]>> dict = new Dictionary<int, LinkedListNode<int[]>>();

        public LRUCache(int capacity)
        {
            this.capacity = capacity;
        }

        public int Get(int key)
        {
            if (!dict.ContainsKey(key))
                return -1;

            Reorder(dict[key]);

            return dict[key].Value[1];

            int[] x;
            //Array.Copy(x, 0, new int[i], 0,);
        }

        public void Put(int key, int value)
        {
            if (dict.ContainsKey(key))
                dict[key].Value[1] = value;
            else
            {
                if (dict.Count == this.capacity)
                {
                    dict.Remove(list.Last.Value[0]);
                    list.RemoveLast();
                }

                dict.Add(key, new LinkedListNode<int[]>(new int[] { key, value }));
            }

            Reorder(dict[key]);
        }

        private void Reorder(LinkedListNode<int[]> node)
        {
            if (node.Previous != null)
                list.Remove(node);

            if (list.First != node)
                list.AddFirst(node);
        }
    }
}
