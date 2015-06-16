using System;

namespace pokemon_b
{
	public interface HasBattleEffect {
		void ApplyEffect(Pokemon p);
	}

	public class Attack : HasBattleEffect
	{
		public enum Type 
		{
			Normal,
			Fire,
			Grass,
			Fighting,
			Water,
			Ground,
			Rock,
			Ghost,
			Flying
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

		#region HasBattleEffect implementation

		public virtual void ApplyEffect (Pokemon p)
		{
			//throw new NotImplementedException ();
		}

		#endregion

		public class Ember : Attack {
			public Ember() : base(Attack.Type.Fire, "Ember", 30){}
			public override void ApplyEffect (Pokemon p)
			{
				p.SetCondition (Pokemon.Condition.Burned);
				//base.ApplyEffect (p);
			}
		}
		public class FireBlast : Attack {
			public FireBlast() :base(Attack.Type.Fire, "Fire Blast", 90) {}
		}
		public class VineWhip : Attack {
			public VineWhip() : base(Attack.Type.Grass, "Vine Whip", 35) {}
		}
		public class Earthquake : Attack {
			public Earthquake() : base(Attack.Type.Ground, "Earthquake", 100) {}
		}
		public class HighJumpKick : Attack {
			public HighJumpKick() : base(Attack.Type.Fighting, "High Jump Kick", 120) {}
			public override void ApplyEffect ( Pokemon p ) {
				SourcePokemon.TakeRecoilDamage (this, 10);
			}
		}
		public class Tackle : Attack {
			public Tackle() : base(Type.Normal, "Tackle", 20) {}
		}
		public class Peck : Attack {
			public Peck() : base(Type.Flying, "Peck", 30) {}
		}
	}
}

