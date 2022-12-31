namespace OurGoT.Pages
{
    public class Card
    {
        public string Name;
        public Expression Life;
        public int TotalLife;
        public Expression Cost;
        public Expression Defense;
        public Expression Attack;
        public string Description;
        public string Picture;
        public Expression Range;
        public int Posx;
        public int Posy;
        public List<Expression> Powers = new List<Expression>();
        public List<Expression> Conditions = new List<Expression>();
        public bool Moved = false;
        public List<bool> Used = new List<bool>(); 
        public Card()
        {
            Name = Description = Picture = "*";
            Posx = Posy = -1;
            Life = Cost = Defense = Attack = Range = new Constant(0);
            TotalLife = 0;

            //Life = TotalLife = Cost = Defense = Attack =Range = Posx = Posy = 0;

            Powers = new List<Expression>();
            Powers.Add(new Constant(0));
            Conditions = new List<Expression>();
            Conditions.Add(new Constant(0));
            Used.Add(false);
            Picture = "../Img/Empty.jpg";
        }

        public void ReadCard()
        {
            System.Console.WriteLine("Name : " + this.Name);
            System.Console.WriteLine("Life : " + this.Life);
            System.Console.WriteLine("Attack : " + this.Attack);
            System.Console.WriteLine("Defense : " + this.Defense);
            System.Console.WriteLine("Range : " + this.Range);
            System.Console.WriteLine("Cost : " + this.Cost);
            System.Console.WriteLine("Description : " + this.Description);
            System.Console.WriteLine("Position : " + this.Posx + " " + this.Posy);
            System.Console.WriteLine();
        }
    }
}
