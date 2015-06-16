using System;
using System.Linq;
using System.Collections.Generic;

namespace pokemon_b
{
	public class Trainer
	{
		public Pokemon OnField;
		public List<Pokemon> Pokemons;
		public String TrainerName;
		public Trainer (String trainerName)
		{
			Pokemons = new List<Pokemon> ();
			TrainerName = trainerName;
		}

		public void AddPokemon(Pokemon pokemon){
			Pokemons.Add (pokemon);
		}

		public Pokemon GetNextUsablePokemon() {
			Pokemon x;
			try {
				x = Pokemons.First (p => !p.isFainted());
				OnField = x;
			} catch (NullReferenceException) {
				throw new InvalidOperationException();
			}
			Console.WriteLine ("{0} sent out {1}", TrainerName, OnField.Name);
			return x;
		}

		virtual public void PerformTurn(Trainer opponent) {
			if (OnField.isFainted ()) {
				try {
					GetNextUsablePokemon ();
				} catch (InvalidOperationException ex) {
					throw ex;
				}
			} else {
				var highestDMG = OnField.PokemonMovePool.getHighestDamage ();
				var enemyweakness = OnField.PokemonMovePool.getEnemyWeakestTo (opponent.OnField);
				if (enemyweakness != null) {
					if ((enemyweakness.Damage * 2.0) > highestDMG.Damage) {
						OnField.PerformAttack (opponent.OnField, enemyweakness);
						return;
					}
				}
				OnField.PerformAttack (opponent.OnField, highestDMG);
			}
		}
	}
}