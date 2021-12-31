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

        private void AssertFirstElement<T>(IDotGraph sut)
            where T : IDotElement
        {
            Check.That(sut.Elements).CountIs(1);
            Check.That(sut.Elements[0]).IsInstanceOfType(typeof(T));
        }

        [Theory]
        [MemberData(nameof(GetGraphs))]
        public void NewNode_WhenCalled_ThenNewNodeIsAdded(IDotGraph sut)
        {
            var id = "A";
            sut.NewNode(id);
            
            AssertFirstElement<DotNode>(sut);
        }

        [Theory]
        [MemberData(nameof(GetGraphs))]
        public void NewEdge_WhenCalledWithStrings_ThenNewEdgeIsAdded(IDotGraph sut)
        {
            var left = "A";
            var right = "B";
            sut.NewEdge(left, right);

            AssertFirstElement<DotEdge>(sut);
        }

        [Theory]
        [MemberData(nameof(GetGraphs))]
        public void NewEdge_WhenCalledWithElements_ThenNewEdgeIsAdded(IDotGraph sut)
        {
            var left = new DotNode("A");
            var right = new DotNode("B");
            sut.NewEdge(left, right);

            AssertFirstElement<DotEdge>(sut);
        }

        [Theory]
        [MemberData(nameof(GetGraphs))]
        public void NewSubGraph_WhenCalled_ThenSubGraphIsAdded(IDotGraph sut)
        {
            var id = "A";
            sut.NewSubGraph(id);

            AssertFirstElement<DotSubGraph>(sut);
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
