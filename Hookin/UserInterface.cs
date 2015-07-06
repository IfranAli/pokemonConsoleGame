using System;
using pokemon_b;

namespace Hookin
{
	public class UserInterface : EventHook
	{
		#region EventHook implementation

		public void TurnPassed (int turns) {
//			Console.WriteLine ("Turn {0}", turns);
		}
			
		public void JoinedBattle (Trainer trainer)
		{
//			Console.WriteLine ("{0} Joined the battle.",
//				trainer.TrainerName
//			);
		}

		public int pokemon;
		public int move;
		public TurnType PlayerPerformTurn (Trainer player, Trainer opponent) {
			Attack attack = player.OnField.PokemonMovePool.Attacks [move];
			return player.OnField.PerformAttack(new AttackTurn(player.OnField, opponent.OnField, attack));
		}

		public void OnPerformTurn (int turnsPassed, Trainer player, Trainer opponent)
		{
//			Console.WriteLine("\n{0} : Turn {1}\n{2}\n{3}",
//				player.TrainerName, turnsPassed, player.OnField.Name,
//				player.OnField.GenHealthBar());
		}

		public void HasWon (Trainer trainer)
		{
			//Console.Write ("{0} Has Won!\n", trainer.TrainerName);
		}

		public void HasMessage (string message)
		{
			//Console.WriteLine (message);
		}
		#endregion
	}
}

