using System;
using System.Linq.Expressions;

namespace Project.Utilities {
    public static class ExpressionExtensions {
        public static string GetName<T>(this Expression<Func<T>> predicate) {            
            var info = (MethodCallExpression) predicate.Body;
            return info.Method.Name;
        }
    }
}