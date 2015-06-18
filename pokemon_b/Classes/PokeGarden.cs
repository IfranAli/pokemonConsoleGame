using System;

namespace pokemon_b
{
	public class PokeGarden
	{
		public PokeGarden ()
		{
			
		}
		public Pokemon Generate(String name, int level) {
			Pokemon gen = new Pokemon(name, GetRandomStat(level));
			gen.PokemonMovePool.AddAttack(new Attack.Earthquake());
			gen.PokemonMovePool.AddAttack(new Attack.HighJumpKick());
			//gen.Weakness.Add(Attack.Type.Fighting
			Console.WriteLine (gen.getInfo ());
			return gen;
		}

		Pokemon.Stat GetRandomStat(int level) {
			return new Pokemon.Stat (GetRandomIv (),
				level,
				GetRandomInt (60, 200),
				GetRandomInt (60, 200),
				GetRandomInt (60, 200),
				GetRandomInt (60, 200),
				GetRandomInt (60, 200),
				GetRandomInt (60, 200)
			);
		}

		Pokemon.IV GetRandomIv() {
			return new Pokemon.IV(
				GetRandomInt(0, 31),
				GetRandomInt(0, 31),
				GetRandomInt(0, 31),
				GetRandomInt(0, 31),
				GetRandomInt(0, 31),
				GetRandomInt(0, 31)
			);
		}

		Random r = new Random();
		public int GetRandomInt(int min, int max) {
			return r.Next(min, max);
		}


		/// <summary>
		/// Pokemon Classes from here on.
		/// </summary>
		public class Tirwig : Pokemon {
			public Tirwig() 
				:base("Tirwig", new Stat(new IV(0,0,0,0,0,0), 50,10,10,10,10,10,10)){
				PokemonMovePool.AddAttack(new Attack.VineWhip());
				PokemonMovePool.AddAttack(new Attack.Tackle());
				PokemonMovePool.AddAttack(new Attack.Peck());
				Weakness.Add(Attack.Type.Fire);
				Weakness.Add(Attack.Type.Flying);
			}
		}
		public class Bulbasaur : Pokemon {
			public Bulbasaur()
				:base("Bulbasaur", new Stat(new IV(10, 10, 10, 10, 10, 5), 50, 10, 10, 10, 10, 10, 5)){
				PokemonMovePool.AddAttack(new Attack.VineWhip());
				Weakness.Add(Attack.Type.Fire);
				Weakness.Add(Attack.Type.Flying);
			}
		}
		public class Charmander : Pokemon {
			public Charmander()
				:base("Charmander", new Stat(new IV(15, 10, 10, 10, 10, 10) ,70, 10, 10, 10, 10, 10, 10)){
				PokemonMovePool.AddAttack(new Attack.Ember());
				PokemonMovePool.AddAttack(new Attack.HighJumpKick());
				Weakness.Add(Attack.Type.Flying);
				Weakness.Add(Attack.Type.Water);
			}
		}
		public class Zangoose : Pokemon {
			public Zangoose ()
				:base("Zangoose", new Stat(new IV(10,10,10,10,10,10), 50, 10,10,10,10,10,10)){
				PokemonMovePool.AddAttack(new Attack.Earthquake());
				PokemonMovePool.AddAttack(new Attack.FireBlast());
				Weakness.Add (Attack.Type.Fighting);
			}
		}
	}
}

