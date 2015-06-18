using System;

namespace pokemon_b
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			//var pg = new PokeGarden ();
			// Assign Pokemon to Trainer object.
			Trainer red = new Player("Red");
			red.AddPokemon(new PokeGarden.Bulbasaur());
			red.AddPokemon (new PokeGarden.Charmander());
			//red.AddPokemon(pg.Generate("MegaMewTwo", 80));
			//red.AddPokemon(pg.Generate("Deoxys", 80));

			Trainer blue = new Trainer ("Blue");
			blue.AddPokemon (new PokeGarden.Tirwig());
			blue.AddPokemon (new PokeGarden.Zangoose());
			//blue.AddPokemon(pg.Generate("Mew", 80));
			//blue.AddPokemon(pg.Generate("Jirachi", 80));

			// Pass Trainers to Battle object.
			new Battle(red, blue);
		}
	}
}