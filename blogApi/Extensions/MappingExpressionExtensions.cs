using AutoMapper;

namespace blogApi.Extensions
{
    public static class MappingExpressionExtensions
    {
        public static IMappingExpression<TSource, TDest> IgnoreAllUnmapped<TSource, TDest>(this IMappingExpression<TSource, TDest> expression)
        {
            expression.ForAllMembers(opt => opt.Ignore());
            return expression;
        }
        public static IMappingExpression<TSource, TDest> IgnoreUnmapped<TSource, TDest>(this IMappingExpression<TSource, TDest> expression, string ignoredProperty)
        {
            expression.ForMember(ignoredProperty, opt => opt.Ignore());
            return expression;
        }
    }
}
