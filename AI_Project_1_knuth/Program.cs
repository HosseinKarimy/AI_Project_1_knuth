using AI_Project_1_knuth;
using System.Diagnostics;

Queue<Node> frontier = new();
var goal = new Node(1234567, null, null);

var root = new Node(4, null, null);
frontier.Enqueue(root);

Stopwatch sw = new();
sw.Start();

GraphSearch();
//TreeSearch();

//void TreeSearch()
//{
//    while (frontier.Count > 0)
//    {
//        var node = frontier.Dequeue();
//        if (node.Value == goal)
//        {
//            Console.WriteLine($"frontier count = {frontier.Count}");
//            PrintResult(node);
//            return;
//        }

//        var parentValue = node.Value;
//        double newValue;


//    }
//}

void GraphSearch()
{
    HashSet<Node> frontierAndExplored = new();

    while (frontier.Count > 0)
    {
        var node = frontier.Dequeue();
        if (node == goal)
        {
            sw.Stop();
            TimeSpan ts = sw.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
            Console.WriteLine("RunTime: " + elapsedTime);
            Console.WriteLine($"frontier count = {frontier.Count}");
            Console.WriteLine($"explored count = {frontierAndExplored.Count - frontier.Count}");
            Console.Write("Goal");
            goal.Print();
            Console.WriteLine("__________________________________");
            int level = 0;
            PrintResult(node, ref level);
            return;
        }
        frontierAndExplored.Add(node);

        foreach (var n in node.GetActions())
        {
            if (frontierAndExplored.Add(n))
            {
                frontier.Enqueue(n);
            }
        }

    }
}

void PrintResult(Node node, ref int level)
{
    if (node.parent is null)
    {
        Console.Write("level " + level++);
        node.Print();
        return;
    }
    PrintResult(node.parent, ref level);
    Console.Write("level " + level++ + ": ");
    node.Print();

}

return 1;