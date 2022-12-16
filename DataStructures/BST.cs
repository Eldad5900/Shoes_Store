using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
    public class BST<T> where T : IComparable<T>,IComparer<T>
    {
        Node root;
        public void Clear()
        {
            root = null;
        }

        public void Add(T value)
        {
            if (root == null)
            {
                root = new Node(value);
                return;
            }

            Node tmp = root;
            while (true)
            {
                if (value.CompareTo(tmp.value) < 0) // value < tmp.value - go left
                {
                    if (tmp.left == null)
                    {
                        tmp.left = new Node(value);
                        break;
                    }
                    else tmp = tmp.left;
                }
                else // go right
                {
                    if (tmp.right == null)
                    {
                        tmp.right = new Node(value);
                        break;
                    }
                    else tmp = tmp.right;
                }
            }

        }
        public void ScanInOrder(Action<string> act) // O(n)
        {
            if (act == null) throw new ArgumentNullException("action function cant be null");
            ScanInOrder(root, act);
        }

        private void ScanInOrder(Node tmp, Action<string> act)
        {
            if (tmp == null) return;
            ScanInOrder(tmp.left, act);
            act(tmp.value.ToString());
            ScanInOrder(tmp.right, act);
        }

        public int GetDepth()
        {
            return GetDepth(root);
        }
        private int GetDepth(Node tmp)
        {
            if (tmp == null) return 0;
            int maxChildDepth = Math.Max(GetDepth(tmp.left), GetDepth(tmp.right));
            return maxChildDepth + 1;
        }

        public bool Remove(T value, out T valremo) // O(logN)
        {
            valremo = default;
            Node tmp = root;
            Node tmperent = root;
            bool isRoot = true;

            while (value.CompareTo(tmp.value) != 0)
            {
                tmperent = tmp;
                if (value.CompareTo(tmp.value) < 0)
                {
                    tmp = tmp.left;
                }
                else tmp = tmp.right;
                if (tmp == null) return false;

                if (tmp.value.CompareTo(value) == 0)
                {
                    if (tmperent.left == tmp)
                        isRoot = false;
                }
            }
            value = tmp.value;
            if (tmp.right == null && tmp.left == null)
            {
                if (isRoot) Clear();
                else
                {
                    if (tmperent.left == tmp) tmperent.left = null;
                    else tmperent.right = null;
                }
            }
            else if (tmp.right == null || tmp.left == null)
            {

                if (tmp.left == null)
                {

                    if (tmperent.left == tmp)
                    {
                        tmperent.left = tmp.right;
                    }
                    else tmperent.right = tmp.right;

                }
                else
                {
                    if (isRoot)
                    {
                        root = root.left;
                    }
                    if (tmperent.left == tmp)
                        tmperent.left = tmp.left;
                    else
                        tmperent.right = tmp.left;
                }
            }
            else
            {
                Node tmpokev = tmp.right;
                Node perentokev = tmp;
                while (tmpokev.left != null)
                {
                    perentokev = tmpokev;
                    tmpokev = tmpokev.left;
                }
                if (perentokev == tmp)
                {
                    tmp.right.left = tmp.left;
                    tmperent.right = tmp.right;

                }
                else
                {
                    tmp.value = tmpokev.value;
                    perentokev.left = tmpokev.right;
                }
            }
            return true;


            //1. Find Item (use tmp and parent Node temp variables)
            //if found item is leaf ?
            //if found item has only one child
            //if found item has both children ?????
        }
        public void PrintInOrder(Action <string> ac)
        {
            Node no = root;
            if (root == null) return;
            PrintInOrderOverLode(no,ac);
        } // print
        private void PrintInOrderOverLode(Node node , Action<string> action )
        {

            if (node.left == null) // left nul
            {
                if (node.right == null) //right and left null
                {
                    action?.Invoke($"{node.value}"); 
                    return;
                }
                // left null right not null
                Console.WriteLine(node.value);
                PrintInOrderOverLode(node.right,action);
            }
            else // left is not null
            {

                if (node.right == null)
                {
                    PrintInOrderOverLode(node.left,action);
                    Console.WriteLine(node.value);
                }
                else
                {
                    PrintInOrderOverLode(node.left,action);
                    Console.WriteLine(node.value);
                    PrintInOrderOverLode(node.right,action);
                }
            }
        }
        public bool Search(T item, out T foundItem)
        {
            foundItem = default;

            Node tmp = root;
            while (tmp != null)
            {
                if (item.CompareTo(tmp.value) == 0)
                {
                    foundItem = tmp.value;
                    return true;
                }
                if (item.CompareTo(tmp.value) < 0)
                {
                    tmp = tmp.left;
                }
                else
                {
                    tmp = tmp.right;
                }
            }
            return false; // the item is not in the tree (no such item)
        }
        public bool SearchClosePoint(T item, out T foundItem,out T itmeClose)
        {
            foundItem = default;
            itmeClose = default;

            Node tmp = root;
            while (tmp != null)
            {
                if (item.CompareTo(tmp.value) == 0)
                {
                    foundItem = tmp.value;
                    break;
                }
                if (item.CompareTo(tmp.value) < 0)
                {
                    foundItem = tmp.value;
                    tmp = tmp.left;
                }
                else
                {
                    itmeClose = tmp.value;
                    tmp = tmp.right;
                }
            }
            return false; // the item is not in the tree (no such item)

        }
        public Node PerRoot()
        {
            return root;
        }
        public void Incidences(BST<T> pointIncidence)
        {
            Incidences(pointIncidence, root);
        }
        private void Incidences(BST<T> pointIncidence, Node root)
        {
            if (root.left == null) // left nul
            {
                if (root.right == null) //right and left null
                {
                    pointIncidence.AddCompere(root.value);
                    return;
                }
                // left null right not null
                pointIncidence.AddCompere(root.value);
                Incidences(pointIncidence, root.right);



            }
            else // left is not null
            {

                if (root.right == null)
                {
                    Incidences(pointIncidence, root.left);
                    pointIncidence.AddCompere(root.value);
                }
                else
                {
                    Incidences(pointIncidence, root.left);
                    pointIncidence.AddCompere(root.value);
                    Incidences(pointIncidence, root.right);
                }
            }

        }
        public void AddCompere(T value)
        {
            if (root == null)
            {
                root = new Node(value);
                return;
            }

            Node tmp = root;
            while (true)
            {
                if (value.Compare(value, tmp.value) < 0) // value < tmp.value - go left
                {
                    if (tmp.left == null)
                    {
                        tmp.left = new Node(value);
                        break;
                    }
                    else tmp = tmp.left;
                }
                else // go right
                {
                    if (tmp.right == null)
                    {
                        tmp.right = new Node(value);
                        break;
                    }
                    else tmp = tmp.right;
                }
            }
        }

        public class Node
        {
            public T value;
            public Node left;
            public Node right;

            public Node(T value)
            {
                this.value = value;
            }

        }
    }
}
