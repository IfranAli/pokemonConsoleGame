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
		public String Name;

		public Attack (Type attackType, String attackName, int damage)
		{
			this.Name = attackName;
			this.AttackType = attackType;
			this.Damage = damage;
		}

		public Attack (Pokemon sourcePokemon, Type attackType, String attackName, int damage)
		{
			this.Name = attackName;
			this.SourcePokemon = sourcePokemon;
			this.AttackType = attackType;
			this.Damage = damage;
			this.SourcePokemon = sourcePokemon;
		}
	}
}

