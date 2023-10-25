using AI_Project_1_knuth;


Queue<Node> frontier = new();
List<double> explored = new();

double goal = 1234;

var root = new Node(4, null, null);
frontier.Enqueue(root);

while(frontier.Count > 0)
{
    var node = frontier.Dequeue();
    if (node.Value == goal)
    {
        Console.WriteLine($"frontier count = {frontier.Count}");
        PrintResult(node);
        return 0;
    }
    explored.Add(node.Value);

    var parentValue = node.Value;
    double newValue;

    // *5 
    newValue = parentValue * 5;
    if (!frontier.Any(n => n.Value == newValue) && !explored.Contains(newValue))
    {
        frontier.Enqueue(new Node(newValue, Operator.MultipleOn5, node));
    }

    // sqrt
    newValue = Math.Sqrt(parentValue);
    if (!frontier.Any(n => n.Value == newValue) && !explored.Contains(newValue))
    {
        frontier.Enqueue(new Node(newValue, Operator.Sqrt, node));
    }


    // floor
    newValue = Math.Floor(parentValue);
    if (newValue != parentValue && !frontier.Any(n => n.Value == newValue) && !explored.Contains(newValue))
    {
        frontier.Enqueue(new Node(newValue, Operator.Floor, node));
    }
}

void PrintResult(Node node)
{
    if (node.Parent is null)
    {
        Console.WriteLine("start =" + node.Value);
        return;
    }
    PrintResult(node.Parent);
    Console.WriteLine($"{node.Operator} = {node.Value} ");
}

return 1;