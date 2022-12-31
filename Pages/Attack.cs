namespace OurGoT.Pages
{
    public class Attack : Action
    {
        Card A;
        Card B = new Card();

        public Attack(Card A)
        {
            this.A = A;
        }
        public override void Run()
        {
            if (Methods.OnRange(A.Posx, A.Posy, Play.NextPlayer.CampCards, A.Range.Evaluate()).Count() != 0)
            {

                if (Play.CurrentPlayer is VirtualPlayer)
                    B = Play.CurrentPlayer.Choose_Card(A, 2);
                else
                    B = Play.Position;
                
                Play.MessegeAction = $"{A.Name}  Attack to {B.Name}";
                
                if (B.Name == "*" || (Methods.Distance(A.Posx, A.Posy, B.Posx, B.Posy) > A.Range.Evaluate()) || B.Name == "**")
                {
                    Play.MessegeAction = "Your spell was misused";
                    System.Console.WriteLine("Your spell was misused");
                    return;
                }
                System.Console.WriteLine("{0} attack to {1}", A.Name, B.Name);
                if (A.Attack.Evaluate() > B.Defense.Evaluate())
                {
                    System.Console.Write("Life of {0} down from {1} to ", B.Name, B.Life.Evaluate());
                    B.Life = new Sub(B.Life,new Sub(A.Attack,B.Defense));
                    System.Console.WriteLine(B.Life);
                }
                else
                {
                    System.Console.WriteLine("Defense of {0} is bigger than attack of {1}", B.Name, A.Name);
                    Play.MessegeAction = $"{B.Name} Defense's is bigger than attack of {A.Name}";
                }
                if(new Minus(B.Life,new Constant(0)).Evaluate() == 1)
                {
                    B.Life = new Constant(0);
                }
                if (B.Life.Evaluate() <= 0)
                {
                    System.Console.WriteLine("{0} has died", B.Name);
                    Console.WriteLine("You earn {0}", B.Cost.Evaluate() / 2);
                    Play.CurrentPlayer.Money += B.Cost.Evaluate() / 2;
                    Play.NextPlayer.CampCards.Remove(B);
                    Play.Graveyard.Add(B);
                    Play.Tab[B.Posx, B.Posy] = new Card();
                    Play.Tab[B.Posx, B.Posy].Posx = B.Posx;
                    Play.Tab[B.Posx, B.Posy].Posy = B.Posy;
                    Play.Context.Save(Play.NextPlayer.Name + ".CampCards", Play.NextPlayer.CampCards.Count());
                    Play.MessegeAction = $"{B.Name} has died";
                }

                Play.Context.Save(B.Name + ".Life", B.Life.Evaluate());
            }
            else
            {
                Play.MessegeAction = $"You cannot Attack anymore";
                //await Task.Delay(1000);
                System.Console.WriteLine("You cannot Attack anymore, because there is not enemies around");
            }
        }
    }
}
