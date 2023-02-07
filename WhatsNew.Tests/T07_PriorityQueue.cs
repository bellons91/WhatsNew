namespace WhatsNew.Tests
{
    public class T07_PriorityQueue
    {
        public record TaskToDo(string description);
        private PriorityQueue<TaskToDo, int> _tasks;

        [SetUp]
        public void SetupQueue()
        {
            _tasks = new PriorityQueue<TaskToDo, int>();
            _tasks.Enqueue(new TaskToDo("turn off tv"), 5);
            _tasks.Enqueue(new TaskToDo("wake up"), 1);
            _tasks.Enqueue(new TaskToDo("clean up house"), 3);
        }

        [Test]
        [DotNet6]
        public void priorityqueue_has_correct_size()
        {
            Assert.That(_tasks.Count, Is.EqualTo(3));
        }

        [Test]
        [DotNet6]
        public void priorityqueue_has_prioritized_items_on_top()
        {
            Assert.That(_tasks.Peek(), Is.EqualTo(new TaskToDo("wake up")));
        }

        [Test]
        [DotNet6]
        public void priorityqueue_puts_item_with_higher_priority_on_top()
        {
            _tasks.Enqueue(new TaskToDo("code"), 2);

            _tasks.Dequeue();// removes "turn off tv"

            Assert.That(_tasks.Dequeue(), Is.EqualTo(new TaskToDo("code")));
        }
    }
}