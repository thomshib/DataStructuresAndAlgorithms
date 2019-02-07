using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructuresAndAlgorithms.Tree.BST
{
    public class BSTreeSample
    {
        private const int COLUMN_WIDTH = 5;

        public static void BinarySearchTreeTest()
        {
            Console.OutputEncoding = Encoding.UTF8;

            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            tree.Root = new BinaryTreeNode<int>() { Data = 100 };
            tree.Root.Left = new BinaryTreeNode<int> { Data = 50, Parent = tree.Root };
            tree.Root.Right = new BinaryTreeNode<int> { Data = 150, Parent = tree.Root };
            tree.Count = 3;
            Console.WriteLine("The BST with three nodes  (50, 100, 150):");

            tree.Add(75);
            tree.Add(125);

            Console.WriteLine("Added 75 and 25");
            tree.Add(25);
            tree.Add(175);
            tree.Add(90);
            tree.Add(110);
            tree.Add(135);

            tree.Remove(25);
            tree.Remove(50);
            tree.Remove(100);
            Console.WriteLine("The BST after removing the node 25:");

            Console.Write("PreOrder Traversal: \t");
            Console.Write(string.Join(", ", tree.Traverse(TraversalEnum.PREORDER).Select(n => n.Data)));
        }

        private static void VisualizeTree(BinarySearchTree<int> tree, string v)
        {
            throw new NotImplementedException();
        }
    }
}
