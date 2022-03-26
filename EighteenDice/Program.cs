namespace EighteenDice {
  class Program {
    public static List<int> RollDice(Random rnd) {
      List<int> temp = new List<int>();
      for (int i = 0; i < 4; i++)
        temp.Add(rnd.Next(1, 7));
      return temp;
    }
    // delegate
    public delegate void printhandandpoint();

    public static void Main() {
      // instance
      Random rnd = new Random();
      Player p1 = new Player();
      Player p2 = new Player();
      // set name
      p1.name = "player1";
      p2.name = "player2";
      // set chips
      p1.chips = 100;
      p2.chips = 100;
      // set bookmaker
      p1.bookmaker = true;

      // delegate
      printhandandpoint pp = new printhandandpoint(p1.PrintHandAndPoint);
      pp += new printhandandpoint(p2.PrintHandAndPoint);

      // player1 roll dice and get point
      p1.hand = RollDice(rnd);
      p1.Check();
      while (p1.point == 0) {
        p1.hand = RollDice(rnd);
        p1.Check();
      }

      // player2 roll dice and get point
      p2.hand = RollDice(rnd);
      p2.Check();
      while (p2.point == 0) {
        p2.hand = RollDice(rnd);
        p2.Check();
      }

      pp();
      if (p1.point < p2.point)
        Console.WriteLine("Player2 Win!");
      else if (p1.point > p2.point)
        Console.WriteLine("player1 Win!");
    }
  }
}