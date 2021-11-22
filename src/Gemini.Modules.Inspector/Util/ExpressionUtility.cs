using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Gemini.Modules.Inspector.Util
{
    internal static class ExpressionUtility
    {
        public static string GetPropertyName<T, TProperty>(Expression<Func<T, TProperty>> expression) => GetPropertyNameInternal(expression);

        private static string GetPropertyNameInternal(LambdaExpression expression)
        {

/* Unmerged change from project 'Gemini.Modules.Inspector (netcoreapp3.1)'
Before:
            var member = expression.Body as MemberExpression;
            if (member == null)
After:
            var (!(expression.Body is MemberExpression;
            if (member))
*/

/* Unmerged change from project 'Gemini.Modules.Inspector (net461)'
Before:
            var member = expression.Body as MemberExpression;
            if (member == null)
After:
            var (!(expression.Body is MemberExpression;
            if (member))
*/
            if (expression.Body is not MemberExpression member)
                throw new ArgumentException(string.Format(
                    "Expression '{0}' refers to a method, not a property.",
                    expression));

            var propertyInfo = member.Member as PropertyInfo;
            if (propertyInfo == null)
                throw new ArgumentException(string.Format(
                    "Expression '{0}' refers to a field, not a property.",
                    expression));

            return propertyInfo.Name;
        }
    }
}