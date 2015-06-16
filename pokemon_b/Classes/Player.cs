using System;

namespace pokemon_b
{
	public class Player : Trainer
	{
		public Player (String playerName)
			:base(playerName) {

		}

		public override void PerformTurn(Trainer opponent) {
			if (OnField.isFainted ()) {
				try {
					GetNextUsablePokemon ();
				} catch (InvalidOperationException ex) {
					throw ex;
				}
			} else {
				textGui (opponent);
				//OnField.PerformAttack (opponent.OnField);
			}
		}

		void textGui(Trainer opponent) {
			Console.WriteLine("NUM\tNAME\t\tDMG\tTYPE");
			foreach (Attack a in this.OnField.PokemonMovePool.Attacks) {
				Console.WriteLine ("{0}\t{1}\t{2}\t{3}", OnField.PokemonMovePool.Attacks.IndexOf(a), a.Name,
					a.Damage, a.AttackType);
			}
			Console.WriteLine ("Enter option: ");


			int input = int.Parse(Console.ReadLine());
			Console.WriteLine (input);

			Attack attack = OnField.PokemonMovePool.Attacks [input];

			OnField.PerformAttack(opponent.OnField, attack);
		}
	}
}

