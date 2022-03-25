using System.Linq;
using System.Collections.Generic;
namespace EighteenDice {
  internal class WinCheck {
    private List<int> probablypair = new List<int>();
    private List<int> temphand = new List<int>();
    private void ProbablyPairCheck(Player player) {
      for (int i = 1; i < 7; i++) {
        if (player.hand.Count(t => t == i) == 2) {
          this.probablypair.Add(i);
        }
      }
    }
    public int Check(Player player) {
      this.probablypair = new List<int>();
      this.temphand = new List<int>(player.hand);
      this.temphand.Sort();
      ProbablyPairCheck(player);
      if (this.probablypair.Any()) {
        for (int i = 0; i < 2; i++)
          this.temphand.Remove(this.probablypair[0]);
        return this.temphand[0] + this.temphand[1];
      } else
        return 0;
    }
  }
}
