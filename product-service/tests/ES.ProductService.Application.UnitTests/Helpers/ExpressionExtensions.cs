using System;
using System.Linq;
using System.Linq.Expressions;

namespace ES.ProductService.Application.UnitTests.Helpers;

public static class ExpressionExtensions
{
    public static bool EqualsTo<T>(
        this Expression<Func<T, bool>> expr1,
        Expression<Func<T, bool>> expr2)
    {
        var expr1Visitor = new ExpressionVisitor();
        expr1Visitor.Visit(expr1);

        var expr2Visitor = new ExpressionVisitor();
        expr2Visitor.Visit(expr2);

        var result = expr1Visitor.Nodes.Except(expr2Visitor.Nodes).ToList();

        return !result.Any();
    }
}