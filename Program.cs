using System;
using System.Collections.Generic;
using System.Linq;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            List<int> result = program.CreateList();
            foreach (var item in result)
                Console.WriteLine(item);
        }
        public LinkedList<int> list1 { get; set; }
        public LinkedList<int> list2 { get; set; }
        public LinkedList<int> list3 { get; set; }
        public List<int> CreateList()
        {
            List<int> baseList1 = new List<int>()
        {
            1, 3, 5, 7
        };
            List<int> baseList2 = new List<int>()
        {
            2, 4, 6, 8
        };
            List<int> baseList3 = new List<int>()
        {
            0, 9, 10, 11
        };

            List<int> resultList = new List<int>();

            list1 = new LinkedList<int>(baseList1);
            list2 = new LinkedList<int>(baseList2);
            list3 = new LinkedList<int>(baseList3);

            Node node1 = new Node();
            Node node2 = new Node();
            Node node3 = new Node();
            while (list1.Count > 0 || list2.Count > 0 || list3.Count > 0)
            {
                if (list1.Count > 0)
                {
                    node1.Value = list1.First.Value;
                    if (list1.First.Next != null)
                        node1.NextNode = new Node()
                        {
                            Value = list1.First.Next.Value
                        };
                }
                else node1 = null;
                if (list2.Count > 0)
                {
                    node2.Value = list2.First.Value;
                    if (list2.First.Next != null)
                        node2.NextNode = new Node()
                        {
                            Value = list2.First.Next.Value
                        };
                }
                else node2 = null;
                if (list3.Count > 0)
                {
                    node3.Value = list3.First.Value;
                    if (list3.First.Next != null)
                        node3.NextNode = new Node()
                        {
                            Value = list3.First.Next.Value
                        };
                }

                int minElem = FindMin(new List<Node>() { node1, node2, node3 });
                resultList.Add(minElem);
            }

            return resultList;
        }

        private int FindMin(List<Node> elem)
        {
            int minElem = elem.Where(y => y != null).Select(x => x.Value).Min();

            list1.Remove(minElem);
            list2.Remove(minElem);
            list3.Remove(minElem);

            return minElem;
        }
    }
    public class Node
    {
        public int Key { get; set; }
        public int Value { get; set; }
        public Node NextNode;
    }
}
