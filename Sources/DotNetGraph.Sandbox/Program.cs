using System.Drawing;
using DotNetGraph;
using DotNetGraph.Edge;
using DotNetGraph.Extensions;
using DotNetGraph.Node;
using DotNetGraph.SubGraph;

var graph = new DotGraph("MyGraph");

graph.AddNode("MyNode", node =>
{
    node.WithShape(DotNodeShape.Ellipse)
        .WithLabel("My node!")
        .WithFillColor(Color.Coral)
        .WithFontColor(Color.Black)
        .WithStyle(DotNodeStyle.Dotted)
        .WithWidth(0.5f)
        .WithHeight(0.5f)
        .WithPenWidth(1.5f);
});

var myNode1 = new DotNode("MyNode1");
var myNode2 = new DotNode("MyNode2");

// Create an edge with identifiers
graph.AddEdge("MyNode1", "MyNode2");

// Create an edge with DotNode objects
graph.AddEdge(myNode1, myNode2, edge =>
{
    edge.WithArrowHead(DotEdgeArrowType.Box)
        .WithArrowTail(DotEdgeArrowType.Diamond)
        .WithColor(Color.Red)
        .WithLabel("My edge!")
        .WithStyle(DotEdgeStyle.Dashed)
        .WithPenWidth(1.5f);
});

var myEdge1 = new DotEdge("MyNode1", "MyNode2");

var anotherSubGraph = new DotSubGraph("cluster_0");

// Create a subgraph with attributes (only used for cluster) and child elements
graph.AddSubGraph("cluster_0", subGraph =>
{
    subGraph.WithColor(Color.Red)
        .WithStyle(DotSubGraphStyle.Dashed)
        .WithLabel("My subgraph!")
        .AddNode(myNode1)
        .AddEdge(myEdge1)
        .AddSubGraph(anotherSubGraph);
});

var dot = graph.CompileToString(indented: true);

Console.WriteLine(dot);