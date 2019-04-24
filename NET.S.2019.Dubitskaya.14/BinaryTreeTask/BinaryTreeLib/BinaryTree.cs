using System;
using System.Collections.Generic;

namespace BinaryTreeLib
{
    /// <summary>
    /// Represents binary tree abstraction and provides it's methods
    /// </summary>
    public class BinaryTree<T>
    {
        private Node<T> _root;
        private Comparison<T> _comparison;

        /// <summary>
        /// Initializes a new instance of the Book class taking delegate as a parameter
        /// </summary>
        /// <param name="comp"></param>
        /// <returns>instance</returns>
        public BinaryTree(Comparison<T> comp)
        {
            _root = null;
            if (comp != null)
                _comparison = comp;
            else
                _comparison = Comparer<T>.Default.Compare;
        }

        /// <summary>
        /// Initializes a new instance of the Book class taking interface as a parameter
        /// </summary>
        /// <param name="comparer"></param>
        /// <returns>instance</returns>
        public BinaryTree(IComparer<T> comparer) : this(comparer.Compare)
        {
        }

        /// <summary>
        /// Initializes a new instance of the Book class without parameter
        /// </summary>
        /// <returns>instance</returns>
        public BinaryTree() : this((Comparison<T>)null)
        {
        }

        /// <summary>
        /// Invokes algorithm for adding new element to the tree
        /// </summary>
        /// <param name="value"></param>
        public void AddElement(T value)
        {
            if (value == null)
                throw new ArgumentNullException();

            _root = Add(_root, value);
        }

        /// <summary>
        /// Invokes algorithm for adding group of new elements to the tree
        /// </summary>
        /// <param name="value"></param>
        public void AddElements(IEnumerable<T> elements)
        {
            if (elements == null)
                throw new ArgumentNullException();

            foreach (T value in elements)
            {
                if (value == null)
                    throw new ArgumentNullException();

                _root = Add(_root, value);
            }
        }

        /// <summary>
        /// Invokes algorithm that checks if tree contains the element
        /// </summary>
        /// <param name="value"></param>
        public bool Contains(T value)
        {
            if (_root == null)
                throw new NullReferenceException();

            if (value == null)
                throw new ArgumentNullException();

            return Contains(_root, value);
        }

        /// <summary>
        /// Invokes algorithm that returns enumerable for inorder traversal
        /// </summary>
        /// <returns>IEnumerable</returns>
        public IEnumerable<T> InorderTraversal()
        {
            if (_root == null)
                throw new NullReferenceException();

            return Inorder(_root);
        }

        /// <summary>
        /// Invokes algorithm that returns enumerable for preorder traversal
        /// </summary>
        /// <returns>IEnumerable</returns>
        public IEnumerable<T> PreorderTraversal()
        {
            if (_root == null)
                throw new NullReferenceException();

            return Preorder(_root);
        }

        /// <summary>
        /// Invokes algorithm that returns enumerable for postorder traversal
        /// </summary>
        /// <returns>IEnumerable</returns>
        public IEnumerable<T> PostorderTraversal()
        {
            if (_root == null)
                throw new NullReferenceException();

            return Postorder(_root);
        }

        /// <summary>
        /// Recursive method that enumerable for inorder traversal
        /// </summary>
        /// <returns>IEnumerable</returns>
        private IEnumerable<T> Inorder(Node<T> node)
        {
            if (node.left != null)
                foreach (T currValue in Inorder(node.left))
                    yield return currValue;

            yield return node.value;
            if (node.rigth != null)
                foreach (T currValue in Inorder(node.rigth))
                    yield return currValue;
        }

        /// <summary>
        /// Recursive method that enumerable for preorder traversal
        /// </summary>
        /// <returns>IEnumerable</returns>
        private IEnumerable<T> Preorder(Node<T> node)
        {
            yield return node.value;
            if (node.left != null)
                foreach (T currValue in Preorder(node.left))
                    yield return currValue;

            if (node.rigth != null)
                foreach (T currValue in Preorder(node.rigth))
                    yield return currValue;
        }

        /// <summary>
        /// Recursive method that enumerable for postorder traversal
        /// </summary>
        /// <returns>IEnumerable</returns>
        private IEnumerable<T> Postorder(Node<T> node)
        {
            if (node.left != null)
                foreach (T currValue in Postorder(node.left))
                    yield return currValue;

            if (node.rigth != null)
                foreach (T currValue in Postorder(node.rigth))
                    yield return currValue;

            yield return node.value;
        }

        /// <summary>
        /// Recursive method that checks if the element is in the tree
        /// </summary>
        /// <param name="node"></param>
        /// <param name="value"></param>
        private bool Contains(Node<T> node, T value)
        {
            if (node == null)
                return false;

            int tempResult = _comparison(node.value, value);
            if (tempResult == 0)
                return true;
            else if (tempResult > 0)
                return Contains(node.left, value);
            else
                return Contains(node.rigth, value);
        }

        /// <summary>
        /// Recursive method thad adds new element to the tree
        /// </summary>
        /// <param name="node"></param>
        /// <param name="value"></param>
        private Node<T> Add(Node<T> node, T value)
        {
            if (node == null)
                return new Node<T>(value);

            if (_comparison(node.value, value) > 0)
                node.left = Add(node.left, value);
            else
                node.rigth = Add(node.rigth, value);

            return node;
        }
    }
}
