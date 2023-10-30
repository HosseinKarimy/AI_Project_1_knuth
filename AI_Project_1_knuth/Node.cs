using System.Xml.Linq;

namespace AI_Project_1_knuth
{
    public class Node
    {
        public readonly float value;
        public readonly char? op;
        public readonly Node? parent;

        public Node(float value, char? op, Node? parent)
        {
            this.value = value;
            this.op = op;
            this.parent = parent;
        }

        public override int GetHashCode()
        {
            return value.GetHashCode();
        }

        public static bool operator ==(Node? left, Node? right)
        {
            if (left is null || right is null)
                return false;
            return left.GetHashCode() == right.GetHashCode();
        }

        public static bool operator !=(Node? left, Node? right)
        {
            if (left is null || right is null)
                return true;
            return left!.GetHashCode() != right!.GetHashCode();
        }

        public override bool Equals(object? obj)
        {
            if (obj is Node other)
            {
                if (other == null)
                    return false;
                if(this.value == other.value) 
                    return true;
                return false;
            } 
            else
                return false;
        }

        public List<Node> GetActions()
        {
            return new List<Node>()
            {
                new Node(value * 5, '*', this),
                new Node((float)Math.Sqrt(value), 's', this),
                new Node((float)Math.Floor(value), 'f', this)
            };
        }

        public void Print()
        {
            var temp = op == '*' ? "*5" : op == 's' ? "Sqrt" : "Floor";
            Console.WriteLine($"{temp} = {value} ");
        }
    }
}
