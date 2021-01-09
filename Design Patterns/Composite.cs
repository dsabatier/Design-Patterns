using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// Composite pattern allows you to create tree structures made of
/// composites and leafs and has whole-part relationships
/// </summary>
namespace Design_Patterns.Composite
{
    public abstract class Node
    {
        protected string _name;
        public Node(string name) => _name = name;
        public abstract void Add(Node node);
        public abstract void Remove(Node node);
        public abstract void Print();
    }

    public class NodeComposite : Node
    {
        private List<Node> _nodes = new List<Node>();
        public NodeComposite(string name) : base(name) { }
        public override void Add(Node node)
        {
            _nodes.Add(node);
        }

        public override void Print()
        {
            Console.WriteLine($"{_name}: {_nodes.Count}");
            foreach (Node node in _nodes)
                node.Print();
        }

        public override void Remove(Node node)
        {
            _nodes.Remove(node);
        }
    }

    public class NodeLeaf : Node
    {
        public NodeLeaf(string name) : base(name)
        {

        }
        public override void Add(Node node)
        {
            throw new NotImplementedException();
        }

        public override void Print()
        {
            Console.WriteLine($"{_name}");
        }

        public override void Remove(Node node)
        {
            throw new NotImplementedException();
        }
    }

}
