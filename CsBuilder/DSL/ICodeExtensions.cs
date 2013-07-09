using System;
using CsBuilder.Statements;
using CsBuilder.Expressions;

namespace CsBuilder.DSL
{
    public static class ICodeExtensions
    {
        public static UsingStatement Using(this ICode code, string @namespace)
        {
            return new UsingStatement(@namespace, code);
        }

        public static Statement Namespace(this ICode code, string @namespace)
        {
            return new NamespaceStatement(@namespace, code);
        }

    }
}