﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace pokemon_b
{
	public class MovePool
	{
		public Pokemon pokemon;
		public List<Attack> Attacks;

		public MovePool (Pokemon p)
		{
			this.pokemon = p;
			this.Attacks = new List<Attack> ();
			Attacks.Add (new Attack (p, Attack.Type.Normal, "Struggle" ,20));
		}

		public void RemoveMove(Attack a) {
			Attacks.Remove(a);
		}

		public void AddAttack(Attack a) {
			a.SourcePokemon = pokemon;
			this.Attacks.Add (a);
		}
		public Attack GetAttack() {
			var a = getHighestDamage();
			if (a == null) {
				a = Attacks.FirstOrDefault ();
			}
			return a;
		}

		public Attack getHighestDamage() {
			return Attacks.Aggregate ((b1, b2) => b2.Damage > b1.Damage ? b2 : b1);
		}

		public Attack getEnemyWeakestTo(Pokemon p) {
			var weaknesses = p.Weakness;
			var allAttacks = Attacks.FindAll (e => e.Damage > 0);

			var xy = allAttacks.FindAll (e => weaknesses.Contains (e.AttackType));

			var highestDMG = allAttacks.Aggregate ((b1, b2) => b2.Damage > b1.Damage ? b2 : b1);
			if (xy != null) {
				return xy.FirstOrDefault();
			}
			return highestDMG;
		}
	}
}

