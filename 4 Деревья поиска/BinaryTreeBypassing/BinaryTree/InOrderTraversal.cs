﻿using System.Collections.Generic;

namespace BinaryTree
{
    public class InOrderTraversal : TraversalStrategy
    {
        public override IEnumerator<T> Traversal<T>(BinaryTreeNode<T> node)
        {
            var stack = new Stack<BinaryTreeNode<T>>();
            
            while (stack.Count > 0 || node != null)
            {
                if (node != null)
                {
                    stack.Push(node);
                    node = node.Left;
                }
                else
                {
                    node = stack.Pop();
                    yield return node.Value;
                    node = node.Right;
                }
            }
        }
    }
}
