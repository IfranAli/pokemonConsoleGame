using System;
using System.Collections.Generic;

namespace pokemon_b
{
	public class Battle
	{
		Trainer Red, Blue;
		public int TurnsPassed;
		EventHook mEventHook; 

		public Battle (EventHook eventHook, Trainer trainerOne, Trainer trainerTwo)
		{
			mEventHook = eventHook;

			Red = trainerOne;
			Blue = trainerTwo;

			mEventHook.JoinedBattle (Red);
			mEventHook.JoinedBattle (Blue);

			Red.GetNextUsablePokemon ();
			trainerTwo.GetNextUsablePokemon ();
		}

		public Boolean Continue() {
			return PerformTurnSet ();
		}

		Trainer GetFirstMoveTrainer(){
			var x = String.Format ("\nRed:{0}\tBlue:{1}\n", Red.OnField.StatInfo._Speed, Blue.OnField.StatInfo._Speed);
			mEventHook.HasMessage (x);
			if (Red.OnField.StatInfo._Speed > Blue.OnField.StatInfo._Speed) {
				// Red is faster.
				return Red;
			} else {
				// Blue is faster.
				return Blue;
			}
		}
			
		Boolean PerformTurnSet() {
			TurnsPassed++;
			var x = GetFirstMoveTrainer ();
			var y = (x.TrainerName.Equals(Red.TrainerName)) ? Blue : Red;

			return turn (x, y) || turn (y, x);
		}

		Boolean turn(Trainer trainer, Trainer opponent) {
			try {
				mEventHook.OnPerformTurn(TurnsPassed, trainer, opponent);
				trainer.PerformTurn (opponent);
				handleFainting();
				return false;
			} catch (InvalidOperationException) {
				mEventHook.HasWon (trainer);
				return true;
			}
		}

		void handleFainting() {
			if (Red.OnField.isFainted ()) {
				Red.GetNextUsablePokemon ();
			}
			if (Blue.OnField.isFainted ()) {
				Blue.GetNextUsablePokemon ();
			}
		}

		private List<String> TurnLog;
		public List<String> GetTurnLog() {
			TurnLog = new List<String> ();
			TurnLog.Add ("FIRST");
			TurnLog.Add ("Second");
			TurnLog.Add ("THIRD");
			return TurnLog;
		}
	}
}

