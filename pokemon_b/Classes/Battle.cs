using System;

namespace pokemon_b
{
	public class Battle
	{
		Trainer TrainerOne, TrainerTwo;
		public int TurnsPassed;

		public Battle (Trainer trainerOne, Trainer trainerTwo)
		{
			TrainerOne = trainerOne;
			TrainerTwo = trainerTwo;
			Console.WriteLine ("{0} and {1} Entered a Battle!", TrainerOne.TrainerName, TrainerTwo.TrainerName);

			TrainerOne.GetNextUsablePokemon ();
			trainerTwo.GetNextUsablePokemon ();

			// Determine first to move by pokemon speed.
			// If pokemon fainted earlier, determine first move by pokemon speed.
			while (true) {
				if (turn (TrainerOne, TrainerTwo)) {
					Console.WriteLine ("{0} Has Won!", TrainerTwo.TrainerName);
					break;
				}
				if(turn (TrainerTwo, TrainerOne)) {
					Console.WriteLine ("{0} Has Won!", TrainerOne.TrainerName);
					break;
				}
			}

		}

		private Boolean turn(Trainer trainer, Trainer opponent) {
			try {
				TurnsPassed++;
				Console.WriteLine("\n{0} Turn {1}\n", trainer.TrainerName, TurnsPassed);
				trainer.PerformTurn (opponent);
				return false;
			} catch (InvalidOperationException) {
				return true;
			}
		}
	}
}

