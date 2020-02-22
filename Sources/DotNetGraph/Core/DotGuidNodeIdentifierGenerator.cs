using System;

namespace DotNetGraph.Core
{
    public class DotGuidNodeIdentifierGenerator : IDotNodeIdentifierGenerator
    {
        public string GenerateIdentifier()
        {
            return Guid.NewGuid().ToString("D");
        }
    }
}