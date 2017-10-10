# DotNetGraph

### Create **DOT diagram** using **C# / .Net** (http://bit.ly/2kJGlGB)

# DotNetGraph Documentation

## Create a graph (*DotGraph*)

```csharp
var graph = new DotGraph("MyGraph");

var directedGraph = new DotGraph("MyDirectedGraph", true);
```

## Create and add a node (*DotNode*)

```csharp
var myNode = new DotNode("MyNode") {
    // Set all available properties
    Shape = DotNodeShape.Ellipse,
    Label = "My node !",
    FillColor = DotColor.Lightgrey,
    FontColor = DotColor.Black,
    Style = DotNodeStyle.Default,
    Height = 0.5f
};

// Add the node to the graph
graph.Add(myNode);
```

## Create and add an arrow (*DotArrow*)

```csharp
// Create an arrow with node names
var myArrow = new DotArrow("myNode1", "myNode2");

// Create an arrow with node objects
var myArrow = new DotArrow(myNode1, myNode2) {
    // Set all available properties
    ArrowHeadShape = DotArrowShape.Normal;
};

// Add the arrow to the graph
graph.Add(myArrow);
```

## Compile to DOT format

```csharp
// Indented version
var dot = graph.Compile();

// Minified version
var dot = graph.Compile(true);

// Save it to a file
File.WriteAllText("myFile.dot", dot);
```