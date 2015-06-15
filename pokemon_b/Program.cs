using System;

namespace pokemon_b
{
	class MainClass
	{
		public static void Main (string[] args)
		{
//			Console.WriteLine (new PokeGarden.Tirwig ().getInfo ());
//			Console.WriteLine (new PokeGarden.Zangoose ().getInfo ());
//			Console.WriteLine (new PokeGarden.Charmander ().getInfo ());

			// Assign Pokemon to Trainer object.
			Trainer red = new Trainer("Red");
			red.AddPokemon(new PokeGarden.Bulbasaur());
			red.AddPokemon (new PokeGarden.Charmander());
			Trainer blue = new Trainer ("Blue");
			blue.AddPokemon (new PokeGarden.Tirwig());
			blue.AddPokemon (new PokeGarden.Zangoose());

			// Pass Trainers to Battle object.
			new Battle(red, blue);

			//Console.WriteLine (bulbasaur.getInfo ());
			//Console.WriteLine (charmander.getInfo ());
			//Console.WriteLine (zangoose.getInfo ());
		}
	}
}