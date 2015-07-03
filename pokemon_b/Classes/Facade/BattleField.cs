using System;
using System.Collections.Generic;

namespace pokemon_b
{
	public class BattleField
	{
		private EventHook mEventHook;
		private Battle mBattle;

		public Trainer Red, Blue;
		public BattleField (EventHook eventHook)
		{
			mEventHook = eventHook;

			var pokeGarden = new PokeGarden ();

			// Assign Pokemon to Trainer object.
			Red = new Player(mEventHook, "Red");
			Red.AddPokemon(new PokeGarden.Bulbasaur());
			Red.AddPokemon (new PokeGarden.Charmander());
			//red.AddPokemon(pokeGarden.Generate("MegaMewTwo", 80));
			//red.AddPokemon(pg.Generate("Deoxys", 80));

			Blue = new Trainer (mEventHook, "Blue");
			Blue.AddPokemon (new PokeGarden.Tirwig());
			Blue.AddPokemon (new PokeGarden.Zangoose());
			//blue.AddPokemon(pokeGarden.Generate("Mew", 80));
			//blue.AddPokemon(pg.Generate("Jirachi", 80));

			// Pass Trainers to Battle object.
			mBattle = new Battle(mEventHook, Red, Blue);

		}

		public Boolean ContinueBattle() {
			Console.WriteLine("Continuing battle");
			return mBattle.Continue ();
		}

		public List<String> GetCurrentTurnDetails() {
			return mBattle.GetTurnLog();
		}

		public Trainer GetPlayer() {
			return Red;
		}
	}
}