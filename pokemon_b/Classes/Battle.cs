using System;

namespace pokemon_b
{
	public class Battle
	{
		Trainer Red, Blue;
		public int TurnsPassed;
		private EventHook mEventHook; 
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

		private void gameLoop() {
			while (PerformTurnSet () != true) {

			}
		}

		private Trainer GetFirstMoveTrainer(){
			Console.Write ("\nRed:{0}\tBlue:{1}\n", Red.OnField.StatInfo._Speed, Blue.OnField.StatInfo._Speed);
			if (Red.OnField.StatInfo._Speed > Blue.OnField.StatInfo._Speed) {
				// Red is faster.
				return Red;
			} else {
				// Blue is faster.
				return Blue;
			}
		}


		private Boolean PerformTurnSet() {
			//Console.Clear ();
			TurnsPassed++;
			var x = GetFirstMoveTrainer ();
			var y = (x.TrainerName.Equals(Red.TrainerName)) ? Blue : Red;
			return (turn (x, y) | turn (y, x));
		}

		private Boolean turn(Trainer trainer, Trainer opponent) {
			try {
				Console.WriteLine("\n{0} : Turn {1}\n{2}\n{3}",
					trainer.TrainerName, TurnsPassed, trainer.OnField.Name,
					trainer.OnField.GenHealthBar());
				trainer.PerformTurn (opponent);
				handleFainting();
				return false;
			} catch (InvalidOperationException) {
				Console.Write ("{0} Has Won!\n", trainer.TrainerName);
				return true;
			}
		}

		void handleFainting() {
			if (Red.OnField.isFainted ()) {
				Red.GetNextUsablePokemon ();
			}
			if (Blue.OnField.isFainted ()) {
				Red.GetNextUsablePokemon ();
			}
		}
	}
}

