using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9__1_.List
{
    public class DoublyNode<ListNode>
    {
        public DoublyNode(ListNode data)
        {
            Data = data;
        }
        public ListNode Data { get; set; }
        public DoublyNode<ListNode> Previous { get; set; }
        public DoublyNode<ListNode> Next { get; set; }
    }
}
