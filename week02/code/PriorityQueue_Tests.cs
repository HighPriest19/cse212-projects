using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue multiple items with different priorities (Low, High, Medium) and dequeue them.
    // Expected Result: Items should be dequeued in order of highest priority first ("High", then "Medium", then "Low").
    // Defect(s) Found: None if implemented correctly; previously might have dequeued in FIFO order regardless of priority.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("High", 10);
        priorityQueue.Enqueue("Medium", 5);

        Assert.AreEqual("High", priorityQueue.Dequeue());
        Assert.AreEqual("Medium", priorityQueue.Dequeue());
        Assert.AreEqual("Low", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue multiple items that share the exact same priority level.
    // Expected Result: Items with matching priorities should respect FIFO order (the one added first comes out first).
    // Defect(s) Found: If using >= instead of >, equal priorities might break FIFO order. Using > ensures proper tie-breaking.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("First", 5);
        priorityQueue.Enqueue("Second", 5);
        priorityQueue.Enqueue("Third", 5);

        Assert.AreEqual("First", priorityQueue.Dequeue());
        Assert.AreEqual("Second", priorityQueue.Dequeue());
        Assert.AreEqual("Third", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Attempt to call Dequeue on an empty priority queue.
    // Expected Result: Throws an InvalidOperationException with the message "The queue is empty."
    // Defect(s) Found: None if the exception check is properly placed at the start of Dequeue.
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();
        
        Assert.ThrowsException<InvalidOperationException>(() => 
        {
            priorityQueue.Dequeue();
        });
    }
}