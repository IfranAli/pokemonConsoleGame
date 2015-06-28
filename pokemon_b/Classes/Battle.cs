using System;

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

			gameLoop ();
		}

		void gameLoop() {
			while (!PerformTurnSet ()) {
			}
		}

		Trainer GetFirstMoveTrainer(){
			//Console.Write ("\nRed:{0}\tBlue:{1}\n", Red.OnField.StatInfo._Speed, Blue.OnField.StatInfo._Speed);
			if (Red.OnField.StatInfo._Speed > Blue.OnField.StatInfo._Speed) {
				// Red is faster.
				return Red;
			} else {
				// Blue is faster.
				return Blue;
			}
		}
			
		Boolean PerformTurnSet() {
			//Console.Clear ();
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
	}
}

