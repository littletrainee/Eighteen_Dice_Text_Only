namespace EighteenDice {
  internal class Player {
    // public 
    public string name = "";
    public List<int> hand = new List<int>();
    public int chips { get; set; }
    public bool bookmaker { get; set; }
    public int point { get; set; }
    //private
    public List<int> probablypair = new List<int>();
    public void Check() {
      List<int> temphand = new List<int>(this.hand);
      temphand.Sort();
      for (int i = 1; i <= 7; i++)
        if (this.hand.Count(t => t == i) == 2 || this.hand.Count(t=> t== i) == 4)
          this.probablypair.Add(i);

      if (this.probablypair.Any()) {
        for (int i = 0; i < 2; i++)
          temphand.Remove(this.probablypair[0]);
        this.point = temphand[0] + temphand[1];
      } else {
        this.point = 0;
      }
    }

    public void PrintHandAndPoint() {
      Console.Write("{0} hand is :", this.name);
      foreach (int i in this.hand)
        Console.Write(i + " ");
      Console.WriteLine();
      Console.Write("{0} point is : {1}", this.name, this.point);
      Console.WriteLine();
    }
  }
}
