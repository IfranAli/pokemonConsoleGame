using System;
using pokemon_b;

namespace Hookin
{
	public class UserInterfaceNew : EventHook
	{
		int mConsoleWidth, mConsoleHeight;
		Trainer mRed, mBlue;
		public UserInterfaceNew () {
			mConsoleHeight = Console.BufferHeight;
			mConsoleWidth = Console.BufferWidth;
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
			
		}

		#endregion

		void DrawHealthBars(Trainer trainer, Trainer opponent){
			Console.SetCursorPosition (0, 0);
			Console.Write (trainer.OnField.Name);
			Console.SetCursorPosition (0, 1);
			Console.Write (trainer.OnField.GenHealthBar());

			Console.SetCursorPosition (mConsoleWidth -
				opponent.OnField.Name.Length, 0);
			Console.Write (opponent.OnField.Name);
			Console.SetCursorPosition (mConsoleWidth -
				opponent.OnField.GenHealthBar ().Length, 1);
			Console.Write (opponent.OnField.GenHealthBar ());
		}
	}
}

