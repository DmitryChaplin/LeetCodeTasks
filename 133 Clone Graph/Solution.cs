public class Solution
{
    public class Node
    {
        public int val;
        public IList<Node> neighbors;

        public Node()
        {
            val = 0;
            neighbors = new List<Node>();
        }

        public Node(int _val)
        {
            val = _val;
            neighbors = new List<Node>();
        }

        public Node(int _val, List<Node> _neighbors)
        {
            val = _val;
            neighbors = _neighbors;
        }
    }

    public Node CloneGraph(Node node)
    {
        // since values in nodes are unique, we can use a dict to quickly check if we already have a copy of node
        var dict = new Dictionary<int, Node>();

        return Clone(node, dict);
    }

    Node Clone(Node node, Dictionary<int, Node> dict)
    {
        if (node == null) 
            return null;

        // check if we already copied this node
        if (dict.ContainsKey(node.val))
            return dict[node.val];

        // deep copy the node
        var clone = new Node(node.val);
        dict.Add(node.val, clone);

        // we need to add neighbors to our node and traverse the graph while doing it 
        foreach (var n in node.neighbors)
            clone.neighbors.Add(Clone(n, dict));

        return clone;
    }
}