using AI_Project_1_knuth;

Queue<Node> frontier = new();
double goal = 12345;

var root = new Node(4, null, null);
frontier.Enqueue(root);

GraphSearch();
TreeSearch();

void TreeSearch()
{
    while (frontier.Count > 0)
    {
        var node = frontier.Dequeue();
        if (node.Value == goal)
        {
            Console.WriteLine($"frontier count = {frontier.Count}");
            PrintResult(node);
            return;
        }

        var parentValue = node.Value;
        double newValue;

        // *5 
        newValue = parentValue * 5;
        frontier.Enqueue(new Node(newValue, Operator.MultipleOn5, node));

        // sqrt
        newValue = Math.Sqrt(parentValue);
        frontier.Enqueue(new Node(newValue, Operator.Sqrt, node));

        // floor
        newValue = Math.Floor(parentValue);
        if(newValue != parentValue)
        frontier.Enqueue(new Node(newValue, Operator.Floor, node));
    }
}

void GraphSearch()
{
    List<double> frontierValues = new();
    List<double> explored = new();

    while (frontier.Count > 0)
    {
        var node = frontier.Dequeue();
        if (node.Value == goal)
        {
            Console.WriteLine($"frontier count = {frontier.Count}");
            PrintResult(node);
            return;
        }
        explored.Add(node.Value);

        var parentValue = node.Value;
        double newValue;

        // *5 
        newValue = parentValue * 5;
        if (!frontierValues.Contains(newValue) && !explored.Contains(newValue))
        {
            frontier.Enqueue(new Node(newValue, Operator.MultipleOn5, node));
            frontierValues.Add(newValue);
        }

        // sqrt
        newValue = Math.Sqrt(parentValue);
        if (!frontierValues.Contains(newValue) && !explored.Contains(newValue))
        {
            frontier.Enqueue(new Node(newValue, Operator.Sqrt, node));
            frontierValues.Add(newValue);
        }


        // floor
        newValue = Math.Floor(parentValue);
        if (newValue != parentValue && !frontierValues.Contains(newValue) && !explored.Contains(newValue))
        {
            frontier.Enqueue(new Node(newValue, Operator.Floor, node));
            frontierValues.Add(newValue);
        }
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