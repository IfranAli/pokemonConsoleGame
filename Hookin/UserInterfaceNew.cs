using System;
using pokemon_b;

namespace Hookin
{
	public class UserInterfaceNew : EventHook
	{
		Trainer mRed, mBlue;
		public UserInterfaceNew () {
			drawBox (new Point (0, 2), new Point( 10, 10));
		}

		#region EventHook implementation

		public void TurnPassed (int turns)
		{
			
		}

		public void JoinedBattle (Trainer trainer)
		{
			if (mRed == null) {
				mRed = trainer;
			} else {
				mBlue = trainer;
			}
		}

		public void PlayerPerformTurn (Trainer player, Trainer opponent)
		{
			
			Console.WriteLine("NUM\tNAME\t\tDMG\tTYPE");
			foreach (Attack a in player.OnField.PokemonMovePool.Attacks) {
				Console.WriteLine ("{0}\t{1}\t{2}\t{3}", player.OnField.PokemonMovePool.Attacks.IndexOf(a), a.Name,
					a.Damage, a.AttackType);
			}
			Console.Write("Select Move: ");

			string input = Console.ReadLine ();
			int move = int.Parse (input);

			Attack attack = player.OnField.PokemonMovePool.Attacks [move];

			player.OnField.PerformAttack(opponent.OnField, attack);
		}

		public void OnPerformTurn (int turnsPassed, Trainer player, Trainer opponent)
		{
			if (player.TrainerName.Equals (mRed.TrainerName)) {
				DrawHealthBars (player, opponent);
			} else {
				DrawHealthBars (opponent, player);
			}
		}

		public void HasWon (Trainer trainer)
		{
			HasMessage (String.Format ("{0} has won!", trainer.TrainerName));
		}
			
		public void HasMessage (string message)
		{
			clearSegment (0, 15);
			clearSegment ((Console.BufferWidth - message.Length) / 2, 15);
			drawBox (new Point(0,13), new Point(Console.BufferWidth / 2, 17));
			Console.SetCursorPosition (((Console.BufferWidth / 2) - message.Length) / 2, 15);
			Console.Write (message);
			Console.ReadKey ();
		}
		#endregion

		void DrawHealthBars(Trainer trainer, Trainer opponent){
			clearSegment (0, 0);
			clearSegment (0, 1);
			Console.SetCursorPosition (0, 0);
			Console.Write (trainer.OnField.Name);
			Console.SetCursorPosition (0, 1);
			Console.Write (trainer.OnField.GenHealthBar());

			Console.SetCursorPosition (Console.BufferWidth -
				opponent.OnField.Name.Length, 0);
			Console.Write (opponent.OnField.Name);
			Console.SetCursorPosition (Console.BufferWidth -
				opponent.OnField.GenHealthBar ().Length, 1);
			Console.Write (opponent.OnField.GenHealthBar ());
		}

		void clearSegment(int left, int top) {
			Console.SetCursorPosition (left, top);
			Console.Write (new String (' ', Console.BufferWidth));
			Console.SetCursorPosition (left, top);
		}

		public void drawBox(Point a, Point b) {
			for (int i = a.top; i <= b.top; i++) {
				Console.SetCursorPosition (a.left, i);
				if (i == a.top || i == b.top) {
					Console.Write (new String ('#', b.left - a.left));
				} else {
					Console.SetCursorPosition (a.left, i);
					Console.Write ('#');
					Console.SetCursorPosition (b.left -1, i);
					Console.Write ('#');
				}
			}
		}

		public struct Point {
			public int left, top;
			public Point(int left, int top) {
				this.left = left;
				this.top = top;
			}
		};
	}
}

