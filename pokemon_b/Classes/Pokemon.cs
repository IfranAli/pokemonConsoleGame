using System;
using System.Collections.Generic;

namespace pokemon_b
{
	public class Pokemon
	{
		public String Name;
		public Stat StatInfo;
		public int Health;
		public List<Attack.Type> Weakness;

		public bool isFainted() {
			return Health < 1;
		}

		// For now pokemon only have one move.
		//public Attack AttackMove;

		public MovePool PokemonMovePool;

		public Pokemon (String name, Stat stat)
		{
			Name = name;
			StatInfo = stat;
			Health = stat._Health;
			this.PokemonMovePool = new MovePool(this);
			this.Weakness = new List<Attack.Type> ();
		}

		public void PerformAttack(Pokemon p){
			Attack attack = this.PokemonMovePool.GetAttack ();
			Console.WriteLine ("{0} Used {2} on {1}!", Name, p.Name, attack.Name);
			p.TakeDamage (attack);
		}

		public double getDamageMultiplier(Attack.Type type) {
			if (Weakness == null)
				return 1.0;
			if(Weakness.Contains(type)) {
				Console.WriteLine("Super Effective! x2 Damage");
				return 2.0;
			}
			return 1.0;
		}
			
		public void TakeDamage(Attack attack) {
			double multiplier = getDamageMultiplier (attack.AttackType);
			int dmg = (int) (attack.Damage * multiplier);
			this.Health -= dmg;
			Console.WriteLine ("{0} took {1} Damage! HP: %{2}", Name, dmg, CalculateHealth());
			if (isFainted()) {
				Console.WriteLine ("{0} Fainted!", Name);
			}
		}

		public int CalculateHealth() {
			return Convert.ToInt32(((double)this.Health / StatInfo._Health) * 100);
		}

		public String getInfo() {
			return String.Format ("Name:\t{7}\nLevel:\t{0}\nHP:\t{1}\nDEF:\t{2}\n" +
				"SP_DEF:\t{3}\nATT:\t{4}\nSP_ATT:\t{5}\nSPD:\t{6}\n", StatInfo.Level, StatInfo._Health, 
				StatInfo._Defence, StatInfo._SpDefence, StatInfo._Attack, StatInfo._SpAttack, StatInfo._Speed, Name);
		}

		public class Stat {
			public IV IV;
			public double STAT_SCALE = 0.5;
			public int Level;
			public int _Health;
			public int _SpDefence;
			public int _Defence;
			public int _SpAttack;
			public int _Attack;
			public int _Speed;

			public Stat (IV iv,int level, int hp, int def, int spDef, int att, int spAtt, int speed)
			{
				IV = iv;
				_Health = hp;
				_Defence = def;
				_SpDefence = spDef;
				_SpAttack = spAtt;
				_Attack = att;
				_Speed = speed;

				SetLevel(level);
			}

			public void SetLevel(int level) {
				//Stat = ((Base * 2 + IV + (EV/4)) * Level / 100 + 5) * Nmod
				var ev	= 20;
				Level	= level;

				_Health	=			  ((_Health 	* 2 + IV._HP 	 + (ev / 4)) * Level / 100 + 10 + Level);
				_SpDefence = 	(int) (((_SpDefence * 2 + IV._SpDef + (ev / 4)) * Level / 100 + 5) * 1.0);
				_Defence = 		(int) (((_Defence	* 2 + IV._Def	 + (ev / 4)) * Level / 100 + 5) * 1.0);
				_SpAttack =		(int) (((_SpAttack	* 2 + IV._SpAtt + (ev / 4)) * Level / 100 + 5) * 1.0);
				_Attack =	    (int) (((_Attack	* 2 + IV._Att	 + (ev / 4)) * Level / 100 + 5) * 1.0);
				_Speed =		(int) (((_Speed		* 2 + IV._Speed + (ev / 4)) * Level / 100 + 5) * 1.0);
			}
		}

		public class IV {
			public int _HP, _Def, _SpDef, _SpAtt, _Att, _Speed;

			public IV(int hp, int def, int spDef, int att, int spAtt, int speed){
				_HP = hp;
				_Def = def;
				_SpDef = spDef;
				_Att = att;
				_SpAtt = att;
				_Speed = speed;
			}
		}
	}
}

