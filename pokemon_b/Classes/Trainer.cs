using System;
using System.Linq;
using System.Collections.Generic;

namespace pokemon_b
{
	public class Trainer
	{
		public EventHook mEventHook;
		public Pokemon OnField;
		public List<Pokemon> Pokemons;
		public String TrainerName;
		public Trainer (EventHook eventHook, String trainerName)
		{
			mEventHook = eventHook;
			Pokemons = new List<Pokemon> ();
			TrainerName = trainerName;
		}

		public void AddPokemon(Pokemon pokemon){
			pokemon.mEventHook = mEventHook;
			Pokemons.Add (pokemon);
		}
			
		public Pokemon GetNextUsablePokemon() {
			Pokemon x;
			try {
				x = Pokemons.First (p => !p.isFainted());
				OnField = x;
			} catch (NullReferenceException) {
				mEventHook.HasMessage( String.Format ("{0} is out of usable pokemon.", TrainerName));
				throw new InvalidOperationException ();
			}
			mEventHook.HasMessage (String.Format("{0} sent out: {1}", TrainerName, OnField.GetName()));
			return x;
		}

		virtual public void PerformTurn(Trainer opponent) {
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