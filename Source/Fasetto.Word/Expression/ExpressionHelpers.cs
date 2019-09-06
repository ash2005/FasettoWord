using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Fasetto.Word.Expression
{
    public static class ExpressionHelpers
    {
        public static T GetPropertyValue<T>(this Expression<Func<T>> lambda)
        {
            return lambda.Compile().Invoke();
        }

        /// <summary>
        /// Sets the underlying properties value t the given value from an expression that contains the property
        /// </summary>
        /// <typeparam name="T">The type of value to set</typeparam>
        /// <param name="lambda">the expression</param>
        /// <param name="value">the value to set the property to</param>
        public static void SetPropertyValue<T>(this Expression<Func<T>> lambda, T value)
        {
            // this converts a lambda  () => some.Property to some.Property
            if (!(lambda.Body is MemberExpression expression))
                return;

            // get the property info so we can set it
            var propertyInfo = (PropertyInfo) expression.Member;

            var target  = System.Linq.Expressions.Expression.Lambda(expression.Expression).Compile().DynamicInvoke();
            // Set the property value
            propertyInfo.SetValue(target, value);
        }
    }
}
