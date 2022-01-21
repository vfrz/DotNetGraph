using DotNetGraph.SubGraph;
using DotNetGraph.Extensions;
using System.Collections.Generic;
using Xunit;
using NFluent;
using DotNetGraph.Core;
using DotNetGraph.Node;
using DotNetGraph.Edge;

namespace DotNetGraph.Tests.Extensions
{
    public class DotGraphExtensionsTests
    {
        public static IEnumerable<object[]> GetGraphs()
        {
            yield return new[] { new DotGraph("G") };
            yield return new[] { new DotSubGraph("cluster_0") };
        }

        private void AssertSingleElement<T>(IDotGraph sut)
            where T : IDotElement
        {
            Check.That(sut.Elements).CountIs(1);
            Check.That(sut.Elements[0]).IsInstanceOfType(typeof(T));
        }

        [Theory]
        [MemberData(nameof(GetGraphs))]
        public void AddNode_WhenCalled_ThenNewNodeIsAdded(IDotGraph sut)
        {
            var id = "A";
            sut.AddNode(id);

            AssertSingleElement<DotNode>(sut);
        }

        [Theory]
        [MemberData(nameof(GetGraphs))]
        public void AddEdge_WhenCalledWithStrings_ThenNewEdgeIsAdded(IDotGraph sut)
        {
            var left = "A";
            var right = "B";
            sut.AddEdge(left, right);

            AssertSingleElement<DotEdge>(sut);
        }

        [Theory]
        [MemberData(nameof(GetGraphs))]
        public void AddEdge_WhenCalledWithElements_ThenNewEdgeIsAdded(IDotGraph sut)
        {
            var left = new DotNode("A");
            var right = new DotNode("B");
            sut.AddEdge(left, right);

            AssertSingleElement<DotEdge>(sut);
        }

        [Theory]
        [MemberData(nameof(GetGraphs))]
        public void AddSubGraph_WhenCalled_ThenSubGraphIsAdded(IDotGraph sut)
        {
            var id = "A";
            sut.AddSubGraph(id);

            AssertSingleElement<DotSubGraph>(sut);
        }

        [Theory]
        [MemberData(nameof(GetGraphs))]
        public void AddLine_WhenCalled_ThenLineIsAdded(IDotGraph sut)
        {
            var line = "raw line";
            sut.AddRawLine(line);

            Check.That(sut.Elements).CountIs(1);
            Check.That(((DotString)sut.Elements[0]).Value).HasSameValueAs(line);
        }
    }
}
