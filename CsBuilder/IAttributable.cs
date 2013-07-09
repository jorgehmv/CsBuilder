using System.Collections.Generic;
using CsBuilder.Statements;

namespace CsBuilder
{
    public interface IAttributable
    {
        IEnumerable<AttributeStatement> Attributes { get; }
        void AddAttribute(AttributeStatement attributeStatement);
    }
}