using System;
using pokemon_b;

namespace Hookin
{
	class MainClass
	{
		public static BattleField battleField;
		public static void Main (string[] args)
		{
			UserInterface ui = new UserInterface ();
			battleField = new BattleField (ui);

			while (true) {
				Console.WriteLine("press 'a 'to continue.");
				var y = Console.ReadKey ();
				if (y.KeyChar == 'a') {
					Console.Clear ();
					ui.move = PickMoveBeforeTurn ();
					if (battleField.ContinueBattle ())
						break;
					PrintBattleStatus ();
				} else {
					break;
				}
			}
		}

		public static int PickMoveBeforeTurn() {
			var details = battleField.GetCurrentTurnDetails ();
			var player = battleField.GetPlayer ();
			Console.WriteLine("NUM\tNAME\t\tDMG\tTYPE");
			foreach (Attack a in player.OnField.PokemonMovePool.Attacks) {
				Console.WriteLine ("{0}\t{1}\t{2}\t{3}", player.OnField.PokemonMovePool.Attacks.IndexOf(a), a.Name,
					a.Damage, a.AttackType);
			}
			Console.Write("Select Move: ");

			string input = Console.ReadLine ();
			int move = int.Parse (input);
			return move;
		}

		public static void PrintBattleStatus() {
			var redHealth = battleField.Red.OnField; 
			var blueHealth = battleField.Blue.OnField; 
			Console.Write ("\n{0} {1}\n{2} {3}\n", redHealth.GenHealthBar(), redHealth.GetName() ,
				blueHealth.GenHealthBar(), blueHealth.GetName());
		}
	}
}