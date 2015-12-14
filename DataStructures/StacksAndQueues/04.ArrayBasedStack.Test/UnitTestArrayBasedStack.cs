namespace _04.ArrayBasedStack.Test
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using _03.ImplementArrayBasedStack;

    [TestClass]
    public class UnitTestArrayBasedStack
    {
        [TestMethod]
        public void Push_EmptyStack_ShouldAddElement()
        {
            // Arrange
            var stack = new ArrayStack<int>();

            // Act
            stack.Push(5);

            // Assert
            Assert.AreEqual(1, stack.Count);
        }

        [TestMethod]
        public void PushPop_ShouldWorkCorrectly()
        {
            // Arrange
            var stack = new ArrayStack<int>();
            var element = 101;

            // Act
            stack.Push(element);
            var elementFromStack = stack.Pop();

            // Assert
            Assert.AreEqual(0, stack.Count);
            Assert.AreEqual(element, elementFromStack);
        }

        [TestMethod]
        public void PushPop1000Elemnts_ShouldWorkCorrectly()
        {
            // Arrange
            var stack = new ArrayStack<string>();
            var numberOfElemnts = 1000;
            var element = "some element";

            // Act and Assert
            for (int i = 0; i < numberOfElemnts; i++)
            {
                stack.Push(element);
            }
            Assert.AreEqual(numberOfElemnts, stack.Count);

            for (int i = 0; i < numberOfElemnts; i++)
            {
                stack.Pop();
            }
            Assert.AreEqual(0, stack.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Pop_FromEmptyStack_ShouldThrowException()
        {
            // Arrange
            var stack = new ArrayStack<int>();

            // Act
            stack.Pop();

            // Assert: expect exception
        }

        [TestMethod]
        public void PushPopInitialCapacityOne_ShouldWorkCorrectly()
        {
            // Arrange
            var stack = new ArrayStack<int>(1);

            // Act and Assert
            Assert.AreEqual(0, stack.Count);

            stack.Push(101);
            Assert.AreEqual(1, stack.Count);

            stack.Push(102);
            Assert.AreEqual(2, stack.Count);

            var popElement = stack.Pop();
            Assert.AreEqual(102, popElement);
            Assert.AreEqual(1, stack.Count);

            popElement = stack.Pop();
            Assert.AreEqual(101, popElement);
            Assert.AreEqual(0, stack.Count);
        }

        [TestMethod]
        public void StackToArray_ShouldWorkCorrectly()
        {
            // Arrange
            var stack = new ArrayStack<int>();
            int[] array = { -34, 101, 75, 5 };

            // Act
            stack.Push(5);
            stack.Push(75);
            stack.Push(101);
            stack.Push(-34);

            var newArr = stack.ToArray();

            // Assert
            CollectionAssert.AreEqual(array, newArr);

        }

        [TestMethod]
        public void EmptyStackToArray_ShouldWorkCorrectly()
        {
            // Arrange
            var stack = new ArrayStack<DateTime>();

            // Act
            var newArray = stack.ToArray();

            // Assert
            Assert.AreEqual(0, newArray.Length);
        }
    }
}
