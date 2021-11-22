using System;
using System.Linq.Expressions;
using System.Reflection;
using Caliburn.Micro;

namespace Gemini.Framework.Services
{
	public static class ExtensionMethods
	{
        public static string GetExecutingAssemblyName() => Assembly.GetExecutingAssembly().GetAssemblyName();

        public static string GetPropertyName<TProperty>(Expression<Func<TProperty>> property) => property.GetMemberInfo().Name;

        public static string GetPropertyName<TTarget, TProperty>(Expression<Func<TTarget, TProperty>> property) => property.GetMemberInfo().Name;
    }
}