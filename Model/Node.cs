namespace Test.Model
{
    public class Node
    {
        public string Value { get; set; }
        public int Level { get; set; }
        public Node Parent { get; set; }
        public List<Node> Children { get; set; }

        public Node(int level, string value, Node parent)
        {
            Level = level;
            Value = value;
            Parent = parent;
            Children = new List<Node>();
        }

        public Node InsertNode(int level, string value, Node parent)
        {
            Node newNode = new Node(level, value, parent);
            parent.Children.Add(newNode);
            return newNode;
        }

        public void DeleteNode(Node node)
        {
            node.Parent.Children.Remove(node);
        }

        public void BreadthFirstSearch(Node root)
        {
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                Node current = queue.Dequeue();
                Console.WriteLine(current.Value);
                foreach (Node child in current.Children)
                {
                    queue.Enqueue(child);
                }
            }
        }
    }
}
