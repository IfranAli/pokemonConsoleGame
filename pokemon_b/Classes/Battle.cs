using System;

namespace pokemon_b
{
	public class Battle
	{
		Trainer Red, Blue, LastMoved;
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

			// Determine first to move by pokemon speed.
			// If pokemon fainted earlier, determine first move by pokemon speed.
			Trainer trainer = null;
			Trainer trainer2 = null;
			while (true) {
				if (LastMoved == null || Red.OnField.isFainted() || Blue.OnField.isFainted()) {
					var status = String.Format ("\t{0}:{1}\t{2}:{3}",
						             Red.OnField.Name, Red.OnField.isFainted (),
						             Blue.OnField.Name, Blue.OnField.isFainted ());
					Console.Write ("\n\tChecking Who is faster.\n{0}\n", status);
					// Calculate first move by speed.
					if (Red.OnField.StatInfo._Speed > Blue.OnField.StatInfo._Speed) {
						trainer = Red;
						trainer2 = Blue;
					} else {
						trainer = Blue;
						trainer2 = trainerOne;
					}
				}

				LastMoved = trainer;
				if (turn (trainer, trainer2)) {
					trainer.trainerFontColour ();
					Console.Write ("{0} ");
					Console.ForegroundColor = ConsoleColor.White;
					Console.Write ("{0} Has Won!\n", trainer.TrainerName);
					break;
				}

				// No trainer should move twice in a row ( excluding some cases )
				if (LastMoved == Blue) {
					trainer = Red;
					trainer2 = Blue;
				} else {
					trainer = Blue;
					trainer2 = Red;
				}
			}
		}

		private Boolean turn(Trainer trainer, Trainer opponent) {
			try {
				TurnsPassed++;
				trainer.trainerFontColour();
				Console.WriteLine("\n{0} : Turn {1}\n{2}\n{3}",
					trainer.TrainerName, TurnsPassed, trainer.OnField.Name,
					trainer.OnField.GenHealthBar());
				Console.ForegroundColor = ConsoleColor.White;
				trainer.PerformTurn (opponent);
				return false;
			} catch (InvalidOperationException) {
				return true;
			} catch (Trainer.MyException) {
				Console.WriteLine ("pkmn fainted!");
				return false;
			}
		}
	}
}

