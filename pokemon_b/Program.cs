using System;

namespace pokemon_b
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			// Create Pokemon.
			Pokemon.IV iv = new Pokemon.IV (10, 10, 10, 10, 10, 5);
			Pokemon.Stat stat = new Pokemon.Stat (iv, 50, 10, 10, 10, 10, 10, 5);
			Pokemon bulbasaur = new Pokemon ("Bulbasaur", stat);

			iv = new Pokemon.IV (15, 10, 10, 10, 10, 10);
			stat = new Pokemon.Stat(iv ,70, 10, 10, 10, 10, 10, 10);
			Pokemon charmander = new Pokemon ("Charmander", stat);

			Pokemon zangoose = new Pokemon("Zangoose", new Pokemon.Stat(
				new Pokemon.IV(10,10,10,10,10,10), 50, 10,10,10,10,10,10)
			);
			
			// Assign Pokemon to Trainer object.
			Trainer red = new Trainer("Red");
			red.AddPokemon(bulbasaur);
			red.AddPokemon (zangoose);
			Trainer blue = new Trainer ("Blue");
			blue.AddPokemon (charmander);

			// Pass Trainers to Battle object.
			new Battle(red, blue);

			//Console.WriteLine (bulbasaur.getInfo ());
			//Console.WriteLine (charmander.getInfo ());
			//Console.WriteLine (zangoose.getInfo ());
		}
	}
}