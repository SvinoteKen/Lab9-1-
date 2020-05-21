using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9__1_.List
{
    public class DoublyLinkedList<ListNode> : IEnumerable<ListNode>  
    {
        DoublyNode<ListNode> head; 
        DoublyNode<ListNode> tail; 
        int count;
        public void Add(ListNode data)
        {
            DoublyNode<ListNode> node = new DoublyNode<ListNode>(data);

            if (head == null)
                head = node;
            else
            {
                tail.Next = node;
                node.Previous = tail;
            }
            tail = node;
            count++;
        }
        public void AddFirst(ListNode data)
        {
            DoublyNode<ListNode> node = new DoublyNode<ListNode>(data);
            DoublyNode<ListNode> temp = head;
            node.Next = temp;
            head = node;
            if (count == 0)
                tail = head;
            else
                temp.Previous = node;
            count++;
        }
        
        public bool Remove(ListNode data)
        {
            DoublyNode<ListNode> current = head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    break;
                }
                current = current.Next;
            }
            if (current != null)
            {
                
                if (current.Next != null)
                {
                    current.Next.Previous = current.Previous;
                }
                else
                {
                    
                    tail = current.Previous;
                }

                 if (current.Previous != null)
                {
                    current.Previous.Next = current.Next;
                }
                else
                {
                    head = current.Next;
                }
                count--;
                return true;
            }
            return false;
        }

        public int Count { get { return count; } }
        public bool IsEmpty { get { return count == 0; } }

        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }

        public bool Contains(ListNode data)
        {
            DoublyNode<ListNode> current = head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                    return true;
                current = current.Next;
            }
            return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        IEnumerator<ListNode> IEnumerable<ListNode>.GetEnumerator()
        {
            DoublyNode<ListNode> current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        public IEnumerable<ListNode> BackEnumerator()
        {
            DoublyNode<ListNode> current = tail;
            while (current != null)
            {
                yield return current.Data;
                current = current.Previous;
            }
        }

        public DoublyNode<ListNode> SearchElement(int index)
        {
             DoublyNode<ListNode> Prev = tail;
            DoublyNode<ListNode> Next = head;

            if (index > count || index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            else if (index < ((count + 1) / 2))
            {
                if (index == 0)
                {
                    return head;
                }

                for (; index != 0; index--)
                {
                    Next = Next.Next;
                }

                return Next;
            }
            else
            {
                for (; index < count; index++)
                {
                    Prev = Prev.Previous;
                }

                return Prev;
            }
        }

        public ListNode AddToPosition(ListNode elem, int index)
        {
            DoublyNode<ListNode> Last = tail;
            DoublyNode<ListNode> Next = SearchElement(index);

            if (index == 0)
            {
                head = new DoublyNode<ListNode>(elem);
                head.Next = Next;
                Next.Previous = head;
                return default(ListNode);
            }

            DoublyNode<ListNode> Prev = SearchElement(index - 1);
            var NewElement = new DoublyNode<ListNode>(elem);


            Prev.Next = NewElement;
            NewElement.Previous = Prev;
            Next.Previous = NewElement;
            NewElement.Next = Next;

            count++;

            tail = Last;

            return default(ListNode);
        }

    }
}
