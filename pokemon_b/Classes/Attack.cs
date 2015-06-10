using System;

namespace pokemon_b
{
	public class Attack
	{
		public enum Type 
		{
			Normal,
			Fire,
			Grass
		};

		public Pokemon SourcePokemon;
		public int Damage;
		public Type AttackType;

		public Attack (Pokemon sourcePokemon, Type attackType, int damage)
		{
			this.SourcePokemon = sourcePokemon;
			this.AttackType = attackType;
			this.Damage = damage;
		}
	}
}

