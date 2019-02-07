using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresAndAlgorithms.Tree
{
    public class Utils
    {

        public Utils()
        {
            Tree<int> tree = new Tree<int>();
            tree.Root = new TreeNode<int>() { Data = 100 };

            tree.Root.Children = new List<TreeNode<int>>()
            {
                new TreeNode<int>(){Data = 50, Parent = tree.Root},
                new TreeNode<int>(){Data = 1, Parent = tree.Root},
                new TreeNode<int>(){Data = 150, Parent = tree.Root},

            };

            tree.Root.Children[2].Children = new List<TreeNode<int>>()
            {
                new TreeNode<int>(){Data = 30, Parent = tree.Root.Children[2]},
            };
        }

       public void CreatePersonTree()
        {

            Tree<Person> company = new Tree<Person>();
            company.Root = new TreeNode<Person>()
            {
                Data = new Person( 1000, "Marcin Jamro", "CEO" ),
                Parent = null
            };

            company.Root.Children = new List<TreeNode<Person>>()
            {
                new TreeNode<Person>()
                {
                    Data = new Person(1, "John Smith", "Head of Development"),
                    Parent = company.Root
                },
                new TreeNode<Person>()
                {
                    Data = new Person(50, "Mary Fox", "Head of Research"),
                    Parent = company.Root
                },
                new TreeNode<Person>()
                {
                    Data = new Person(150, "Lily Smith", "Head of Sales"),
                    Parent = company.Root
                }

            };

            company.Root.Children[2].Children = new List<TreeNode<Person>>()
            {
                new TreeNode<Person>()
                {
                    Data = new Person(30, "Anthony Black", "Sales Specialist"),
                    Parent = company.Root.Children[2]
                }
            };

        }
    }
}
