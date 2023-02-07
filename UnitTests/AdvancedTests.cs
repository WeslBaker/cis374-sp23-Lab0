using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab0;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestClass]
    public class AdvancedTests
    {

        [TestMethod]
        public void MinKey1()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            tree.Add(10, 10);
            tree.Add(5, 5);
            tree.Add(20, 10);
            tree.Add(15, 10);
            tree.Add(25, 10);
            tree.Add(1, 10);
            tree.Add(12, 10);

            Assert.AreEqual(1, tree.MinKey);
        }

        [TestMethod]
        public void MinKey2()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            tree.Add(10, 10);
            tree.Add(5, 5);
            tree.Add(20, 10);
            tree.Add(15, 10);
            tree.Add(25, 10);
            tree.Add(12, 10);

            Assert.AreEqual(5, tree.MinKey);
        }

        [TestMethod]
        public void MinKey3()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            tree.Add(10, 10);
            tree.Add(20, 10);
            tree.Add(15, 10);
            tree.Add(25, 10);
            tree.Add(12, 10);

            Assert.AreEqual(10, tree.MinKey);
        }
        [TestMethod]
        public void MedianKey1()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            for (int i = 0; i < 51; i++)
            {
                tree.Add(i, i + 1);
            }
            Assert.AreEqual(25.0, tree.MedianKey);
        }

        [TestMethod]
        public void MedianKey2()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            for (int i = 0; i < 52; i++)
            {
                tree.Add(i, i + 1);
            }
            Assert.AreEqual(25.5, tree.MedianKey);
        }

        [TestMethod]
        public void MedianKey3()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            tree.Add(1, 3);
            Assert.AreEqual(1.0, tree.MedianKey);
        }

        [TestMethod]
        public void MedianKey4()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            tree.Add(1, 3);
            tree.Add(2, 4);
            Assert.AreEqual(1.5, tree.MedianKey);
        }

        [TestMethod]
        public void MedianKey5()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            tree.Add(1, 3);
            tree.Add(2, 3);
            tree.Add(3, 3);
            tree.Add(10, 3);
            tree.Add(30, 3);
            Assert.AreEqual(3.0, tree.MedianKey);
        }

        [TestMethod]
        public void MedianKey6()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            tree.Add(10, 3);
            tree.Add(30, 3);
            tree.Add(35, 3);
            tree.Add(1, 3);
            tree.Add(2, 3);
            tree.Add(3, 3);
            Assert.AreEqual(6.5, tree.MedianKey);
        }

        [TestMethod]
        public void Next1()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            int index = 0;
            for (int i = 0; i < 50; i++)
            {
                index = (i + 13) % 50;
                tree.Add(index, index);
            }

            BinarySearchTreeNode<int> current = new BinarySearchTreeNode<int>(1,1);
            for (int i = 0; i < 49; i++)
            {
                current = tree.GetNode(i);
                Assert.AreEqual(tree.Search(i + 1), tree.Next(current).Value);
            }
        }

        [TestMethod]
        public void Next2()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            tree.Add(5, 5);
            tree.Add(4, 5);
            Assert.AreEqual(tree.Search(5), tree.Next(tree.GetNode(4)).Value);
        }

        [TestMethod]
        public void Next3()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            tree.Add(4, 5);
            tree.Add(5, 5);
            Assert.AreEqual(tree.Search(5), tree.Next(tree.GetNode(4)).Value);
        }

        [TestMethod]
        public void Next4Edge()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            tree.Add(4, 5);
            tree.Add(5, 5);
            Assert.IsNull(tree.Next(tree.GetNode(5)));
        }

        [TestMethod]
        public void Prev1()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            int index = 0;
            for (int i = 0; i < 50; i++)
            {
                index = (i + 13) % 50;
                tree.Add(index, index);
            }

            BinarySearchTreeNode<int> current = new BinarySearchTreeNode<int>(1, 1);
            for (int i = 1; i < 50; i++)
            {
                current = tree.GetNode(i);
                Assert.AreEqual(tree.Search(i - 1), tree.Prev(current).Value);
            }
        }

        [TestMethod]
        public void Prev2()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            tree.Add(4, 5);
            tree.Add(5, 5);
            Assert.AreEqual(tree.Search(4), tree.Prev(tree.GetNode(5)).Value);
        }

        [TestMethod]
        public void Prev3()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            tree.Add(5, 5);
            tree.Add(4, 5);
            Assert.AreEqual(tree.Search(4), tree.Prev(tree.GetNode(5)).Value);
        }

        [TestMethod]
        public void Prev4Edge()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            tree.Add(4, 5);
            tree.Add(5, 5);
            Assert.IsNull(tree.Prev(tree.GetNode(4)));
        }

        [TestMethod]
        public void Range1()
        {
            int min = 3;
            int max = 40;
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            int index = 0;
            for (int i = 0; i < 50; i++)
            {
                index = (i + 13) % 50;
                tree.Add(index, index);
            }
            List<BinarySearchTreeNode<int>> range = tree.RangeSearch(min, max);
            for (int i = min; i < (max + 1); i++)
            {
                Assert.IsTrue(range.Contains(tree.GetNode(i)));
            }
        }

        [TestMethod]
        public void Range2()
        {
            int min = 0;
            int max = 49;
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            int index = 0;
            for (int i = 0; i < 50; i++)
            {
                index = (i + 13) % 50;
                tree.Add(index, index);
            }
            List<BinarySearchTreeNode<int>> range = tree.RangeSearch(min, max);
            for (int i = min; i < (max + 1); i++)
            {
                Assert.IsTrue(range.Contains(tree.GetNode(i)));
            }
        }

        [TestMethod]
        public void Range3()
        {
            int min = 48;
            int max = 49;
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            int index = 0;
            for (int i = 0; i < 50; i++)
            {
                index = (i + 13) % 50;
                tree.Add(index, index);
            }
            List<BinarySearchTreeNode<int>> range = tree.RangeSearch(min, max);
            for (int i = min; i < (max + 1); i++)
            {
                Assert.IsTrue(range.Contains(tree.GetNode(i)));
            }
        }

        [TestMethod]
        public void Range4()
        {
            int min = 49;
            int max = 49;
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            int index = 0;
            for (int i = 0; i < 50; i++)
            {
                index = (i + 13) % 50;
                tree.Add(index, index);
            }
            List<BinarySearchTreeNode<int>> range = tree.RangeSearch(min, max);
            for (int i = min; i < (max + 1); i++)
            {
                Assert.IsTrue(range.Contains(tree.GetNode(i)));
            }
        }

        [TestMethod]
        public void Range5()
        {
            int min = 0;
            int max = 0;
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            int index = 0;
            for (int i = 0; i < 50; i++)
            {
                index = (i + 13) % 50;
                tree.Add(index, index);
            }
            List<BinarySearchTreeNode<int>> range = tree.RangeSearch(min, max);
            for (int i = min; i < (max + 1); i++)
            {
                Assert.IsTrue(range.Contains(tree.GetNode(i)));
            }
        }

        [TestMethod]
        public void Range6()
        {
            int min = 23;
            int max = 33;
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            int index = 0;
            for (int i = 0; i < 50; i++)
            {
                index = (i + 13) % 50;
                tree.Add(index, index);
            }
            List<BinarySearchTreeNode<int>> range = tree.RangeSearch(min, max);
            for (int i = min; i < (max + 1); i++)
            {
                Assert.IsTrue(range.Contains(tree.GetNode(i)));
            }
        }

        [TestMethod]
        public void Range7()
        {
            int min = 7;
            int max = 37;
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            int index = 0;
            for (int i = 0; i < 50; i++)
            {
                index = (i + 13) % 50;
                tree.Add(index, index);
            }
            List<BinarySearchTreeNode<int>> range = tree.RangeSearch(min, max);
            for (int i = min; i < (max + 1); i++)
            {
                Assert.IsTrue(range.Contains(tree.GetNode(i)));
            }
        }

        [TestMethod]
        public void Range8Edge()
        {
            int min = -1;
            int max = 37;
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            int index = 0;
            for (int i = 0; i < 50; i++)
            {
                index = i + 50;
                tree.Add(index, index);
            }
            List<BinarySearchTreeNode<int>> range = tree.RangeSearch(min, max);
            Assert.AreEqual(0, range.Count);
        }
    }
}