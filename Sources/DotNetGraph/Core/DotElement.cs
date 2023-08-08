using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DotNetGraph.Attributes;
using DotNetGraph.Compilation;

namespace DotNetGraph.Core
{
    public abstract class DotElement : IDotElement
    {
        protected readonly Dictionary<string, IDotAttribute> Attributes = new Dictionary<string, IDotAttribute>();

        // Common attributes
        public DotLabelAttribute Label
        {
            get => GetAttributeOrDefault<DotLabelAttribute>("label");
            set => SetAttribute("label", value);
        }

        public DotColorAttribute FontColor
        {
            get => GetAttributeOrDefault<DotColorAttribute>("fontcolor");
            set => SetAttribute("fontcolor", value);
        }

        // Attribute methods
        public bool HasAttribute(string name)
        {
            return Attributes.ContainsKey(name);
        }
        
        public IDotAttribute GetAttribute(string name)
        {
            if (Attributes.TryGetValue(name, out var attribute))
                return attribute;
            throw new Exception($"There is no attribute named '{name}'");
        }

        public IDotAttribute GetAttributeOrDefault(string name, IDotAttribute defaultValue = default)
        {
            if (Attributes.TryGetValue(name, out var attribute))
                return attribute;
            return defaultValue;
        }

        public T GetAttribute<T>(string name) where T : IDotAttribute
        {
            var attribute = GetAttribute(name);
            if (attribute is T result)
                return result;
            throw new Exception($"Attribute with name '{name}' doesn't match the expected type (expected: {typeof(T)}, current: {attribute.GetType()})");
        }

        public T GetAttributeOrDefault<T>(string name, T defaultValue = default) where T : IDotAttribute
        {
            if (Attributes.TryGetValue(name, out var attribute))
            {
                if (attribute is T result)
                    return result;
                throw new Exception($"Attribute with name '{name}' doesn't match the expected type (expected: {typeof(T)}, current: {attribute.GetType()})");
            }

            return defaultValue;
        }

        public bool TryGetAttribute(string name, out IDotAttribute attribute)
        {
            var result = Attributes.TryGetValue(name, out var outAttribute);
            if (result)
            {
                attribute = outAttribute;
                return true;
            }

            attribute = default;
            return false;
        }

        public bool TryGetAttribute<T>(string name, out T attribute) where T : IDotAttribute
        {
            var result = TryGetAttribute(name, out var untypedAttribute);
            if (result is false)
            {
                attribute = default;
                return false;
            }

            if (untypedAttribute is T typedAttribute)
            {
                attribute = typedAttribute;
                return true;
            }

            throw new Exception($"Attribute with name '{name}' doesn't match the expected type (expected: {typeof(T)}, current: {untypedAttribute.GetType()})");
        }

        public void SetAttribute(string name, IDotAttribute value)
        {
            if (value is null)
                RemoveAttribute(name);
            else
                Attributes[name] = value;
        }

        public bool RemoveAttribute(string name)
        {
            return Attributes.Remove(name);
        }

        protected async Task CompileAttributesAsync(CompilationContext context)
        {
            foreach (var attributePair in Attributes)
            {
                await context.WriteIndentationAsync();
                await context.WriteAsync($"\"{attributePair.Key}\"=");
                await attributePair.Value.CompileAsync(context);
                await context.WriteLineAsync();
            }
        }

        public abstract Task CompileAsync(CompilationContext context);
    }
}