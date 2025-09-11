using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Dequeue from empty queue.
    // Expected Result: InvalidOperationException with message "The queue is empty."
    // Defect(s) Found: Code throws correctly, but this requirement confirms proper exception handling.
    public void TestPriorityQueue_1()
    {
        var pq = new PriorityQueue();
        var ex = Assert.ThrowsException<InvalidOperationException>(() => pq.Dequeue());
        Assert.AreEqual("The queue is empty.", ex.Message);
    }

    [TestMethod]
    // Scenario: Enqueue one item, then Dequeue it.
    // Expected Result: Returned value is the enqueued item, and queue becomes empty.
    // Defect(s)Found: The item was returned but it was never removed from the queue.
    public void TestPriorityQueue_2()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("A", 1);

        var result = pq.Dequeue();
        Assert.AreEqual("A", result);
        Assert.AreEqual("[]", pq.ToString());
    }

    [TestMethod]
    // Scenario: Multiple items with different priorities.
    // Expected Result: The highest priority item is removed.
    // Defect(s) Found: The loop skipped the last element, so the final item in the queue could never be chosen.
    public void TestPriorityQueue_3()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("Low", 1);
        pq.Enqueue("Medium", 2);
        pq.Enqueue("High", 3);

        var result = pq.Dequeue();
        Assert.AreEqual("High", result);
    }

    [TestMethod]
    // Scenario: Multiple items with the same highest priority.
    // Expected Result: The first inserted among them (FIFO) should be removed.
    // Defect(s) Found: I was using '>=' instead of '>', causing the last inserted high-priority item to be removed instead of the first.
    public void TestPriorityQueue_4()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("First", 5);
        pq.Enqueue("Second", 5);
        pq.Enqueue("Third", 5);

        var result = pq.Dequeue();
        Assert.AreEqual("First", result);
    }

    [TestMethod]
    // Scenario: Mixed priorities and duplicates.
    // Expected Result: Highest priority chosen first, then the next highest, preserving FIFO order among equals.
    // Defect(s) Found: None issues were found after fixing test 4.
    public void TestPriorityQueue_5()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("Low1", 1);
        pq.Enqueue("High1", 10);
        pq.Enqueue("High2", 10);
        pq.Enqueue("Low2", 1);

        var result1 = pq.Dequeue(); // should be "High1"
        var result2 = pq.Dequeue(); // should be "High2"

        Assert.AreEqual("High1", result1);
        Assert.AreEqual("High2", result2);
    }
}