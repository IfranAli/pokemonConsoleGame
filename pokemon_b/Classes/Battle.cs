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
			Trainer trainer = null;
			Trainer trainer2 = null;
			while (true) {
				if(TurnsPassed == 0) {
					// Calculate fitst move by speed.
					if (TrainerOne.OnField.StatInfo._Speed > TrainerTwo.OnField.StatInfo._Speed) {
						trainer = TrainerOne;
						trainer2 = TrainerTwo;
					} else {
						trainer = TrainerTwo;
						trainer2 = trainerOne;
					}
				}
					
				if (turn (trainer, trainer2)) {
					trainer.trainerFontColour ();
					Console.Write ("{0} ");
					Console.ForegroundColor = ConsoleColor.White;
					Console.Write ("Has Won!\n", trainer.TrainerName);
					break;
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

