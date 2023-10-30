using AI_Project_1_knuth;
using System.Diagnostics;

Queue<Node> frontier = new();
double goal = 999;

var root = new Node(4, null, null);
frontier.Enqueue(root);

Stopwatch sw = new();
sw.Start();

GraphSearch();
//TreeSearch();

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
    HashSet<double> frontierAndExplored = new();

    while (frontier.Count > 0)
    {
        var node = frontier.Dequeue();
        if (node.Value == goal)
        {
            sw.Stop();
            TimeSpan ts = sw.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",ts.Hours, ts.Minutes, ts.Seconds,ts.Milliseconds / 10);
            Console.WriteLine("RunTime: " + elapsedTime);
            Console.WriteLine($"frontier count = {frontier.Count}");
            Console.WriteLine($"explored count = {frontierAndExplored.Count}");
            PrintResult(node);
            return;
        }
        frontierAndExplored.Add(node.Value);

        var parentValue = node.Value;
        double newValue;

        // *5 
        newValue = parentValue * 5;
        if (frontierAndExplored.Add(newValue))
        {
            frontier.Enqueue(new Node(newValue, Operator.MultipleOn5, node));
        }

        // sqrt
        newValue = Math.Sqrt(parentValue);
        if (frontierAndExplored.Add(newValue))
        {
            frontier.Enqueue(new Node(newValue, Operator.Sqrt, node));
        }


        // floor
        newValue = Math.Floor(parentValue);
        if (newValue != parentValue && frontierAndExplored.Add(newValue))
        {
            frontier.Enqueue(new Node(newValue, Operator.Floor, node));
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