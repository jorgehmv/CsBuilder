using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CsBuilder.Expressions;

namespace CsBuilder.DSL
{
    public static class BooleanExtensions
    {
        public static Expression Value(this bool value)
        {
            return value ? Expression.True : Expression.False;
        }
    }
}
