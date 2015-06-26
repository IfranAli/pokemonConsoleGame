using System;

namespace pokemon_b
{
	public class BattleField
	{
		private EventHook mEventHook;
		public BattleField (EventHook eventHook)
		{
			mEventHook = eventHook;

			var pokeGarden = new PokeGarden ();

			// Assign Pokemon to Trainer object.
			var red = new Player(mEventHook, "Red");
			red.AddPokemon(new PokeGarden.Bulbasaur());
			red.AddPokemon (new PokeGarden.Charmander());
			//red.AddPokemon(pokeGarden.Generate("MegaMewTwo", 80));
			//red.AddPokemon(pg.Generate("Deoxys", 80));

			var blue = new Trainer (mEventHook, "Blue");
			blue.AddPokemon (new PokeGarden.Tirwig());
			blue.AddPokemon (new PokeGarden.Zangoose());
			//blue.AddPokemon(pokeGarden.Generate("Mew", 80));
			//blue.AddPokemon(pg.Generate("Jirachi", 80));

			// Pass Trainers to Battle object.
			new Battle(mEventHook, red, blue);
		}
	}
}