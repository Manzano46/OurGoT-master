namespace OurGoT.Pages
{
    public class Repetition : Action
    {
        Expression action;
        Expression n;

        public Repetition(Expression action, Expression n)
        {
            this.action = action;
            this.n = n;
        }
        public override void Run()
        {
            System.Console.WriteLine("Is goin to Run an action {0} times", n);
            Play.MessegeAction = $"Is goin to Run an action {n} times";
            //await Task.Delay(1000);
            for (int i = 0; i < n.Evaluate(); i++)
            {
                action.Evaluate();
            }
        }
    }
}
