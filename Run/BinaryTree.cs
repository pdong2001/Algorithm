namespace BinaryTree
{
    using System;
    public class Node
    {
        public int Data;
        public Node Left;
        public Node Right;
        public Node(int Data)
        {
            this.Data = Data;
            Left = null;
            Right = null;
        }
        public Node() { }
    }
    public class BTree
    {
        public Node Root;
        public int Length;
        public BTree()
        {
            Length = 0;
        }
        public BTree(int[] Arr)
        {
            for (int i = 0; i < Arr.Length; i++)
            {
                Insert(Arr[i]);
            }
        }
        public void Delete(int Value)
        {
            Root = Delete(Root, Value);
        }
        public void PrintT()
        {
            if (Root == null)
                Console.Write("NULL");
            else
            {
                PrintT(Root, " ");
            }
        }
        public void ToAVL()
        {
            while (isAVL() != true)
                Root = UpdateTreeAvl(Root);
        }
        public int LeavesCount()
        {
            int Count = 0;
            LeavesCount(Root, ref Count);
            return Count;
        }
        public int Count(int Value)
        {
            int RS = 0;
            Count(Root, ref RS, Value);
            return RS;
        }
        public int Level()
        {
            return TreeLevel(Root);
        }
        public void Insert(int Value)
        {
            Root = Insert(Value, Root);
            Length++;
        }
        public bool isAVL()
        {
            if (Math.Abs(TreeLevel(Root.Left) - TreeLevel(Root.Right)) <= 1)
                return true;
            return false;
        }
        public int[] ToArray()
        {
            int[] RS = new int[Length];
            int A = 0;
            ToArray(Root, ref RS, ref A);
            return RS;
        }
        private void PrintT(Node A, string Step = "")
        {
            if (A != null)
            {
                PrintT(A.Left, " ");
                Console.Write(A.Data + Step);
                PrintT(A.Right, " ");
            }
        }
        private void Count(Node A, ref int C, int Value)
        {
            if (A != null)
            {
                Count(A.Left, ref C, Value);
                Count(A.Right, ref C, Value);
                if (A.Data == Value)
                {
                    C++;
                }
            }
        }
        private Node Delete(Node A, int Value)
        {
            if (A != null)
            {
                if (A.Data == Value)
                {
                    A = null;
                }
                else
                {
                    A.Left = Delete(A.Left, Value);
                    A.Right = Delete(A.Right, Value);
                }
            }
            return A;
        }
        private void LeavesCount(Node A, ref int Count)
        {
            if (A != null)
            {
                LeavesCount(A.Left, ref Count);
                LeavesCount(A.Right, ref Count);
                if (A.Left == null && A.Right == null)
                {
                    Count++;
                }
            }
        }
        private Node Insert(int Value, Node A)
        {
            if (A == null)
            {
                A = new Node(Value);
                return A;
            }
            else
            {
                if (A.Data > Value)
                {
                    A.Left = Insert(Value, A.Left);
                }
                else
                {
                    A.Right = Insert(Value, A.Right);
                }
            }
            return A;
        }
        private int TreeLevel(Node A)
        {
            if (A == null)
            {
                return -1;
            }
            return 1 + Math.Max(TreeLevel(A.Left), TreeLevel(A.Right));
        }
        private Node UpdateTreeAvl(Node A)
        {
            if (Math.Abs(TreeLevel(A.Left) - TreeLevel(A.Right)) > 1)
            {
                if (TreeLevel(A.Left) > TreeLevel(A.Right))
                {
                    Node p = A.Left;
                    if (TreeLevel(p.Left) >= TreeLevel(p.Right))
                    {
                        A = TurnRight(A);
                    }
                    else
                    {
                        A.Left = TurnLeft(A.Left);
                        A = TurnRight(A);
                    }
                }
                else
                {
                    Node p = A.Right;
                    if (TreeLevel(p.Right) >= TreeLevel(p.Left))
                    {
                        A = TurnLeft(A);
                    }
                    else
                    {
                        A.Right = TurnRight(A.Right);
                        A = TurnLeft(A);

                    }
                }
            }
            if (A.Left != null) A.Left = UpdateTreeAvl(A.Left);
            if (A.Right != null) A.Right = UpdateTreeAvl(A.Right);
            return A;
        }
        private Node TurnRight(Node A)
        {
            Node b = A.Left;
            Node d = b.Right;
            A.Left = d;
            b.Right = A;
            return b;
        }
        private Node TurnLeft(Node A)
        {
            Node b = A.Right;
            Node c = b.Left;
            A.Right = c;
            b.Left = A;
            return b;
        }
        private void ToArray(Node A, ref int[] T, ref int Index)
        {
            if (A != null)
            {
                ToArray(A.Left, ref T, ref Index);
                T[Index] = A.Data;
                Index++;
                ToArray(A.Right, ref T, ref Index);
            }
        }
    }
}