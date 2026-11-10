using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add Bob (2), Tim (5), and Sue (3).
    // Expected Result: Tim, Sue, Bob.
    // Defect(s) Found: Dequeue did not remove the item from the queue.
    public void TestPriorityQueue_1()
    {
        string[] expectedResult = ["Tim", "Sue", "Bob"];

        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Bob", 2);
        priorityQueue.Enqueue("Tim", 5);
        priorityQueue.Enqueue("Sue", 3);

        var first = priorityQueue.Dequeue();
        var second = priorityQueue.Dequeue();
        var third= priorityQueue.Dequeue();

        Assert.AreEqual(expectedResult[0], first);
        Assert.AreEqual(expectedResult[1], second);
        Assert.AreEqual(expectedResult[2], third);
    }

    [TestMethod]
    // Scenario: Add Bob, Tim, and Sue with the same priority (5).
    // Expected Result: Bob, Tim, Sue (FIFO).
    // Defect(s) Found: Equal priorities were not handled using FIFO order.
    public void TestPriorityQueue_2()
    {
        string[] expectedResult = ["Bob", "Tim", "Sue"];

        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Bob", 5);
        priorityQueue.Enqueue("Tim", 5);
        priorityQueue.Enqueue("Sue", 5);

        var first = priorityQueue.Dequeue();
        var second = priorityQueue.Dequeue();
        var third= priorityQueue.Dequeue();

        Assert.AreEqual(expectedResult[0], first);
        Assert.AreEqual(expectedResult[1], second);
        Assert.AreEqual(expectedResult[2], third);
    }

    [TestMethod]
    // Scenario: Dequeue from an empty priority queue.
    // Expected Result: Throw InvalidOperationException with message "The queue is empty.".
    // Defect(s) Found: None.
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Test Error");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail(
                 string.Format("Unexpected exception of type {0} caught: {1}",
                                e.GetType(), e.Message)
            );
        }
    }
}