using DataStructures;

namespace Data_Structures_Library_Test
{
    [TestFixture]
    public class LeftLeaningRedBlackTreeTests
    {
        private LeftLeaningRedBlackTree<int, int> _leftLeaningRedBlackTree;
        [SetUp]
        public void Setup()
        {
            _leftLeaningRedBlackTree = new LeftLeaningRedBlackTree<int, int>();
        }

        [Test]
        public void Find_FindInEmptyTree_ReturnFalse()
        {
            Assert.IsFalse(_leftLeaningRedBlackTree.Find(0));
        }

        [Test]
        public void Find_FindValueSameAsInsert_ReturnTrue()
        {
            _leftLeaningRedBlackTree.Insert(0, 0);
            Assert.IsTrue(_leftLeaningRedBlackTree.Find(0));
        }

        [Test]
        public void Find_FindValueNotSameAsInsert_ReturnFalse()
        {
            _leftLeaningRedBlackTree.Insert(0, 0);
            Assert.IsFalse(_leftLeaningRedBlackTree.Find(1));
        }

        [TestCase(new int[] { 0 })]
        [TestCase(new int[] { 0, 1 })]
        [TestCase(new int[] { 0, -1 })]
        [TestCase(new int[] { 0, 1, 1 })]
        [TestCase(new int[] { 0, 1, 2 })]
        [TestCase(new int[] { 0, -1, -2 })]
        [TestCase(new int[] { 0, 2, 1 })]
        [TestCase(new int[] { 0, -2, -1 })]
        public void Insert_InsertIntoTree_TreeContainsElement(int[] value)
        {
            foreach (int element in value)
            {
                _leftLeaningRedBlackTree.Insert(element, 0);
            }
            foreach (int element in value)
            {
                Assert.That(_leftLeaningRedBlackTree.Find(element), Is.True);
            }
        }

        [Test]
        public void Remove_RemoveFromEmptyTree_NothingHappens()
        {
            _leftLeaningRedBlackTree.Remove(0);
            Assert.That(_leftLeaningRedBlackTree.Find(0), Is.False);
        }

        [TestCase(0, 1)]
        [TestCase(0, -1)]
        public void Remove_RemoveNotExistedElementFromTreeWithOneElement_NothingHappens(int value, int remove)
        {
            _leftLeaningRedBlackTree.Insert(value, 0);
            _leftLeaningRedBlackTree.Remove(remove);
            Assert.IsTrue(_leftLeaningRedBlackTree.Find(value));
        }

        [TestCase(new int[] { 0 }, 0)]
        [TestCase(new int[] { 0, 1 }, 0)]
        [TestCase(new int[] { 0, -1 }, 0)]
        [TestCase(new int[] { 1, 0, 2 }, 0)]
        [TestCase(new int[] { -1, 0, -2 }, 0)]
        [TestCase(new int[] { 1, 0, 2 }, 1)]
        [TestCase(new int[] { 1, -1, 2, 0 }, 1)]
        [TestCase(new int[] { -3, -2, -1, 0, 1, 2, 3 }, 0)]
        public void Remove_RemoveElementFromTree_ElementRemoved(int[] array, int value)
        {
            foreach (int element in array)
            {
                _leftLeaningRedBlackTree.Insert(element, 0);
            }
            _leftLeaningRedBlackTree.Remove(value);
            array = array.Where(val => val != value).ToArray();
            foreach (int element in array)
            {
                Assert.That(_leftLeaningRedBlackTree.Find(element), Is.True);
            }
            Assert.That(_leftLeaningRedBlackTree.Find(value), Is.False);
        }

        [TestCase(new int[] { 0 }, new int[] { 1 }, 0, 1)]
        [TestCase(new int[] { 0, -1 }, new int[] { 2, 3 }, -1, 3)]
        [TestCase(new int[] { 0, 1 }, new int[] { 2, 3 }, 1, 3)]
        public void Get_GetValueByExistedKeyFromTree_ReceivedValue(int[] keyArray, int[] valueArray, int key, int value)
        {
            for (int i = 0; i < keyArray.Length && i < valueArray.Length; i++)
            {
                _leftLeaningRedBlackTree.Insert(keyArray[i], valueArray[i]);
            }
            var result = _leftLeaningRedBlackTree.Get(key);
            Assert.That(result, Is.EqualTo(value));
        }

        [Test]
        public void Get_GetValueByNotExistedKeyFromTreeWithOneElement_ReceivedDefaultValueForType()
        {
            _leftLeaningRedBlackTree.Insert(2, 1);
            var value = _leftLeaningRedBlackTree.Get(1);
            Assert.That(value, Is.EqualTo(0));
        }

        [Test]
        public void Get_GetValueFromEmptyTree_ReceivedDefaultValueForType()
        {
            var value = _leftLeaningRedBlackTree.Get(1);
            Assert.That(value, Is.EqualTo(0));
        }

        [Test]
        public void Minimum_GetMinimumFromTree_ReceivedMinimum()
        {
            _leftLeaningRedBlackTree.Insert(0, 0);
            _leftLeaningRedBlackTree.Insert(1, 0);
            _leftLeaningRedBlackTree.Insert(-1, 0);
            var value = _leftLeaningRedBlackTree.Minimum();
            Assert.That(value, Is.EqualTo((-1, 0)));
        }

        [Test]
        public void Maximum_GetMinimumFromTree_ReceivedMaximum()
        {
            _leftLeaningRedBlackTree.Insert(0, 0);
            _leftLeaningRedBlackTree.Insert(1, 0);
            _leftLeaningRedBlackTree.Insert(-1, 0);
            var value = _leftLeaningRedBlackTree.Maximum();
            Assert.That(value, Is.EqualTo((1, 0)));
        }

        [Test]
        public void InfixTraverse_InfixTraverseInTree_ReceivedList()
        {
            _leftLeaningRedBlackTree.Insert(0, 2);
            _leftLeaningRedBlackTree.Insert(1, 3);
            _leftLeaningRedBlackTree.Insert(-1, 4);
            var list = new List<IComparable>();
            list.Add(-1);
            list.Add(0);
            list.Add(1);
            var result = _leftLeaningRedBlackTree.InfixTraverse();
            Assert.That(result, Is.EqualTo(list));
        }

        [Test]
        public void PrefixTraverse_PrefixTraverseInTree_ReceivedList()
        {
            _leftLeaningRedBlackTree.Insert(0, 2);
            _leftLeaningRedBlackTree.Insert(1, 3);
            _leftLeaningRedBlackTree.Insert(-1, 4);
            var list = new List<IComparable>();
            list.Add(0);
            list.Add(-1);
            list.Add(1);
            var result = _leftLeaningRedBlackTree.PrefixTraverse();
            Assert.That(result, Is.EqualTo(list));
        }

        [Test]
        public void PostfixTraverse_PostfixTraverseInTree_ReceivedList()
        {
            _leftLeaningRedBlackTree.Insert(0, 2);
            _leftLeaningRedBlackTree.Insert(1, 3);
            _leftLeaningRedBlackTree.Insert(-1, 4);
            var list = new List<IComparable>();
            list.Add(-1);
            list.Add(1);
            list.Add(0);
            var result = _leftLeaningRedBlackTree.PostfixTraverse();
            Assert.That(result, Is.EqualTo(list));
        }

        [Test]
        public void InfixTraverseValues_InfixTraverseValuesInTree_ReceivedList()
        {
            _leftLeaningRedBlackTree.Insert(0, 2);
            _leftLeaningRedBlackTree.Insert(1, 3);
            _leftLeaningRedBlackTree.Insert(-1, 4);
            var list = new List<int>();
            list.Add(4);
            list.Add(2);
            list.Add(3);
            var result = _leftLeaningRedBlackTree.InfixTraverseValues();
            Assert.That(result, Is.EqualTo(list));
        }

        [Test]
        public void PrefixTraverseValues_PrefixTraverseValuesInTree_ReceivedList()
        {
            _leftLeaningRedBlackTree.Insert(0, 2);
            _leftLeaningRedBlackTree.Insert(1, 3);
            _leftLeaningRedBlackTree.Insert(-1, 4);
            var list = new List<int>();
            list.Add(2);
            list.Add(4);
            list.Add(3);
            var result = _leftLeaningRedBlackTree.PrefixTraverseValues();
            Assert.That(result, Is.EqualTo(list));
        }

        [Test]
        public void PostfixTraverseValues_PostfixTraverseValuesInTree_ReceivedList()
        {
            _leftLeaningRedBlackTree.Insert(0, 2);
            _leftLeaningRedBlackTree.Insert(1, 3);
            _leftLeaningRedBlackTree.Insert(-1, 4);
            var list = new List<int>();
            list.Add(4);
            list.Add(3);
            list.Add(2);
            var result = _leftLeaningRedBlackTree.PostfixTraverseValues();
            Assert.That(result, Is.EqualTo(list));
        }

        [Test]
        public void Traverse_TraverseInEmptyTree_NoExeptions()
        {
            Assert.DoesNotThrow(() => _leftLeaningRedBlackTree.Traverse());
        }

        [Test]
        public void Traverse_TraverseInTree_NoExeptions()
        {
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            _leftLeaningRedBlackTree.Insert(0, 2);
            _leftLeaningRedBlackTree.Insert(1, 3);
            _leftLeaningRedBlackTree.Insert(-1, 4);
            Assert.DoesNotThrow(() => _leftLeaningRedBlackTree.Traverse());
        }
    }
}