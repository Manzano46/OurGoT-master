namespace OurGoT.Pages
{
    public class UpRange : UpAttack
    {
        public UpRange(Card A, Expression P) : base(A, P)
        {
        }
        public override void Run()
        {
            if (Play.CurrentPlayer is VirtualPlayer)
                B = Play.CurrentPlayer.Choose_Card(A, 1);
            else
            {
                B = Play.Position;
            }
            Play.MessegeAction = $"{A.Name}  modified the Range of {B.Name} on {P.Evaluate( )}";
            //await Task.Delay(1000);
            if (B.Name == "*" ||  (Methods.Distance(A.Posx, A.Posy, B.Posx, B.Posy) > A.Range.Evaluate()) || B.Name == "**")
            {
                System.Console.WriteLine("Your spell was misused");
                return;
            }
            B.Range = new Sum(B.Range,P);
            System.Console.WriteLine("{2} has modified the range of {0} on {1}", B.Name, P.Evaluate(), A.Name);
            System.Console.WriteLine("Now the Range of {0} is {1}", B.Name, B.Range.Evaluate());
            Play.Context.Save(B.Name + ".Range", B.Range.Evaluate());
        }
    }
}
