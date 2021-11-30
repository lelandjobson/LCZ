using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Structures
{
    internal class DisjointSetUnion
    {
        private int[] _parent;
        private int[] _size;

        public DisjointSetUnion(int size)
        {
            // Initialize arrays to be filled
            // from 0 to i
            _parent = new int[size + 1];
            _size = new int[size + 1];

            for(int i = 0; i < size + 1; i++)
            {
                this._parent[i] = i;
                this._size[i] = 1;
            }
        }


        public int Find(int x)
        {
            if(this._parent[x] != x)
            {
                this._parent[x] = this.Find(this._parent[x]);
            }
            return this._parent[x];
        }

        public int Union(int x, int y)
        {
            int px = this.Find(x);
            int py = this.Find(y);

            // the two nodes share the same group
            if (px == py) { return px; }

            // otherwise, connect the two sets (components)
            if (this._size[px] > this._size[py])
            {
                // add the node to the union with less members.
                // keeping px as the index of the smaller component
                int temp = px;
                px = py;
                py = temp;
            }

            // add the smaller component to the larger one
            this._parent[px] = py;
            this._size[py] += this._size[px];
            return py;
        }
    }
}
