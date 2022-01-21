# DotNetGraph

Create **GraphViz DOT graph** with **.NET**

Available on NuGet: [![#](https://img.shields.io/nuget/v/DotNetGraph.svg)](https://www.nuget.org/packages/DotNetGraph/)

Compatible with **.NET Standard 2.0** and higher

# Documentation

## Create a graph (*DotGraph*)

```csharp
var graph = new DotGraph("MyGraph");

var directedGraph = new DotGraph("MyDirectedGraph", true);
```

## Create and add a node (*DotNode*)

```csharp
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
```

## Create and add an edge (*DotEdge*)

```csharp
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
```

## Create a subgraph / cluster

```csharp
// Create a subgraph with attributes (only used for cluster) and child elements
graph.AddSubGraph("mysubgraph1", subGraph =>
{
    subGraph.WithColor(Color.Red)
        .WithStyle(DotSubGraphStyle.Dashed)
        .WithLabel("My subgraph!")
        .AddNode(myNode1)
        .AddEdge(myEdge1)
        .AddSubGraph(anotherSubGraph);
});
```

## Compile to DOT format

```csharp
// Non indented version
var dot = graph.CompileToString();

// Indented version
var dot = graph.CompileToString(indented: true);
```