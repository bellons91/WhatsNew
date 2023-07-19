namespace WhatsNew.Tests
{
    public class About_PriorityQueue
    {
        public record ToDoItem(string description);
        private PriorityQueue<ToDoItem, int> _tasks;

        [SetUp]
        public void SetupQueue()
        {
            _tasks = new PriorityQueue<ToDoItem, int>();
            _tasks.Enqueue(new ToDoItem("Deploy on dev"), 5);
            _tasks.Enqueue(new ToDoItem("Create repository"), 1);
            _tasks.Enqueue(new ToDoItem("Write tests"), 3);
        }

        [Test]
        [DotNet6]
        public void PriorityQueue_has_correct_size()
        {
            Assert.That(_tasks.Count, Is.EqualTo(3));
        }

        [Test]
        [DotNet6]
        public void PriorityQueue_has_prioritized_items_on_top()
        {
            Assert.That(_tasks.Peek(), Is.EqualTo(new ToDoItem("Create repository")));
        }

        [Test]
        [DotNet6]
        public void PriorityQueue_has_first_inserted_item_on_top()
        {
            _tasks.Enqueue(new ToDoItem("Initialize Solution"), 1);

            Assert.That(_tasks.Peek(), Is.EqualTo(new ToDoItem("Create repository")));
        }

        [Test]
        [DotNet6]
        public void PriorityQueue_puts_item_with_higher_priority_on_top()
        {
            _tasks.Enqueue(new ToDoItem("Write code"), 2);

            _tasks.Dequeue();

            Assert.That(_tasks.Dequeue(), Is.EqualTo(new ToDoItem("Write code")));
        }
    }
}