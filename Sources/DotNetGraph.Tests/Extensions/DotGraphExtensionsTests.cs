using DotNetGraph.SubGraph;
using DotNetGraph.Extensions;
using System.Collections.Generic;
using Xunit;
using NFluent;
using DotNetGraph.Core;
using DotNetGraph.Node;

namespace DotNetGraph.Tests.Extensions
{
    public class DotGraphExtensionsTests
    {
        public static IEnumerable<object[]> GetGraphs()
        {
            yield return new[] { new DotGraph("G") };
            yield return new[] { new DotSubGraph("cluster_0") };
        }

        private void AssertFirstElement(IDotGraph sut, IDotElement expected)
        {
            Check.That(sut.Elements).CountIs(1);
            Check.That(sut.Elements[0]).IsSameReferenceAs(expected);
        }

        [Theory]
        [MemberData(nameof(GetGraphs))]
        public void NewNode_WhenCalled_ThenNewNodeIsAdded(IDotGraph sut)
        {
            var id = "A";
            var node = sut.NewNode(id);
            Check.That(node.Identifier).HasSameValueAs(id);
            AssertFirstElement(sut, node);
        }

        [Theory]
        [MemberData(nameof(GetGraphs))]
        public void NewEdge_WhenCalledWithStrings_ThenNewEdgeIsAdded(IDotGraph sut)
        {
            var left = "A";
            var right = "B";
            var edge = sut.NewEdge(left, right);

            Check.That(((DotString)edge.Left).Value).HasSameValueAs(left);
            Check.That(((DotString)edge.Right).Value).HasSameValueAs(right);

            AssertFirstElement(sut, edge);
        }

        [Theory]
        [MemberData(nameof(GetGraphs))]
        public void NewEdge_WhenCalledWithElements_ThenNewEdgeIsAdded(IDotGraph sut)
        {
            var left = new DotNode("A");
            var right = new DotNode("B");
            var edge = sut.NewEdge(left, right);

            Check.That(edge.Left).IsSameReferenceAs(left);
            Check.That(edge.Right).IsSameReferenceAs(right);

            AssertFirstElement(sut, edge);
        }

        [Theory]
        [MemberData(nameof(GetGraphs))]
        public void NewSubGraph_WhenCalled_ThenSubGraphIsAdded(IDotGraph sut)
        {
            var id = "A";
            var subgraph = sut.NewSubGraph(id);
            Check.That(subgraph.Identifier).HasSameValueAs(id);
            AssertFirstElement(sut, subgraph);
        }

        [Theory]
        [MemberData(nameof(GetGraphs))]
        public void AddLine_WhenCalled_ThenLineIsAdded(IDotGraph sut)
        {
            var line = "raw line";
            sut.AddLine(line);

            Check.That(sut.Elements).CountIs(1);
            Check.That(((DotString)sut.Elements[0]).Value).IsSameReferenceAs(line);
        }
    }
}
