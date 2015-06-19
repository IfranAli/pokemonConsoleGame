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

			Console.Clear();

			TrainerOne.trainerFontColour();
			Console.Write ("{0}", TrainerOne.TrainerName);
			Console.ForegroundColor = ConsoleColor.White;
			Console.Write(" and ");
			TrainerTwo.trainerFontColour();
			Console.Write("{0} ", TrainerTwo.TrainerName);
			Console.ForegroundColor = ConsoleColor.White;
			Console.Write("Entered a Battle!\n\n");

			TrainerOne.GetNextUsablePokemon ();
			trainerTwo.GetNextUsablePokemon ();

			// Determine first to move by pokemon speed.
			// If pokemon fainted earlier, determine first move by pokemon speed.
			while (true) {
				if (turn (TrainerOne, TrainerTwo)) {
					TrainerTwo.trainerFontColour();
					Console.Write("{0} ");
					Console.ForegroundColor = ConsoleColor.White;
					Console.Write("Has Won!\n", TrainerTwo.TrainerName);
					break;
				}
				if(turn (TrainerTwo, TrainerOne)) {
					TrainerOne.trainerFontColour();
					Console.Write("{0} ");
					Console.ForegroundColor = ConsoleColor.White;
					Console.Write("Has Won!\n", TrainerOne.TrainerName);
					break;
				}
			}

		}

		private Boolean turn(Trainer trainer, Trainer opponent) {
			try {
				TurnsPassed++;
				trainer.trainerFontColour();
				Console.WriteLine("\n{0} : Turn {1}\n--------------\n", trainer.TrainerName, TurnsPassed);
				Console.ForegroundColor = ConsoleColor.White;
				trainer.PerformTurn (opponent);
				return false;
			} catch (InvalidOperationException) {
				return true;
			}
		}
	}
}

