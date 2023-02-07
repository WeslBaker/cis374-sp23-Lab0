using System;
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

        // TODO
        public int Height => HeightRecursive(Root);

        private int HeightRecursive(BinarySearchTreeNode<T> node)
        {
            if (node == null)
            {
                return -1;
            }

            int leftHeight = HeightRecursive(node.Left);
            int rightheight = HeightRecursive(node.Right);

            return 1 + Math.Max(leftHeight, rightheight);
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
            else if (node.Right == null)
            {
                return node.Key;
            }
            else
            {
                return MinKeyRecursive(node.Right);
            }
        }

        // TODO
        Tuple<int, T> IBinarySearchTree<T>.Min
         {
            get
            {
                if(isEmpty)
                {
                    return null;
                }
                var minNode = minNode(Root);
                return Tuple.Create(minNode.Key, minNode.Value);
            }
            
        }

        // TODO
        Tuple<int, T> IBinarySearchTree<T>.Max
        {
            get
            {
                if (isEmpty)
                {
                    return null;
                }
                var maxNode = maxNode(Root);
                return Tuple.Create(maxNode.Key, maxNode.Value);
            }

        }
        public BinarySearchTreeNode<T> MinNode(BinarySearchTreeNode<T> node)
        {
            return MinNodeRecursive(node);
        }
        private BinarySearchTreeNode<T> MinNodeRecursive(BinarySearchTreeNode<T> node)
        {
            if (node.Left == null)
            {
                return node;
            }
            return MinNodeRecursive(node.Left);
        }

        public BinarySearchTreeNode<T> MaxNode(BinarySearchTreeNode<T> node)
        {
            return MaxNodeRecursive(node);
        }
        private BinarySearchTreeNode<T> MaxNodeRecursive(BinarySearchTreeNode<T> node)
        {
            if (node.Right == null)
            {
                return node;
            }
            return MaxNodeRecursive(node.Right);
        }

        // TODO
        public double? MedianKey
        {
            get
            {
                //get the inorder keys
                var keys = InOrderKeys;

                //odd
                if(keys.Count % 2 == 1)
                {
                    return keys[keys.Count / 2];
                }
                else
                {
                    return (keys[keys.Count / 2] + keys[keys.Count / 2 - 1]) / 2.0;
                }
            }
        }


        public BinarySearchTreeNode<T>? GetNode(int key)
        {
            return GetNodeRecursive(Root, key);
        }

        private BinarySearchTreeNode<T>? GetNodeRecursive(BinarySearchTreeNode<T> node, int key)
        {
            if(node == null)
            {
                return null;
            }
            if(node.Key == key)
            {
                return node;
            }
            else if(key < node.Key)
            {
                return GetNodeRecursive(node.Left, key);
            }
            else
            {
                return GetNodeRecursive(node.Right, key);
            }
        }


        // TODO
        public void Add(int key, T value)
        {
            BinarySearchTreeNode<T> newNode = new BinarySearchTreeNode<T>(key, value);
            
            if(Root == null)
            {
                Root = newNode;
                Count++;
            }
            else
            {
                AddRecursive(key, value, Root);
            }
        }
        // TODO
        private void AddRecursive(int key, T value, BinarySearchTreeNode<T> node)
        {
            BinarySearchTreeNode<T> nodeToAdd = new BinarySearchTreeNode<T>(key, value);


            if(node.Key == node.Key)
            {
                return;
            }
            if(nodeToAdd.Key < node.Key)
            {
                if(node.Left == null)
                {
                    node.Left = nodeToAdd;
                    nodeToAdd.Parent = node;
                    Count++;
                }
                else
                {
                    AddRecursive(nodeToAdd.Key, nodeToAdd.Value, node.Left);
                }
            }
            else if(nodeToAdd.Key > node.Key)
            {
                if(node.Right == null)
                {
                    node.Right = nodeToAdd;
                    nodeToAdd.Parent = node;
                    Count++;
                }
                else
                {
                    AddRecursive(nodeToAdd.Key, nodeToAdd.Value, node.Right);
                }
                
            }
        }

        // TODO
        public void Clear()
        {
            Root = null;
        }

        // TODO
        public bool Contains(int key)
        {
            var node = GetNode(key);

            if(node == null)
            {
                return false;
            }
            return true;
        }

        // TODO
        public BinarySearchTreeNode<T> Next(BinarySearchTreeNode<T> node)
        {
            int 
        }

        // TODO
        public BinarySearchTreeNode<T> Prev(BinarySearchTreeNode<T> node)
        {
            throw new NotImplementedException();
        }

        // TODO
        public List<BinarySearchTreeNode<T>> RangeSearch(int min, int max)
        {
            throw new NotImplementedException();
        }

        public void Remove(int key)
        {
            var nodeToDelete = GetNode(key);
            var parent = nodeToDelete.Parent;

            if(nodeToDelete == null)
            {
                return;
            }
            Count--;

            //case 1: Leaf node
            if (nodeToDelete.Left == null && nodeToDelete.Right == null)
            {
                if(parent.Left == nodeToDelete)
                {
                    parent.Left = null;
                    nodeToDelete.Parent = null;
                }
                else
                {
                    parent.Right = null;
                    nodeToDelete.Parent = null;
                }
            }
            //case 2: Parent of 1 child
            if (nodeToDelete.Left == null && nodeToDelete.Right != null)
            {
                //only has a right child
                var child = nodeToDelete.Right;
                if (parent.Left == nodeToDelete)
                {
                    parent.Right = child;
                    child.Parent = parent;
                    nodeToDelete.Parent = null;
                    nodeToDelete.Right = null;
                }
                else if (parent.Right == nodeToDelete)
                {
                    parent.Right = child;
                    child.Parent = parent;
                    nodeToDelete.Parent = null;
                    nodeToDelete.Left = null;
                }
            }
            if (nodeToDelete.Right == null && nodeToDelete.Left != null)
            {
                //only has left child
                var child = nodeToDelete.Left;
                if (parent.Left == nodeToDelete)
                {
                    parent.Left = child;
                    child.Parent = parent;
                    nodeToDelete.Parent = null;
                }
                else if (parent.Right == nodeToDelete)
                {
                    parent.Left = child;
                    child.Parent = parent;
                    nodeToDelete.Parent = null;
                }
            }
            //case 3: Parent of 2 children
            if(nodeToDelete.Left != null && nodeToDelete.Right != null)
            {
                nodeToDelete = nodeToDelete.Next;
                
            }
        }

        // TODO
        public T Search(int key)
        {
            if(Contains(key))
            {
                return GetNode(key).Value;
            }
            return default(T);
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
            //Left
            //Root
            //Right
            if(node == null)
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
            //Root
            //Left
            //Right

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
    }
}

