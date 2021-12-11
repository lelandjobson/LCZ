using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Structures
{
    internal class DoubleLinkedNode
    {
        public DoubleLinkedNode Prev;
        public DoubleLinkedNode Next;
        public int Key;
        public int Value;
    }

    internal class DoubleLinkedList
    {
        // The head and the tail are NOT actual items
        // in the linked list.
        // They're like the brackets that hold everything together.
        DoubleLinkedNode Head = new DoubleLinkedNode();
        DoubleLinkedNode Tail = new DoubleLinkedNode();

        int size = 0;

        public void AddNode(DoubleLinkedNode node)
        {
            node.Prev = Head;
            node.Next = Head.Next;

            Head.Next.Prev = node;
            Head.Next = node;
            size++;
        }

        public void RemoveNode(DoubleLinkedNode node)
        {
            var prev = node.Prev;
            var next = node.Next;
            prev.Next = next;
            next.Prev = prev;
            size--;
        }

        public void MoveToHead(DoubleLinkedNode node)
        {
            RemoveNode(node);
            AddNode(node);
        }

        public DoubleLinkedNode PopTail()
        {
            var tail = Tail.Prev;
            RemoveNode(tail);
            return tail;
        }
    }
}
