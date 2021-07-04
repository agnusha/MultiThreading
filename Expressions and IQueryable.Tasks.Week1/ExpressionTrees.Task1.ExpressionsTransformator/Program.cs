﻿/*
 * Create a class based on ExpressionVisitor, which makes expression tree transformation:
 * 1. converts expressions like <variable> + 1 to increment operations, <variable> - 1 - into decrement operations.
 * 2. changes parameter values in a lambda expression to constants, taking the following as transformation parameters:
 *    - source expression;
 *    - dictionary: <parameter name: value for replacement>
 * The results could be printed in console or checked via Debugger using any Visualizer.
 */
using System;
using System.Linq.Expressions;

namespace ExpressionTrees.Task1.ExpressionsTransformer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Expression Visitor for increment/decrement.");
            Console.WriteLine();

            var visitor = new IncDecExpressionVisitor();

            Expression<Func<Int32, Int32>> expressionInc = variable => variable + 1;
            Expression<Func<Int32, Int32>> expressionDec = variable => variable - 1;

            Visit(visitor, expressionInc);
            Visit(visitor, expressionDec);

            Console.ReadLine();
        }

        private static void Visit(IncDecExpressionVisitor visitor, Expression<Func<Int32, Int32>> expression)
        {
            Console.WriteLine(expression);

            var res1 = visitor.Modify(expression);
            Console.WriteLine("Result");
            Console.WriteLine(res1);
            Console.WriteLine();

        }
    }
}
