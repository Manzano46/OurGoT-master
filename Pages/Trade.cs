namespace OurGoT.Pages
{
    public class Trade : Action
    {
        Player Player = Play.CurrentPlayer;
        Expression P;
        public Trade(Expression P)
        {
            this.P = P;
        }
        public override void Run()
        {
            if (Play.CurrentPlayer is VirtualPlayer)
            {
                if (P.Evaluate() < 0) Player = Play.CurrentPlayer.Choose_Player(2);
                            else Player = Play.CurrentPlayer.Choose_Player(1);
                          
            }
            else
            {
                Play.OnTrade = true;
                if(Play.CurrentPlayer.Name == Play.SelectedPlayer)
                    Player = Play.CurrentPlayer;
                else
                    Player = Play.NextPlayer; 
                Play.OnTrade = false;
            }
            Player.Money += P.Evaluate();
            System.Console.WriteLine("The Money of {0} has been modified on {1}", Player.Name, P.Evaluate());
            System.Console.WriteLine("Now is {0}", Player.Money);
            Play.Context.Save(Player.Name + ".Money", Player.Money);
            Play.MessegeAction = $"{Player.Name} has been modified on {P.Evaluate()}";
        }
    }
}
