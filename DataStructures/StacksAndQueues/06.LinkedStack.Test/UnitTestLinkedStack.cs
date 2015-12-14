namespace _06.LinkedStack.Test
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using _05.LinkedStack;

    [TestClass]
    public class UnitTestLinkedStack
    {
        [TestMethod]
        public void Push_EmptyLinkedStack_ShouldAddElement()
        {
            // Arrange
            var stack = new LinkedStack<int>();

            // Act
            stack.Push(5);

            // Assert
            Assert.AreEqual(1, stack.Count);
        }

        [TestMethod]
        public void PushPop_ShouldWorkCorrectly()
        {
            // Arrange
            var stack = new LinkedStack<int>();
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
            var stack = new LinkedStack<string>();
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
        [ExpectedException(typeof(InvalidOperationException))]
        public void Pop_FromEmptyStack_ShouldThrowException()
        {
            // Arrange
            var stack = new LinkedStack<int>();

            // Act
            stack.Pop();

            // Assert: expect exception
        }

        [TestMethod]
        public void StackToArray_ShouldWorkCorrectly()
        {
            // Arrange
            var stack = new LinkedStack<int>();
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
            var stack = new LinkedStack<DateTime>();

            // Act
            var newArray = stack.ToArray();

            // Assert
            Assert.AreEqual(0, newArray.Length);
        }
    }
}
