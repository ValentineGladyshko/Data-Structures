using DataStructures;

namespace Data_Structures_Library_Test
{
    [TestFixture]
    public class RedBlackTreeTests
    {
        private RedBlackTree<int, int> _redBlackTree;
        [SetUp]
        public void Setup()
        {
            _redBlackTree = new RedBlackTree<int, int>();
        }

        [Test]
        public void Find_FindInEmptyTree_ReturnFalse()
        {
            Assert.That(_redBlackTree.Find(0), Is.False);
            Assert.That(_redBlackTree.isValidRedBlackTree, Is.True);
        }

        [Test]
        public void Find_FindValueSameAsInsert_ReturnTrue()
        {
            _redBlackTree.Insert(0, 0);
            Assert.That(_redBlackTree.Find(0), Is.True);
        }

        [Test]
        public void Find_FindValueNotSameAsInsert_ReturnFalse()
        {
            _redBlackTree.Insert(0, 0);
            Assert.That(_redBlackTree.Find(1), Is.False);
        }

        [TestCase(new int[] { 0 })]
        [TestCase(new int[] { 0, 1 })]
        [TestCase(new int[] { 0, -1 })]
        [TestCase(new int[] { 0, 1, 2 })]
        [TestCase(new int[] { 0, -1, -2 })]
        [TestCase(new int[] { 0, 1, -1, -2 })]
        [TestCase(new int[] { 0, -1, 1, 2 })]
        [TestCase(new int[] { 0, -1, 2, 1, 3, 4 })]
        [TestCase(new int[] { 0, 1, -2, -1, -3, -4 })]
        [TestCase(new int[] { 0, 3, -1, 1, 2 })]
        [TestCase(new int[] { 0, -3, 1, -1, -2 })]
        public void Insert_InsertIntoTree_TreeContainsElement(int[] value)
        {
            foreach (int element in value)
            {
                _redBlackTree.Insert(element, 0);
            }
            foreach (int element in value)
            {
                Assert.That(_redBlackTree.Find(element), Is.True);
            }
            Assert.That(_redBlackTree.isValidRedBlackTree, Is.True);
        }

        [Test]
        public void Remove_RemoveFromEmptyTree_NothingHappens()
        {
            _redBlackTree.Remove(0);
            Assert.That(_redBlackTree.Find(0), Is.False);
            Assert.That(_redBlackTree.isValidRedBlackTree, Is.True);
        }

        [TestCase(0, 1)]
        [TestCase(0, -1)]
        public void Remove_RemoveNotExistedElementFromTreeWithOneElement_NothingHappens(int value, int remove)
        {
            _redBlackTree.Insert(value, 0);
            _redBlackTree.Remove(remove);
            Assert.That(_redBlackTree.Find(value), Is.True);
            Assert.That(_redBlackTree.isValidRedBlackTree, Is.True);
        }

        [TestCase(new int[] { 0 }, 0)]
        [TestCase(new int[] { 0, 1 }, 0)]
        [TestCase(new int[] { 0, -1 }, 0)]
        [TestCase(new int[] { 0, 1 }, 1)]
        [TestCase(new int[] { 0, -1 }, -1)]
        [TestCase(new int[] { 0, -1, 1 }, 0)]
        [TestCase(new int[] { 0, -1, 1, 2 }, 0)]
        [TestCase(new int[] { 0, -1, 2, 1, 3 }, -1)]
        [TestCase(new int[] { 0, 1, -2, -1, -3 }, 1)]
        [TestCase(new int[] { 0, -1, 5, 6, 2, 1, 3, 4 }, 0)]
        [TestCase(new int[] { 0, 1, -5, -6, -2, -1, -3, -4 }, -5)]
        [TestCase(new int[] { 0, -1, 5, 6, 2, 1, 3, 4 }, 5)]
        [TestCase(new int[] { 0, -1, 2, 1, 5, 6, 3, 4 }, 6)]
        [TestCase(new int[] { 0, -1, 2, 1, 3, 4 }, -1)]
        [TestCase(new int[] { 0, 1, -2, -1, -3, -4 }, 1)]

        public void Remove_RemoveElementFromTree_ElementRemoved(int[] array, int value)
        {
            foreach (int element in array)
            {
                _redBlackTree.Insert(element, 0);
            }
            _redBlackTree.Remove(value);
            array = array.Where(val => val != value).ToArray();
            foreach (int element in array)
            {
                Assert.That(_redBlackTree.Find(element), Is.True);
            }
            Assert.That(_redBlackTree.Find(value), Is.False);
            Assert.That(_redBlackTree.isValidRedBlackTree, Is.True);
        }

        [TestCase(new int[] { 0 }, new int[] { 1 }, 0, 1)]
        [TestCase(new int[] { 0, -1 }, new int[] { 2, 3 }, -1, 3)]
        [TestCase(new int[] { 0, 1 }, new int[] { 2, 3 }, 1, 3)]
        public void Get_GetValueByExistedKeyFromTree_ReceivedValue(int[] keyArray, int[] valueArray, int key, int value)
        {
            for (int i = 0; i < keyArray.Length && i < valueArray.Length; i++)
            {
                _redBlackTree.Insert(keyArray[i], valueArray[i]);
            }
            var result = _redBlackTree.Get(key);
            Assert.That(result, Is.EqualTo(value));
        }

        [Test]
        public void Get_GetValueByNotExistedKeyFromTreeWithOneElement_ReceivedDefaultValueForType()
        {
            _redBlackTree.Insert(2, 1);
            var value = _redBlackTree.Get(1);
            Assert.That(value, Is.EqualTo(0));
        }

        [Test]
        public void Get_GetValueFromEmptyTree_ReceivedDefaultValueForType()
        {
            var value = _redBlackTree.Get(1);
            Assert.That(value, Is.EqualTo(0));
        }

        [Test]
        public void Minimum_GetMinimumFromTree_ReceivedMinimum()
        {
            _redBlackTree.Insert(0, 0);
            _redBlackTree.Insert(1, 0);
            _redBlackTree.Insert(-1, 0);
            var value = _redBlackTree.Minimum();
            Assert.That(value, Is.EqualTo((-1, 0)));
        }

        [Test]
        public void Maximum_GetMinimumFromTree_ReceivedMaximum()
        {
            _redBlackTree.Insert(0, 0);
            _redBlackTree.Insert(1, 0);
            _redBlackTree.Insert(-1, 0);
            var value = _redBlackTree.Maximum();
            Assert.That(value, Is.EqualTo((1, 0)));
        }

        [Test]
        public void InfixTraverse_InfixTraverseInTree_ReceivedList()
        {
            _redBlackTree.Insert(0, 2);
            _redBlackTree.Insert(1, 3);
            _redBlackTree.Insert(-1, 4);
            var list = new List<IComparable>();
            list.Add(-1);
            list.Add(0);
            list.Add(1);
            var result = _redBlackTree.InfixTraverse();
            Assert.That(result, Is.EqualTo(list));
        }

        [Test]
        public void PrefixTraverse_PrefixTraverseInTree_ReceivedList()
        {
            _redBlackTree.Insert(0, 2);
            _redBlackTree.Insert(1, 3);
            _redBlackTree.Insert(-1, 4);
            var list = new List<IComparable>();
            list.Add(0);
            list.Add(-1);
            list.Add(1);
            var result = _redBlackTree.PrefixTraverse();
            Assert.That(result, Is.EqualTo(list));
        }

        [Test]
        public void PostfixTraverse_PostfixTraverseInTree_ReceivedList()
        {
            _redBlackTree.Insert(0, 2);
            _redBlackTree.Insert(1, 3);
            _redBlackTree.Insert(-1, 4);
            var list = new List<IComparable>();
            list.Add(-1);
            list.Add(1);
            list.Add(0);
            var result = _redBlackTree.PostfixTraverse();
            Assert.That(result, Is.EqualTo(list));
        }

        [Test]
        public void InfixTraverseValues_InfixTraverseValuesInTree_ReceivedList()
        {
            _redBlackTree.Insert(0, 2);
            _redBlackTree.Insert(1, 3);
            _redBlackTree.Insert(-1, 4);
            var list = new List<int>();
            list.Add(4);
            list.Add(2);
            list.Add(3);
            var result = _redBlackTree.InfixTraverseValues();
            Assert.That(result, Is.EqualTo(list));
        }

        [Test]
        public void PrefixTraverseValues_PrefixTraverseValuesInTree_ReceivedList()
        {
            _redBlackTree.Insert(0, 2);
            _redBlackTree.Insert(1, 3);
            _redBlackTree.Insert(-1, 4);
            var list = new List<int>();
            list.Add(2);
            list.Add(4);
            list.Add(3);
            var result = _redBlackTree.PrefixTraverseValues();
            Assert.That(result, Is.EqualTo(list));
        }

        [Test]
        public void PostfixTraverseValues_PostfixTraverseValuesInTree_ReceivedList()
        {
            _redBlackTree.Insert(0, 2);
            _redBlackTree.Insert(1, 3);
            _redBlackTree.Insert(-1, 4);
            var list = new List<int>();
            list.Add(4);
            list.Add(3);
            list.Add(2);
            var result = _redBlackTree.PostfixTraverseValues();
            Assert.That(result, Is.EqualTo(list));
        }

        [Test]
        public void Traverse_TraverseInEmptyTree_NoExeptions()
        {
            Assert.DoesNotThrow(() => _redBlackTree.Traverse());
        }

        [Test]
        public void Traverse_TraverseInTree_NoExeptions()
        {
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            _redBlackTree.Insert(0, 2);
            _redBlackTree.Insert(1, 3);
            _redBlackTree.Insert(-1, 4);
            Assert.DoesNotThrow(() => _redBlackTree.Traverse());
        }
    }
}