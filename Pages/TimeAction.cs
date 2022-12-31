namespace OurGoT.Pages
{
    public class TimeAction : Action
    {
        Expression action;
        Expression time;

        public TimeAction(Expression action, Expression time)
        {
            this.action = action;
            this.time = time;
        }

        public override void Run()
        {
            System.Console.WriteLine("A time action has been actived, it will be reactived {0} times", time);
            Play.MessegeAction = $"Is goin to Run an action {time} times";
            //await Task.Delay(1000);
            if (time.Evaluate() <= 0)
            {
                System.Console.WriteLine("The power is finish");
                Play.MessegeAction = $"The power is finish";
              //  await Task.Delay(1000);
                return;
            }
            action.Evaluate();
            time = new Sub(time,new Constant(1));
            if (Play.TimeActions.ContainsKey(action))
                Play.TimeActions[action] += time.Evaluate();
            else
            Play.TimeActions.Add(action, time.Evaluate());
        }
    }
}
