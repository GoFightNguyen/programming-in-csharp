using System;
using System.Linq.Expressions;

namespace _2._78_ExpressionTree
{
    class Program
    {
        static void Main(string[] args)
        {
            //The same as 2.74_CodeDOM, except with expression trees

            BlockExpression blockExpr = Expression.Block(
                Expression.Call(null, typeof(Console).GetMethod("Write", new Type[] { typeof(string) }), Expression.Constant("Hello ")),
                Expression.Call(null, typeof(Console).GetMethod("WriteLine", new Type[] { typeof(string) }), Expression.Constant("World"))
                );

            Expression.Lambda<Action>(blockExpr).Compile(); //compile expression to action since it returns nothing
        }
    }
}
