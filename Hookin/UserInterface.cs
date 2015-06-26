using System;
using pokemon_b;

namespace Hookin
{
	public class UserInterface : EventHook
	{
		public UserInterface ()
		{
			
		}

		#region EventHook implementation

		public void TurnPassed (int turns) {
			Console.WriteLine ("Turn {0}", turns);
		}
			
		public void JoinedBattle (Trainer trainer)
		{
			Console.WriteLine ("{0} Joined the battle.",
				trainer.TrainerName
			);
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
		#endregion
	}
}

