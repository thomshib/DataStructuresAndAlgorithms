using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresAndAlgorithms.Tree.BST
{
   public  class TreeNode<T>
    {
        public T Data { get; set; }
        public List<TreeNode<T>> Children { get; set; }
    }
}
