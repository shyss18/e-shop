using System.Collections.Generic;
using System.Linq.Expressions;

namespace ES.ProductService.Application.UnitTests.Helpers;

public class ExpressionVisitor : System.Linq.Expressions.ExpressionVisitor
{
    public Dictionary<string, int> Nodes { get; } = new();

    public override Expression Visit(Expression node)
    {
        var key = node!.NodeType.ToString();
        if (Nodes.ContainsKey(key))
        {
            Nodes[key] += 1;
        }
        else
        {
            Nodes.Add(key, 1);
        }

        return base.Visit(node);
    }
}