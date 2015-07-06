using System;
using System.Collections.Generic;

namespace pokemon_b
{
	public class Battle
	{
		Trainer Red, Blue;
		public int TurnsPassed = 1;
		EventHook mEventHook; 
		List<TurnType> actions;

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

		public List<TurnType> Continue() {
			return  PerformTurn();
		}

		List<Trainer> GetFirstMoveTrainer(){
			var x = String.Format ("\nRed:{0}\tBlue:{1}\n", Red.OnField.StatInfo._Speed, Blue.OnField.StatInfo._Speed);
			mEventHook.HasMessage (x);
			if (Red.OnField.StatInfo._Speed > Blue.OnField.StatInfo._Speed) {
				// Red is faster.
				return new List<Trainer>(){ Red, Blue };
			} else {
				// Blue is faster.
				return new List<Trainer>(){ Blue, Red };
			}
		}

		Trainer lastMoved;
		List<TurnType> PerformTurn() {
			actions = new List<TurnType> ();
			if (TurnsPassed == 1) {
				// Player Introduction.
				actions.Add (new PlayerJoiedTurn(Red));
				actions.Add (new PlayerJoiedTurn (Blue));
			}
			TurnsPassed++;
			if (lastMoved == null) {
				// First Turn.
				var x = GetFirstMoveTrainer();
				lastMoved = x[0];
				actions.Add( turn (x [0], x [1]));
			} else {
				// Second Turn.
				var x = GetFirstMoveTrainer();
				if (x [0] == lastMoved) {
					lastMoved = x [1];
					actions.Add (turn (x [1], x [0]));
				} else {
					lastMoved = x [0];
					actions.Add( turn (x [0], x [1]));
				}
			}
				
			if(lastMoved.TrainerName.Equals("Blue")) {
				actions.Add(new RequestUserInput());
			}

			Pokemon p = null;

			if (Blue.OnField.isFainted()) {
				try {
					p = Blue.GetNextUsablePokemon();
				} catch (InvalidOperationException) {
					actions.Add( new WinTurn(Red));
				}
			}
			p = null;
			if (Red.OnField.isFainted()) {
				try {
					p = Red.GetNextUsablePokemon();
				} catch (InvalidOperationException) {
					actions.Add (new WinTurn (Blue));
				}
			}

			return actions;
		}

		TurnType turn(Trainer trainer, Trainer opponent) {
			TurnType x = null;
			try {
				// Make sure trainers have switched pokemon 
				// if their pokemon last turn had fainted.
				if(trainer.OnField.isFainted()) {
					var t = trainer.GetNextUsablePokemon();
					trainer.OnField = t;
					actions.Add(new HasSwitched(trainer, t));
				}

				x = trainer.PerformTurn (opponent);
				handleFainting();
			} catch (InvalidOperationException e) {
				//mEventHook.HasWon (trainer);
				//actions.Add(new WinTurn(trainer));
			}
			return x;
		}

		void handleFainting() {
			if (Red.OnField.isFainted ()) {
				if (Red.GetType () == typeof(Player)) {
					if (((Player)Red).HasPokemon ()) {
						var switchPokemon = new SwitchPokemonRequest (Red, Red.OnField);
						actions.Add (switchPokemon);
					} else {
						Red.GetNextUsablePokemon ();
						var switchedInto = new HasSwitched (Red, Red.OnField);
						actions.Add (switchedInto);
					}
				}
			}
		}

		public List<TurnType> GetTurnLog() {
			return actions;
		}

		public int GetTurnsPassed() {
			return TurnsPassed;
		}
	}
}
