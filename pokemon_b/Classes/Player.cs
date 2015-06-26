using System;

namespace pokemon_b
{
	public class Player : Trainer
	{
		public Player (EventHook eventHook, String playerName)
			:base(eventHook, playerName) {
		}

		public override void PerformTurn(Trainer opponent) {
			if (OnField.isFainted ()) {
				try {
					GetNextUsablePokemon ();
				} catch (InvalidOperationException ex) {
					throw ex;
				}
			} else {
				textGui (this, opponent);
				//OnField.Pe rformAttack (opponent.OnField);
			}
		}

		void textGui(Trainer player, Trainer opponent) {
			mEventHook.PlayerPerformTurn (player, opponent);
		}
	}
}

