﻿namespace OurGoT.Pages
{
    public class Mult : Binary
    {
        public Mult(Expression expression1, Expression expression2) : base(expression1, expression2)
        {
        }
        protected override int Evaluate(int result1, int result2)
        {
            return result1 * result2;
        }
    }
}