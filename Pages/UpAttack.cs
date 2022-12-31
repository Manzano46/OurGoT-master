namespace OurGoT.Pages
{
    public class UpAttack : Action
    {
        protected Card A;
        protected Expression P;
        protected Card B = new Card();
        public UpAttack(Card A, Expression P)
        {
            this.A = A;
            this.P = P;
        }
        public override void Run()
        {
            if (Play.CurrentPlayer is VirtualPlayer)
                B = Play.CurrentPlayer.Choose_Card(A, 1);
            else
            {
                B = Play.Position;
            }
            Play.MessegeAction = $"{A.Name}  modified the Attack of {B.Name} on {P.Evaluate()}";
            //await Task.Delay(1000);
            if (B.Name == "*"  || (Methods.Distance(A.Posx, A.Posy, B.Posx, B.Posy) > A.Range.Evaluate()) || B.Name == "**") 
            {
                System.Console.WriteLine("Your spell was misused");
                return;
            }
            B.Attack = new Sum(B.Attack,P);
            System.Console.WriteLine("{2} has modified the attack of {0} on {1}", B.Name, P, A.Name);
            System.Console.WriteLine("Now the attack of {0} is {1}", B.Name, B.Attack.Evaluate());
            Play.Context.Save(B.Name + ".Attack", B.Attack.Evaluate());
        }
    }
}
