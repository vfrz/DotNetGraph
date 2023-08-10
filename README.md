# DotNetGraph

![Logo](Resources/icon_64.png)

Create **GraphViz DOT graph** with **dotnet** (compatible with **.NET Standard 2.0** and higher).

Current stable version: [![#](https://img.shields.io/nuget/v/DotNetGraph.svg)](https://www.nuget.org/packages/DotNetGraph/)

Latest version: [![#](https://img.shields.io/nuget/vpre/DotNetGraph.svg)](https://www.nuget.org/packages/DotNetGraph/absoluteLatest)

# Usage

## Create a graph (*DotGraph*)

```csharp
var graph = new DotGraph().WithIdentifier("MyGraph");

var directedGraph = new DotGraph().WithIdentifier("MyDirectedGraph").Directed();
```

## Create and add a node (*DotNode*)

```csharp
var myNode = new DotNode()
    .WithIdentifier("MyNode")
    .WithShape(DotNodeShape.Ellipse)
    .WithLabel("My node!")
    .WithFillColor(DotColor.Coral)
    .WithFontColor(DotColor.Black)
    .WithStyle(DotNodeStyle.Dotted)
    .WithWidth(0.5)
    .WithHeight(0.5)
    .WithPenWidth(1.5);

// Add the node to the graph
graph.Add(myNode);
```

## Create and add an edge (*DotEdge*)

```csharp
// Create an edge with identifiers
var myEdge = new DotEdge().From("Node1").To("Node2");

// Or with nodes and attributes
var myEdge = new DotEdge()
    .From(node1)
    .To(node2)
    .WithArrowHead(DotEdgeArrowType.Box)
    .WithArrowTail(DotEdgeArrowType.Diamond)
    .WithColor(DotColor.Red)
    .WithFontColor(DotColor.Black)
    .WithLabel("My edge!")
    .WithStyle(DotEdgeStyle.Dashed)
    .WithPenWidth(1.5);

// Add the edge to the graph
graph.Add(myEdge);
```

## Create a subgraph / cluster

```csharp
// Subgraph identifier need to start with "cluster" to be identified as a cluster
var mySubGraph = new DotSubGraph().WithIdentifier("cluster_0");

// Create a subgraph with attributes (only used for cluster)
var mySubGraph = new DotSubGraph()
    .WithIdentifier("cluster_0")
    .WithColor(DotColor.Red)
    .WithStyle(DotSubGraphStyle.Dashed)
    .WithLabel("My subgraph!");

// Add node, edge, subgraph
subGraph.Add(myNode);
subGraph.Add(myEdge);
subGraph.Add(mySubGraph2);

// Add subgraph to main graph
graph.Add(mySubGraph);
```

## Compile to DOT format

```csharp
await using var writer = new StringWriter();
var context = new CompilationContext(writer, new CompilationOptions());
await graph.CompileAsync(context);

var result = writer.GetStringBuilder().ToString();

// Save it to a file
File.WriteAllText("graph.dot", result);
```
<hr>

### Credits

Logo: https://www.flaticon.com/free-icon/flow-chart_4411911