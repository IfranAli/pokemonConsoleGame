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

		public void trainerFontColour() {
			if (TrainerName.ToUpper() == "RED") {
				Console.ForegroundColor = ConsoleColor.Red;
			} else if (TrainerName.ToUpper() == "BLUE") {
				Console.ForegroundColor = ConsoleColor.Blue;
			} else {
				Console.ForegroundColor = ConsoleColor.White;
			}
		}

		public void AddPokemon(IPokemon pokemon){
			Pokemons.Add ((Pokemon)pokemon);
		}
			
		public Pokemon GetNextUsablePokemon() {
			Pokemon x;
			try {
				x = Pokemons.First (p => !p.isFainted());
				OnField = x;
			} catch (NullReferenceException) {
				throw new InvalidOperationException();
				Console.WriteLine ("{0} is out of usable pokemon.", TrainerName);
			}
			trainerFontColour ();
			Console.Write(TrainerName);
			Console.ForegroundColor = ConsoleColor.White;
			Console.Write(" sent out ");
			Console.Write("{0}\n", OnField.Name);
			Console.ForegroundColor = ConsoleColor.White;
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