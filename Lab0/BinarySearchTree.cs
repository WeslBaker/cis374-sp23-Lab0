using System;
using System.ComponentModel;
using System.Xml.Linq;

namespace Lab0
{
    public class BinarySearchTree<T> : IBinarySearchTree<T>
    {

        private BinarySearchTreeNode<T> Root { get; set; }

        public BinarySearchTree()
        {
            Root = null;
            Count = 0;
        }

        public bool IsEmpty => Root == null;

        public int Count { get; private set; }

        public int Height => IsEmpty ? 0 : HeightRecursive(Root);

        private int HeightRecursive(BinarySearchTreeNode<T> node)
        {
            if (node == null)
            {
                return -1;
            }

            int leftHeight = HeightRecursive(node.Left);
            int rightHeight = HeightRecursive(node.Right);

            return 1 + Math.Max(leftHeight, rightHeight);
        }

        // TODO
        public int? MinKey => MinKeyRecursive(Root);

        private int? MinKeyRecursive(BinarySearchTreeNode<T> node)
        {
            if (node == null)
            {
                return null;
            }
            else if (node.Left == null)
            {
                return node.Key;
            }
            else
            {
                return MinKeyRecursive(node.Left);
            }
        }

        // TODO
        public int? MaxKey => MaxKeyRecursive(Root);

        private int? MaxKeyRecursive(BinarySearchTreeNode<T> node)
        {
            if (node == null)
            {
                return null;
            }
            else if (node.Left == null)
            {
                return node.Key;
            }
            else
            {
                return MaxKeyRecursive(node.Left);
            }
        }
        // TODO
        public double MedianKey
        {
            get
            {
                // get the inorder keys
                var keys = InOrderKeys;

                //odd number of keys
                if (keys.Count % 2 == 1)
                {
                    int middleIndex = keys.Count / 2;
                    return keys[middleIndex];
                }
                // even number of keys
                else
                {
                    int middleIndex1 = keys.Count / 2 - 1;
                    int middleIndex2 = keys.Count / 2;

                    int sum = keys[middleIndex1] + keys[middleIndex2];

                    return sum / 2.0;
                }

            }
        }
        public BinarySearchTreeNode<T>? GetNode(int key)
        {
            return GetNodeRecursive(Root, key);
        }

        private BinarySearchTreeNode<T> GetNodeRecursive(BinarySearchTreeNode<T> node, int key)
        {
            if (node.Key == key)
            {
                return node;
            }
            else if (node.Key < key)
            {
                return GetNodeRecursive(node.Right, key);
            }
            else
            {
                return GetNodeRecursive(node.Left, key);
            }
        }


        // TODO
        public void Add(int key, T value)
        {
            if (Root == null)
            {
                Root = new BinarySearchTreeNode<T>(key, value);
                Count++;
            }
            else
            {
                AddRecursive(key, value, Root);
            }
        }
        // TODO
        private void AddRecursive(int key, T value, BinarySearchTreeNode<T> parent)
        {
            // duplicate found
            // do not add to BST
            if (key == parent.Key)
            {
                return;
            }

            if (key < parent.Key)
            {
                if (parent.Left == null)
                {
                    var newNode = new BinarySearchTreeNode<T>(key, value); ;
                    parent.Left = newNode;
                    newNode.Parent = parent;
                    Count++;

                }
                else
                {
                    AddRecursive(key, value, parent.Left);
                }
            }
            else
            {
                if (parent.Right == null)
                {
                    var newNode = new BinarySearchTreeNode<T>(key, value);
                    parent.Right = newNode;
                    newNode.Parent = parent;
                    Count++;
                }
                else
                {
                    AddRecursive(key, value, parent.Right);
                }
            }
        }

        // TODO
        public void Clear()
        {
            Root = null;
        }

        public bool Contains(int key)
        {
            if (GetNode(key) == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        // TODO
        public BinarySearchTreeNode<T> Next(BinarySearchTreeNode<T> node)
        {
            int indexOfNode = InOrderKeys.IndexOf(node.Key);
            if(indexOfNode == InOrderKeys.Count - 1)
            {
                return null;
            }
            return GetNode(InOrderKeys[indexOfNode + 1]);

            /*var parent = node.Parent;

            // find the min node in the right child's subtree
            if(node.Right == null)
            {
                if(parent.Left == node)
                {
                    return parent;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return MinNode(node.Right);
            }*/
        }

        // TODO
        public BinarySearchTreeNode<T> Prev(BinarySearchTreeNode<T> node)
        {
            int indexOfNode = InOrderKeys.IndexOf(node.Key);
            if(indexOfNode == 0)
            {
                return null;
            }
            return GetNode(InOrderKeys[indexOfNode - 1]);
            /*var parent = node.Parent;
            // find the max node in the left child's subtree
            if (node.Left == null)
            {
                if (parent.Right == node)
                {
                    return parent;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return MaxNode(node.Left);
            }*/
        }

        // TODO
        /// <summary>
        /// Returns all nodes with keys between the given min and max (inclusive), in order.
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<BinarySearchTreeNode<T>> RangeSearch(int min, int max)
        {

            // METHOD 1 => Use Next()
            // make a list

            // find min node ?

            // until max is reached, find next node, add to list

            //var nodes = new List<BinarySearchTreeNode<T>>();

            // find closest node greater than or equal to min
            //BinarySearchTreeNode<T> startingNode;

            // METHOD 2 => Use InOrderKey

            List<BinarySearchTreeNode<T>> nodeList = new List<BinarySearchTreeNode<T>>();

            if (min > max) {
                return nodeList;
            }

            var orderedKeys = this.InOrderKeys;

            foreach (int key in orderedKeys)
            {
                if (key >= min && key <= max)
                {
                    nodeList.Add(GetNode(key));
                }

                if (key > max)
                {
                    break;
                }
            }

            return nodeList;
        }

        public void Remove(int key)
        {
            var node = GetNode(key);
            var parent = node.Parent;

            if (node == null)
            {
                return;
            }

            Count--;

            // 1) leaf node
            if (node.Left == null && node.Right == null)
            {
                if (parent.Left == node)
                {
                    parent.Left = null;
                    node.Parent = null;
                }
                else if (parent.Right == node)
                {
                    parent.Right = null;
                    node.Parent = null;
                }

                return;
            }

            // 2) parent with 1 child
            if (node.Left == null && node.Right != null)
            {
                // only has a right child
                var child = node.Right;
                if (parent.Left == node)
                {
                    parent.Left = child;
                    child.Parent = parent;
                }
                else if (parent.Right == node)
                {
                    parent.Right = child;
                    child.Parent = parent;
                }

                return;
            }

            if (node.Left != null && node.Right == null)
            {
                // only has a left child
                var child = node.Left;
                if (parent.Left == node)
                {
                    parent.Left = child;
                    child.Parent = parent;

                    node.Parent = null;
                    node.Left = null;
                }
                else if (parent.Right == node)
                {
                    parent.Right = child;
                    child.Parent = parent;

                    node.Parent = null;
                    node.Right = null;
                }

                return;
            }

            // 3) parent with 2 children
            // Find the node to remove
            var nodeToRemove = GetNode(key);

            // Find the next node (successor)
            var next = Next(nodeToRemove);

            // Swap Key and Data from successor to node
            nodeToRemove.Key = next.Key;
            nodeToRemove.Value = next.Value;
            // Remove the successor (a leaf node) (like case 1)
            var nextParent = next.Parent;
            if (nextParent.Left == next)
            {
                nextParent.Left = null;
                next.Parent = null;
            }
            else if (nextParent.Right == next)
            {
                nextParent.Right = null;
                next.Parent = null;
            }
            return;
        }

        // TODO
        public T Search(int key)
        {
            if (Contains(key))
            {
                return GetNode(key).Value;
            }
            else
            {
                return default(T);
            }
        }

        // TODO
        public void Update(int key, T value)
        {
            var nodeToChange = GetNode(key);
            nodeToChange.Value = value;
        }


        // TODO
        public List<int> InOrderKeys
        {
            get
            {
                List<int> keys = new List<int>();
                InOrderKeysRecursive(Root, keys);

                return keys;
            }
        }

        private void InOrderKeysRecursive(BinarySearchTreeNode<T> node, List<int> keys)
        {
            // left
            // root
            // right

            if (node == null)
            {
                return;
            }

            InOrderKeysRecursive(node.Left, keys);
            keys.Add(node.Key);
            InOrderKeysRecursive(node.Right, keys);

        }

        // TODO
        public List<int> PreOrderKeys
        {
            get
            {
                List<int> keys = new List<int>();
                PreOrderKeysRecursive(Root, keys);

                return keys;
            }
        }

        private void PreOrderKeysRecursive(BinarySearchTreeNode<T> node, List<int> keys)
        {
            if (node == null)
            {
                return;
            }

            keys.Add(node.Key);
            PreOrderKeysRecursive(node.Left, keys);
            PreOrderKeysRecursive(node.Right, keys);
        }

        // TODO
        public List<int> PostOrderKeys
        {
            get
            {
                List<int> keys = new List<int>();
                PostOrderKeysRecursive(Root, keys);
                return keys;
            }
        }

        private void PostOrderKeysRecursive(BinarySearchTreeNode<T> node, List<int> keys)
        {
            if (node == null)
            {
                return;
            }
            
            PostOrderKeysRecursive(node.Left, keys);
            PostOrderKeysRecursive(node.Right, keys);
            keys.Add(node.Key);
        }

        public BinarySearchTreeNode<T> MinNode(BinarySearchTreeNode<T> node)
        {
            if(node.Left == null)
            {
                return node;
            }
            else
            {
                return MinNode(node.Left);
            }
        }

        public BinarySearchTreeNode<T> MaxNode(BinarySearchTreeNode<T> node)
        {
            if (node.Right == null)
            {
                return node;
            }
            else
            {
                return MinNode(node.Right);
            }
        }
    }
}

