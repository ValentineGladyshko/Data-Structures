using DataStructures;

namespace Data_Structures_Library_Test
{
    [TestFixture]
    public class BinaryTreeTests
    {
        private BinaryTree<int, int> _binaryTree;
        [SetUp]
        public void Setup()
        {
            _binaryTree = new BinaryTree<int, int>();
        }

        [Test]
        public void Find_FindInEmptyTree_ReturnFalse()
        {
            Assert.That(_binaryTree.Find(0), Is.False);
        }

        [Test]
        public void Find_FindValueSameAsInsert_ReturnTrue()
        {
            _binaryTree.Insert(0, 0);
            Assert.That(_binaryTree.Find(0), Is.True);
        }

        [Test]
        public void Find_FindValueNotSameAsInsert_ReturnFalse()
        {
            _binaryTree.Insert(0, 0);
            Assert.That(_binaryTree.Find(1), Is.False);
        }

        [Test]
        public void Insert_InsertIntoEmptyTree_TreeContainsElement()
        {
            _binaryTree.Insert(0, 0);
            Assert.That(_binaryTree.Find(0), Is.True);
        }

        [Test]
        public void Insert_InsertIntoRightNode_TreeContainsTwoElements()
        {
            _binaryTree.Insert(0, 0);
            _binaryTree.Insert(1, 0);
            Assert.That(_binaryTree.Find(0), Is.True);
            Assert.That(_binaryTree.Find(1), Is.True);
        }

        [Test]
        public void Insert_InsertIntoLeftNode_TreeContainsTwoElements()
        {
            _binaryTree.Insert(0, 0);
            _binaryTree.Insert(-1, 0);
            Assert.Multiple(() =>
            {
                Assert.That(_binaryTree.Find(0), Is.True);
                Assert.That(_binaryTree.Find(-1), Is.True);
            });
        }

        [Test]
        public void Insert_InsertIntoRightNodeTwoElements_TreeContainsThreeElements()
        {
            _binaryTree.Insert(0, 0);
            _binaryTree.Insert(1, 0);
            _binaryTree.Insert(2, 0);
            Assert.Multiple(() =>
            {
                Assert.That(_binaryTree.Find(0), Is.True);
                Assert.That(_binaryTree.Find(1), Is.True);
                Assert.That(_binaryTree.Find(2), Is.True);
            });
        }

        [Test]
        public void Insert_InsertIntoLeftNodeTwoElements_TreeContainsThreeElements()
        {
            _binaryTree.Insert(0, 0);
            _binaryTree.Insert(-1, 0);
            _binaryTree.Insert(-2, 0);
            Assert.Multiple(() =>
            {
                Assert.That(_binaryTree.Find(0), Is.True);
                Assert.That(_binaryTree.Find(-1), Is.True);
                Assert.That(_binaryTree.Find(-2), Is.True);
            });
        }

        [Test]
        public void Remove_RemoveFromEmptyTree_NothingHappens()
        {
            _binaryTree.Remove(0);
            Assert.That(_binaryTree.Find(0), Is.False);
        }

        [Test]
        public void Remove_RemoveFromTreeWithOneElement_TreeIsEmpty()
        {
            _binaryTree.Insert(0, 0);
            _binaryTree.Remove(0);
            Assert.That(_binaryTree.Find(0), Is.False);
        }

        [Test]
        public void Remove_RemoveNotExistedElementFromTreeWithOneElement_NothingHappens()
        {
            _binaryTree.Insert(0, 0);
            _binaryTree.Remove(1);
            Assert.That(_binaryTree.Find(0), Is.True);
        }

        [Test]
        public void Remove_RemoveLeftElementFromTree_ElementRemoved()
        {
            _binaryTree.Insert(0, 0);
            _binaryTree.Insert(-1, 0);
            _binaryTree.Remove(-1);
            Assert.Multiple(() =>
            {
                Assert.That(_binaryTree.Find(0), Is.True);
                Assert.That(_binaryTree.Find(-1), Is.False);
            });
        }

        [Test]
        public void Remove_RemoveRightElementFromTree_ElementRemoved()
        {
            _binaryTree.Insert(0, 0);
            _binaryTree.Insert(1, 0);
            _binaryTree.Remove(1);
            Assert.Multiple(() =>
            {
                Assert.That(_binaryTree.Find(0), Is.True);
                Assert.That(_binaryTree.Find(1), Is.False);
            });
        }

        [Test]
        public void Remove_RemoveElementWithLeftNodeFromTree_ElementRemoved()
        {
            _binaryTree.Insert(0, 0);
            _binaryTree.Insert(-1, 0);
            _binaryTree.Remove(0);
            Assert.Multiple(() =>
            {
                Assert.That(_binaryTree.Find(0), Is.False);
                Assert.That(_binaryTree.Find(-1), Is.True);
            });
        }

        [Test]
        public void Remove_RemoveElementWithRightNodeFromTree_ElementRemoved()
        {
            _binaryTree.Insert(0, 0);
            _binaryTree.Insert(1, 0);
            _binaryTree.Remove(0);
            Assert.Multiple(() =>
            {
                Assert.That(_binaryTree.Find(0), Is.False);
                Assert.That(_binaryTree.Find(1), Is.True);
            });
        }

        [Test]
        public void Remove_RemoveElementWithTwoNodesWithoutChildrenFromTree_ElementRemoved()
        {
            _binaryTree.Insert(0, 0);
            _binaryTree.Insert(1, 0);
            _binaryTree.Insert(-1, 0);
            _binaryTree.Remove(0);
            Assert.Multiple(() =>
            {
                Assert.That(_binaryTree.Find(0), Is.False);
                Assert.That(_binaryTree.Find(1), Is.True);
                Assert.That(_binaryTree.Find(-1), Is.True);
            });
        }

        [Test]
        public void Remove_RemoveElementWithTwoNodesFromTree_ElementRemoved()
        {
            _binaryTree.Insert(0, 0);
            _binaryTree.Insert(2, 0);
            _binaryTree.Insert(1, 0);
            _binaryTree.Insert(-1, 0);
            _binaryTree.Remove(0);
            Assert.Multiple(() =>
            {
                Assert.That(_binaryTree.Find(0), Is.False);
                Assert.That(_binaryTree.Find(1), Is.True);
                Assert.That(_binaryTree.Find(2), Is.True);
                Assert.That(_binaryTree.Find(-1), Is.True);
            });
        }

        [Test]
        public void Get_GetValueByExistedKeyFromTreeWithOneElement_ReceivedValue()
        {
            _binaryTree.Insert(0, 1);
            var value = _binaryTree.Get(0);
            Assert.That(value, Is.EqualTo(1));
        }

        [Test]
        public void Get_GetValueByNotExistedKeyFromTreeWithOneElement_ReceivedDefaultValueForType()
        {
            _binaryTree.Insert(2, 1);
            var value = _binaryTree.Get(1);
            Assert.That(value, Is.EqualTo(0));
        }

        [Test]
        public void Get_GetValueFromEmptyTree_ReceivedDefaultValueForType()
        {
            var value = _binaryTree.Get(1);
            Assert.That(value, Is.EqualTo(0));
        }

        [Test]
        public void Get_GetValueByExistedKeyFromTreeWithLeftNode_ReceivedValue()
        {
            _binaryTree.Insert(0, 2);
            _binaryTree.Insert(-1, 3);
            var value = _binaryTree.Get(-1);
            Assert.That(value, Is.EqualTo(3));
        }

        [Test]
        public void Get_GetValueByExistedKeyFromTreeWithRightNode_ReceivedValue()
        {
            _binaryTree.Insert(0, 2);
            _binaryTree.Insert(1, 3);
            var value = _binaryTree.Get(1);
            Assert.That(value, Is.EqualTo(3));
        }

        [Test]
        public void Minimum_GetMinimumFromEmptyTree_ReceivedNull()
        {
            var value = _binaryTree.Minimum();
            Assert.That(value, Is.EqualTo(null));
        }

        [Test]
        public void Minimum_GetMinimumFromTreeWithOneValue_ReceivedMinimum()
        {
            _binaryTree.Insert(0, 0);
            var value = _binaryTree.Minimum();
            Assert.That(value, Is.EqualTo((0, 0)));
        }

        [Test]
        public void Minimum_GetMinimumFromTree_ReceivedMinimum()
        {
            _binaryTree.Insert(0, 0);
            _binaryTree.Insert(1, 0);
            _binaryTree.Insert(-1, 0);
            var value = _binaryTree.Minimum();
            Assert.That(value, Is.EqualTo((-1, 0)));
        }

        [Test]
        public void Maximum_GetMinimumFromEmptyTree_ReceivedNull()
        {
            var value = _binaryTree.Maximum();
            Assert.That(value, Is.EqualTo(null));
        }

        [Test]
        public void Maximum_GetMinimumFromTreeWithOneValue_ReceivedMaximum()
        {
            _binaryTree.Insert(0, 0);
            var value = _binaryTree.Maximum();
            Assert.That(value, Is.EqualTo((0, 0)));
        }

        [Test]
        public void Maximum_GetMinimumFromTree_ReceivedMaximum()
        {
            _binaryTree.Insert(0, 0);
            _binaryTree.Insert(1, 0);
            _binaryTree.Insert(-1, 0);
            var value = _binaryTree.Maximum();
            Assert.That(value, Is.EqualTo((1, 0)));
        }

        [Test]
        public void InfixTraverse_InfixTraverseInEmptyTree_ReceivedEmptyList()
        {
            var result = _binaryTree.InfixTraverse();
            Assert.That(result, Is.EqualTo(new List<IComparable>()));
        }

        [Test]
        public void InfixTraverse_InfixTraverseInTreeWithOneElement_ReceivedListWithOneElement()
        {
            _binaryTree.Insert(0, 1);
            var list = new List<IComparable>();
            list.Add(0);
            var result = _binaryTree.InfixTraverse();
            Assert.That(result, Is.EqualTo(list));
        }

        [Test]
        public void InfixTraverse_InfixTraverseInTree_ReceivedList()
        {
            _binaryTree.Insert(0, 2);
            _binaryTree.Insert(1, 3);
            _binaryTree.Insert(-1, 4);
            var list = new List<IComparable>();
            list.Add(-1);
            list.Add(0);
            list.Add(1);
            var result = _binaryTree.InfixTraverse();
            Assert.That(result, Is.EqualTo(list));
        }

        [Test]
        public void PrefixTraverse_PrefixTraverseInEmptyTree_ReceivedEmptyList()
        {
            var result = _binaryTree.PrefixTraverse();
            Assert.That(result, Is.EqualTo(new List<IComparable>()));
        }

        [Test]
        public void PrefixTraverse_PrefixTraverseInTreeWithOneElement_ReceivedListWithOneElement()
        {
            _binaryTree.Insert(0, 1);
            var list = new List<IComparable>();
            list.Add(0);
            var result = _binaryTree.PrefixTraverse();
            Assert.That(result, Is.EqualTo(list));
        }

        [Test]
        public void PrefixTraverse_PrefixTraverseInTree_ReceivedList()
        {
            _binaryTree.Insert(0, 2);
            _binaryTree.Insert(1, 3);
            _binaryTree.Insert(-1, 4);
            var list = new List<IComparable>();
            list.Add(0);
            list.Add(-1);
            list.Add(1);
            var result = _binaryTree.PrefixTraverse();
            Assert.That(result, Is.EqualTo(list));
        }

        [Test]
        public void PostfixTraverse_PostfixTraverseInEmptyTree_ReceivedEmptyList()
        {
            var result = _binaryTree.PostfixTraverse();
            Assert.That(result, Is.EqualTo(new List<IComparable>()));
        }

        [Test]
        public void PostfixTraverse_PostfixTraverseInTreeWithOneElement_ReceivedListWithOneElement()
        {
            _binaryTree.Insert(0, 1);
            var list = new List<IComparable>();
            list.Add(0);
            var result = _binaryTree.PostfixTraverse();
            Assert.That(result, Is.EqualTo(list));
        }

        [Test]
        public void PostfixTraverse_PostfixTraverseInTree_ReceivedList()
        {
            _binaryTree.Insert(0, 2);
            _binaryTree.Insert(1, 3);
            _binaryTree.Insert(-1, 4);
            var list = new List<IComparable>();
            list.Add(-1);
            list.Add(1);
            list.Add(0);
            var result = _binaryTree.PostfixTraverse();
            Assert.That(result, Is.EqualTo(list));
        }

        [Test]
        public void InfixTraverseValues_InfixTraverseValuesInEmptyTree_ReceivedEmptyList()
        {
            var result = _binaryTree.InfixTraverseValues();
            Assert.That(result, Is.EqualTo(new List<int>()));
        }

        [Test]
        public void InfixTraverseValues_InfixTraverseInTreeWithOneElement_ReceivedListWithOneElement()
        {
            _binaryTree.Insert(0, 1);
            var list = new List<int>();
            list.Add(1);
            var result = _binaryTree.InfixTraverseValues();
            Assert.That(result, Is.EqualTo(list));
        }

        [Test]
        public void InfixTraverseValues_InfixTraverseValuesInTree_ReceivedList()
        {
            _binaryTree.Insert(0, 2);
            _binaryTree.Insert(1, 3);
            _binaryTree.Insert(-1, 4);
            var list = new List<int>();
            list.Add(4);
            list.Add(2);
            list.Add(3);
            var result = _binaryTree.InfixTraverseValues();
            Assert.That(result, Is.EqualTo(list));
        }

        [Test]
        public void PrefixTraverseValuesPrefixTraverseValuesInEmptyTree_ReceivedEmptyList()
        {
            var result = _binaryTree.PrefixTraverseValues();
            Assert.That(result, Is.EqualTo(new List<int>()));
        }

        [Test]
        public void PrefixTraverseValues_PrefixTraverseInTreeWithOneElement_ReceivedListWithOneElement()
        {
            _binaryTree.Insert(0, 1);
            var list = new List<int>();
            list.Add(1);
            var result = _binaryTree.PrefixTraverseValues();
            Assert.That(result, Is.EqualTo(list));
        }

        [Test]
        public void PrefixTraverseValues_PrefixTraverseValuesInTree_ReceivedList()
        {
            _binaryTree.Insert(0, 2);
            _binaryTree.Insert(1, 3);
            _binaryTree.Insert(-1, 4);
            var list = new List<int>();
            list.Add(2);
            list.Add(4);
            list.Add(3);
            var result = _binaryTree.PrefixTraverseValues();
            Assert.That(result, Is.EqualTo(list));
        }

        [Test]
        public void PostfixTraverseValues_PostfixTraverseValuesInEmptyTree_ReceivedEmptyList()
        {
            var result = _binaryTree.PostfixTraverseValues();
            Assert.That(result, Is.EqualTo(new List<int>()));
        }

        [Test]
        public void PostfixTraverseValues_PostfixTraverseInTreeWithOneElement_ReceivedListWithOneElement()
        {
            _binaryTree.Insert(0, 1);
            var list = new List<int>();
            list.Add(1);
            var result = _binaryTree.PostfixTraverseValues();
            Assert.That(result, Is.EqualTo(list));
        }

        [Test]
        public void PostfixTraverseValues_PostfixTraverseValuesInTree_ReceivedList()
        {
            _binaryTree.Insert(0, 2);
            _binaryTree.Insert(1, 3);
            _binaryTree.Insert(-1, 4);
            var list = new List<int>();
            list.Add(4);
            list.Add(3);
            list.Add(2);
            var result = _binaryTree.PostfixTraverseValues();
            Assert.That(result, Is.EqualTo(list));
        }

        [Test]
        public void Traverse_TraverseInEmptyTree_NoExeptions()
        {
            Assert.DoesNotThrow(() => _binaryTree.Traverse());
        }

        [Test]
        public void Traverse_TraverseInTree_NoExeptions()
        {
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            _binaryTree.Insert(0, 2);
            _binaryTree.Insert(1, 3);
            _binaryTree.Insert(-1, 4);
            Assert.DoesNotThrow(() => _binaryTree.Traverse());
        }
    }
}