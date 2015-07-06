using System;
using System.Linq;

namespace pokemon_b
{
	public class Player : Trainer
	{
		public Player (EventHook eventHook, String playerName)
			:base(eventHook, playerName) {
		}

		public int pokemonIndex = 0;

		public void SetPokemon(int pokemonIndex) {
			Pokemon result = Pokemons [pokemonIndex];
			if (result != null) {
				this.pokemonIndex = pokemonIndex;
				//OnField = result;
			}
		}

		public Boolean HasPokemon() {
			int count = Pokemons.FindAll (p => !p.isFainted ()).Count;
			return count > 1;
		}

		public override Pokemon GetNextUsablePokemon() {
			Pokemon x;
			try {
				//x = Pokemons.First (p => !p.isFainted());
				//OnField = x;
				x = Pokemons[pokemonIndex];
				OnField = x;
			} catch (NullReferenceException) {
				//mEventHook.HasMessage( String.Format ("{0} is out of usable pokemon.", TrainerName));
				throw new InvalidOperationException ();
			}

			//mEventHook.HasMessage (String.Format("{0} sent out: {1}", TrainerName, OnField.GetName()));
			if (x == null) {
				var p = "";
			}
			return x;
		}

		public override TurnType PerformTurn(Trainer opponent) {
			return mEventHook.PlayerPerformTurn (this, opponent);
//			if (OnField.isFainted ()) {
//				try {
//					GetNextUsablePokemon ();
//				} catch (InvalidOperationException ex) {
//					throw ex;
//				}
//				var s = new SwitchPokemonRequest (this, OnField);
//				return s;
//			} else {
//				return mEventHook.PlayerPerformTurn (this, opponent);
//			}
		}
	}
}

