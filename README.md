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
var myNode = new DotNode("MyNode")
{
    Shape = DotNodeShape.Ellipse,
    Label = "My node!",
    FillColor = Color.Coral,
    FontColor = Color.Black,
    Style = DotNodeStyle.Dotted,
    Width = 0.5f,
    Height = 0.5f,
    PenWidth = 1.5f
};

// Add the node to the graph
graph.Elements.Add(myNode);
```

## Create and add an edge (*DotEdge*)

```csharp
// Create an edge with identifiers
var myEdge = new DotEdge("myNode1", "myNode2");

// Create an edge with nodes and attributes
var myEdge = new DotEdge(myNode1, myNode2)
{
    ArrowHead = DotEdgeArrowType.Box,
    ArrowTail = DotEdgeArrowType.Diamond,
    Color = Color.Red,
    FontColor = Color.Black,
    Label = "My edge!",
    Style = DotEdgeStyle.Dashed,
    PenWidth = 1.5f
};

// Add the edge to the graph
graph.Elements.Add(myEdge);
```

## Create a subgraph / cluster

```csharp
// Subgraph identifier need to start with "cluster" to be identified as a cluster
var mySubGraph = new DotSubGraph("cluster_0");

// Create a subgraph with attributes (only used for cluster)
var mySubGraph = new DotSubGraph("cluster_0")
{
    Color = Color.Red,
    Style = DotSubGraphStyle.Dashed,
    Label = "My subgraph!"
};

// Add node, edge, subgraph
subGraph.Elements.Add(myNode);
subGraph.Elements.Add(myEdge);
subGraph.Elements.Add(mySubGraph2);

// Add subgraph to main graph
graph.Elements.Add(mySubGraph);
```

## Compile to DOT format

```csharp
// Non indented version
var dot = graph.Compile();
// Indented version
var dot = graph.Compile(true);

// Save it to a file
File.WriteAllText("myFile.dot", dot);
```