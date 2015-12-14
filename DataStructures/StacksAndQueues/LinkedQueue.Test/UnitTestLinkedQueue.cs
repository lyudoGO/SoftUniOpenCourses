namespace LinkedQueue.Test
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using _07.LinkedQueue;

    [TestClass]
    public class UnitTestLinkedQueue
    {
        [TestMethod]
        public void Enqueue_EmptyLinkedStack_ShouldAddElement()
        {
            // Arrange
            var queue = new LinkedQueue<int>();

            // Act
            queue.Enqueue(5);

            // Assert
            Assert.AreEqual(1, queue.Count);
        }

        [TestMethod]
        public void EnqueueDenqueue_ShouldWorkCorrectly()
        {
            // Arrange
            var queue = new LinkedQueue<int>();
            var element = 101;

            // Act
            queue.Enqueue(element);
            var elementFromStack = queue.Dequeue();

            // Assert
            Assert.AreEqual(0, queue.Count);
            Assert.AreEqual(element, elementFromStack);
        }

        [TestMethod]
        public void EqueueDequeue1000Elemnts_ShouldWorkCorrectly()
        {
            // Arrange
            var queue = new LinkedQueue<string>();
            var numberOfElemnts = 1000;
            var element = "some element";

            // Act and Assert
            for (int i = 0; i < numberOfElemnts; i++)
            {
                queue.Enqueue(element);
            }
            Assert.AreEqual(numberOfElemnts, queue.Count);

            for (int i = 0; i < numberOfElemnts; i++)
            {
                queue.Dequeue();
            }
            Assert.AreEqual(0, queue.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Dequeue_FromEmptyLinkedQueue_ShouldThrowException()
        {
            // Arrange
            var queue = new LinkedQueue<int>();

            // Act
            queue.Dequeue();

            // Assert: expect exception
        }

        [TestMethod]
        public void LinkedQueueToArray_ShouldWorkCorrectly()
        {
            // Arrange
            var queue = new LinkedQueue<int>();
            int[] array = { 5, 75, 101, -34 };

            // Act
            queue.Enqueue(5);
            queue.Enqueue(75);
            queue.Enqueue(101);
            queue.Enqueue(-34);

            var newArr = queue.ToArray();

            // Assert
            CollectionAssert.AreEqual(array, newArr);

        }

        [TestMethod]
        public void EmptyLinkedQueueToArray_ShouldWorkCorrectly()
        {
            // Arrange
            var queue = new LinkedQueue<DateTime>();

            // Act
            var newArray = queue.ToArray();

            // Assert
            Assert.AreEqual(0, newArray.Length);
        }
    }
}
