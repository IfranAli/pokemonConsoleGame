using System;

namespace pokemon_b
{
	public class PokeGarden
	{
		public PokeGarden ()
		{
			
		}

		public class Tirwig : Pokemon {
			public Tirwig() 
				:base("Tirwig", new Stat(new IV(0,0,0,0,0,0), 50,10,10,10,10,10,10)){
				PokemonMovePool.AddAttack(new Attack.VineWhip());
				PokemonMovePool.AddAttack(new Attack.Tackle());
			}
		}
		public class Bulbasaur : Pokemon {
			public Bulbasaur()
				:base("Bulbasaur", new Stat(new IV(10, 10, 10, 10, 10, 5), 50, 10, 10, 10, 10, 10, 5)){
				PokemonMovePool.AddAttack(new Attack.VineWhip());
				Weakness.Add(Attack.Type.Fire);
			}
		}
		public class Charmander : Pokemon {
			public Charmander()
				:base("Charmander", new Stat(new IV(15, 10, 10, 10, 10, 10) ,70, 10, 10, 10, 10, 10, 10)){
				PokemonMovePool.AddAttack(new Attack.Ember());
				PokemonMovePool.AddAttack(new Attack.HighJumpKick());
			}
		}
		public class Zangoose : Pokemon {
			public Zangoose ()
				:base("Zangoose", new Stat(new IV(10,10,10,10,10,10), 50, 10,10,10,10,10,10)){
					PokemonMovePool.AddAttack(new Attack.Earthquake());
					Weakness.Add (Attack.Type.Fighting);
			}
		}
	}
}

