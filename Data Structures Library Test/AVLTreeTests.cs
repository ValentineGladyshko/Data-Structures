using DataStructures;

namespace Data_Structures_Library_Test
{
    [TestFixture]
    public class AVLTreeTests
    {
        private AVLTree<int, int> _AVLTree;
        [SetUp]
        public void Setup()
        {
            _AVLTree = new AVLTree<int, int>();
        }

        [Test]
        public void Find_FindInEmptyTree_ReturnFalse()
        {
            Assert.IsFalse(_AVLTree.Find(0));
        }

        [Test]
        public void Find_FindValueSameAsInsert_ReturnTrue()
        {
            _AVLTree.Insert(0, 0);
            Assert.IsTrue(_AVLTree.Find(0));
        }

        [Test]
        public void Find_FindValueNotSameAsInsert_ReturnFalse()
        {
            _AVLTree.Insert(0, 0);
            Assert.IsFalse(_AVLTree.Find(1));
        }

        [TestCase(new int[] { 0 })]
        [TestCase(new int[] { 0, 1 })]
        [TestCase(new int[] { 0, -1 })]
        [TestCase(new int[] { 0, 1, 2 })]
        [TestCase(new int[] { 0, -1, -2 })]
        [TestCase(new int[] { 0, 2, 1 })]
        [TestCase(new int[] { 0, -2, -1 })]
        public void Insert_InsertIntoTree_TreeContainsElement(int[] value)
        {
            foreach (int element in value)
            {
                _AVLTree.Insert(element, 0);
            }
            foreach (int element in value)
            {
                Assert.That(_AVLTree.Find(element), Is.True);
            }
        }

        [Test]
        public void Remove_RemoveFromEmptyTree_NothingHappens()
        {
            _AVLTree.Remove(0);
            Assert.That(_AVLTree.Find(0), Is.False);
        }

        [TestCase(0, 1)]
        [TestCase(0, -1)]
        public void Remove_RemoveNotExistedElementFromTreeWithOneElement_NothingHappens(int value, int remove)
        {
            _AVLTree.Insert(value, 0);
            _AVLTree.Remove(remove);
            Assert.IsTrue(_AVLTree.Find(value));
        }

        [TestCase(new int[] { 0 }, 0)]
        [TestCase(new int[] { 0, 1 }, 0)]
        [TestCase(new int[] { 0, -1 }, 0)]
        [TestCase(new int[] { 1, 0, 2 }, 0)]
        [TestCase(new int[] { -1, 0, -2 }, 0)]
        [TestCase(new int[] { 1, 0, 2 }, 1)]
        [TestCase(new int[] { 1, -1, 2, 0 }, 1)]
        public void Remove_RemoveElementFromTree_ElementRemoved(int[] array, int value)
        {
            foreach (int element in array)
            {
                _AVLTree.Insert(element, 0);
            }
            _AVLTree.Remove(value);
            array = array.Where(val => val != value).ToArray();
            foreach (int element in array)
            {
                Assert.That(_AVLTree.Find(element), Is.True);
            }
            Assert.That(_AVLTree.Find(value), Is.False);
        }

        [TestCase(new int[] { 0 }, new int[] { 1 }, 0, 1)]
        [TestCase(new int[] { 0, -1 }, new int[] { 2, 3 }, -1, 3)]
        [TestCase(new int[] { 0, 1 }, new int[] { 2, 3 }, 1, 3)]
        public void Get_GetValueByExistedKeyFromTree_ReceivedValue(int[] keyArray, int[] valueArray, int key, int value)
        {
            for (int i = 0; i < keyArray.Length && i < valueArray.Length; i++)
            {
                _AVLTree.Insert(keyArray[i], valueArray[i]);
            }
            var result = _AVLTree.Get(key);
            Assert.That(result, Is.EqualTo(value));
        }

        [Test]
        public void Get_GetValueByNotExistedKeyFromTreeWithOneElement_ReceivedDefaultValueForType()
        {
            _AVLTree.Insert(2, 1);
            var value = _AVLTree.Get(1);
            Assert.That(value, Is.EqualTo(0));
        }

        [Test]
        public void Get_GetValueFromEmptyTree_ReceivedDefaultValueForType()
        {
            var value = _AVLTree.Get(1);
            Assert.That(value, Is.EqualTo(0));
        }

        [Test]
        public void Minimum_GetMinimumFromTree_ReceivedMinimum()
        {
            _AVLTree.Insert(0, 0);
            _AVLTree.Insert(1, 0);
            _AVLTree.Insert(-1, 0);
            var value = _AVLTree.Minimum();
            Assert.That(value, Is.EqualTo((-1, 0)));
        }

        [Test]
        public void Maximum_GetMinimumFromTree_ReceivedMaximum()
        {
            _AVLTree.Insert(0, 0);
            _AVLTree.Insert(1, 0);
            _AVLTree.Insert(-1, 0);
            var value = _AVLTree.Maximum();
            Assert.That(value, Is.EqualTo((1, 0)));
        }

        [Test]
        public void InfixTraverse_InfixTraverseInTree_ReceivedList()
        {
            _AVLTree.Insert(0, 2);
            _AVLTree.Insert(1, 3);
            _AVLTree.Insert(-1, 4);
            var list = new List<IComparable>();
            list.Add(-1);
            list.Add(0);
            list.Add(1);
            var result = _AVLTree.InfixTraverse();
            Assert.That(result, Is.EqualTo(list));
        }

        [Test]
        public void PrefixTraverse_PrefixTraverseInTree_ReceivedList()
        {
            _AVLTree.Insert(0, 2);
            _AVLTree.Insert(1, 3);
            _AVLTree.Insert(-1, 4);
            var list = new List<IComparable>();
            list.Add(0);
            list.Add(-1);
            list.Add(1);
            var result = _AVLTree.PrefixTraverse();
            Assert.That(result, Is.EqualTo(list));
        }

        [Test]
        public void PostfixTraverse_PostfixTraverseInTree_ReceivedList()
        {
            _AVLTree.Insert(0, 2);
            _AVLTree.Insert(1, 3);
            _AVLTree.Insert(-1, 4);
            var list = new List<IComparable>();
            list.Add(-1);
            list.Add(1);
            list.Add(0);
            var result = _AVLTree.PostfixTraverse();
            Assert.That(result, Is.EqualTo(list));
        }

        [Test]
        public void InfixTraverseValues_InfixTraverseValuesInTree_ReceivedList()
        {
            _AVLTree.Insert(0, 2);
            _AVLTree.Insert(1, 3);
            _AVLTree.Insert(-1, 4);
            var list = new List<int>();
            list.Add(4);
            list.Add(2);
            list.Add(3);
            var result = _AVLTree.InfixTraverseValues();
            Assert.That(result, Is.EqualTo(list));
        }

        [Test]
        public void PrefixTraverseValues_PrefixTraverseValuesInTree_ReceivedList()
        {
            _AVLTree.Insert(0, 2);
            _AVLTree.Insert(1, 3);
            _AVLTree.Insert(-1, 4);
            var list = new List<int>();
            list.Add(2);
            list.Add(4);
            list.Add(3);
            var result = _AVLTree.PrefixTraverseValues();
            Assert.That(result, Is.EqualTo(list));
        }

        [Test]
        public void PostfixTraverseValues_PostfixTraverseValuesInTree_ReceivedList()
        {
            _AVLTree.Insert(0, 2);
            _AVLTree.Insert(1, 3);
            _AVLTree.Insert(-1, 4);
            var list = new List<int>();
            list.Add(4);
            list.Add(3);
            list.Add(2);
            var result = _AVLTree.PostfixTraverseValues();
            Assert.That(result, Is.EqualTo(list));
        }

        [Test]
        public void Traverse_TraverseInEmptyTree_NoExeptions()
        {
            Assert.DoesNotThrow(() => _AVLTree.Traverse());
        }

        [Test]
        public void Traverse_TraverseInTree_NoExeptions()
        {
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            _AVLTree.Insert(0, 2);
            _AVLTree.Insert(1, 3);
            _AVLTree.Insert(-1, 4);
            Assert.DoesNotThrow(() => _AVLTree.Traverse());
        }
    }
}