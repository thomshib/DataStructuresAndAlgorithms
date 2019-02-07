using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresAndAlgorithms.Tree
{
    public class QuizItem
    {
        public string Text { get; set; }
        public QuizItem(string text) => Text = text;
    }
    public class BinaryTreeSample
    {
        BinaryTree<QuizItem> tree;
        public BinaryTreeSample()
        {
            tree = GetTree();

            BinaryTreeNode<QuizItem> node = tree.Root;
            while(node != null)
            {
                if( node.Left != null || node.Right != null)
                {
                    WriteAnswer(node.Data.Text);

                    switch (Console.ReadKey(true).Key)
                    {
                        case ConsoleKey.Y:
                            WriteAnswer(" Yes");
                            node = node.Left;
                            break;
                        case ConsoleKey.N:
                            WriteAnswer(" No");
                            node = node.Right;
                            break;

                    }
                }
                else
                {
                    WriteAnswer(node.Data.Text);
                    node = null;
                }
            }
        }

        private void WriteAnswer(string text)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        private BinaryTree<QuizItem> GetTree()
        {
            BinaryTree<QuizItem> t = new BinaryTree<QuizItem>();

            t.Root = new BinaryTreeNode<QuizItem>()
            {
                Data = new QuizItem("Do you have experience in developing applications ? "),
                Children = new List<TreeNode<QuizItem>>()
                {
                    new BinaryTreeNode<QuizItem>()
                    {
                        Data = new QuizItem("Have you worked as a developer for more than 5 years ? "),
                        Children = new List<TreeNode<QuizItem>>()
                        {
                            new BinaryTreeNode<QuizItem>(){ Data = new QuizItem("Apply as a senior developer!")},
                            new BinaryTreeNode<QuizItem>(){ Data = new QuizItem("Apply as a middle developer!")}
                        }
                    },
                    new BinaryTreeNode<QuizItem>()
                    {
                        Data = new QuizItem("Have you completed the university?"),
                        Children = new List<TreeNode<QuizItem>>()
                        {
                            new BinaryTreeNode<QuizItem>(){ Data = new QuizItem("Apply for a junior developer!")},
                            new BinaryTreeNode<QuizItem>(){ Data = new QuizItem("Will you find some time during the semester?"),
                            Children = new List<TreeNode<QuizItem>>()
                            {
                                 new BinaryTreeNode<QuizItem>(){ Data = new QuizItem("Apply for our long-time internship program!")},
                                 new BinaryTreeNode<QuizItem>(){ Data = new QuizItem("Apply for summer internship program!")}
                            }
                                
                            }
                        }

                    }
    

                }

            };


            t.Count = 9;

            return t;
        }
    }
}
