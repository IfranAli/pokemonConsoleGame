using System;
using System.Linq;
using System.Collections.Generic;

namespace pokemon_b
{
	public class Trainer
	{
		public EventHook mEventHook;
		public Pokemon OnField;
		public List<Pokemon> Pokemons;
		public String TrainerName;
		public Trainer (EventHook eventHook, String trainerName)
		{
			mEventHook = eventHook;
			Pokemons = new List<Pokemon> ();
			TrainerName = trainerName;
		}

		public void AddPokemon(Pokemon pokemon){
			pokemon.mEventHook = mEventHook;
			Pokemons.Add (pokemon);
		}
			
		virtual public Pokemon GetNextUsablePokemon() {
			Pokemon x;
			try {
				IEnumerable<Pokemon> notFaintedPokemon = Pokemons.FindAll(p => p.isFainted() == false);
				x = Pokemons.First (p => !p.isFainted());
				OnField = x;
			} catch (NullReferenceException) {
				//mEventHook.HasMessage( String.Format ("{0} is out of usable pokemon.", TrainerName));
				throw new InvalidOperationException ();
			}
			//mEventHook.HasMessage (String.Format("{0} sent out: {1}", TrainerName, OnField.GetName()));
			return x;
		}

		virtual public TurnType PerformTurn(Trainer opponent) {
			// Trainer Bot logic.
			var highestDMG = OnField.PokemonMovePool.getHighestDamage ();
			var enemyweakness = OnField.PokemonMovePool.getEnemyWeakestTo (opponent.OnField);

			if (enemyweakness != null) {
				if ((enemyweakness.Damage * 2.0) > highestDMG.Damage) {
					return OnField.PerformAttack (new AttackTurn(OnField, opponent.OnField, enemyweakness));
				}
			}
			return OnField.PerformAttack (new AttackTurn(OnField, opponent.OnField, highestDMG));
		}
	}

	public interface TurnType {
		void PerformTurn();
		String GetDescription();
	}

	public class PlayerJoiedTurn : TurnType {
		Trainer mPlayer;
		public PlayerJoiedTurn(Trainer player) {
			mPlayer = player;
		}
			
		#region TurnType implementation
		public void PerformTurn ()
		{
			throw new NotImplementedException ();
		}
		public string GetDescription ()
		{
			String result = String.Format("{0} has entered the battle!\n", mPlayer.TrainerName);
			foreach (Pokemon p in mPlayer.Pokemons) {
				result += String.Format ("{0} Lv.{1}\n", p.GetName(), p.StatInfo.Level);
			}

			return result;
		}	
		#endregion
	}

	public class WinTurn : TurnType {

		Trainer trainer;
		public WinTurn(Trainer t) {
			trainer = t;
		}
		#region TurnType implementation

		public void PerformTurn ()
		{
			throw new NotImplementedException ();
		}

		public string GetDescription ()
		{
			return String.Format("Trainer: {0} Has Won!", trainer.TrainerName);
		}

		#endregion
	}

	public class RequestUserInput : TurnType {
		#region TurnType implementation

		public void PerformTurn ()
		{
			throw new NotImplementedException ();
		}

		public string GetDescription ()
		{
			return "Requesting user input";
		}

		#endregion
	}

	public class AttackTurn : TurnType {

		public class AttackResult {
			public double effectiveness;
			public int damageDelt;
			public AttackResult() {

			}
		}

		Attack attack;
		Pokemon target;
		Pokemon attacker;
		public AttackResult attackResult;

		public AttackTurn(Pokemon origin, Pokemon target, Attack attack) {
			this.attack = attack;
			this.target = target;
			this.attacker = origin;
		}

		public Attack GetAttack() {
			return attack;
		}
		public Pokemon GetTargetPokemon() {
			return target;
		}
		public Pokemon GetAttacker() {
			return attacker;
		}
		#region TurnType implementation
		public void PerformTurn ()
		{
			attackResult = target.TakeDamage (attack);
			attack.ApplyEffect (target);
		}
		public String GetDescription ()
		{
			String x;
			if (attackResult != null) {
				x = String.Format ("{0} Used {1} on {2}\n", attacker.GetName (), attack.Name, target.GetName ());
					x += String.Format ("{0}'s {1} was {2}x Effective!\n" +
						"Dealing {3} in damage!", attacker.GetName(), attack.Name, attackResult.effectiveness, attackResult.damageDelt);
			} else {
				x = String.Format ("{0} Used {1} on {2}\n", attacker.GetName (), attack.Name, target.GetName ());
			}
			return x;
		}
		#endregion
	}

	public class SwitchPokemonRequest : TurnType {
		Trainer mTrainer;
		Pokemon mPokemon;

		public SwitchPokemonRequest (Trainer trainer, Pokemon pokemon){
			mTrainer = trainer;
			mPokemon = pokemon;
		}
		#region TurnType implementation
		public void PerformTurn ()
		{
			throw new NotImplementedException ();
		}

		public string GetDescription ()
		{
			return "User Switch Pokemon";
		}

		#endregion
	}

	public class HasSwitched : TurnType {
		Pokemon mPokemon;
		Trainer mTrainer;
		public HasSwitched(Trainer trainer, Pokemon pokemon) {
			mTrainer = trainer;
			mPokemon = pokemon;
		}
		#region TurnType implementation
		public void PerformTurn ()
		{
			throw new NotImplementedException ();
		}

		public string GetDescription () {
			var text = String.Format ("{0} Switched into {1}!\n", mTrainer.TrainerName, mPokemon.GetName());
			text += mPokemon.getInfo ();
			return text;

		}
		#endregion
	}
}