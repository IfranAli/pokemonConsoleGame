using System;
using pokemon_b;
using System.Collections.Generic;

namespace Hookin
{
	class MainClass
	{
		public static BattleField battleField;
		public static void Main (string[] args)
		{
			UserInterface ui = new UserInterface ();
			battleField = new BattleField (ui);

			// Game Booleans
			Boolean userInput = false;
			Boolean exitGame = false;
			Boolean switchPokemon = false;


			Console.WriteLine ("Pokemon Battle Simulator.");

			while (!exitGame) {
				Console.WriteLine("press 'a 'to continue.");
				var y = Console.ReadKey ();
				if (y.KeyChar == 'a') {
					Console.Clear ();
					if (switchPokemon) {
						SwitchPokemon();
					}
					if (userInput) {
						ui.move = PickMoveBeforeTurn (switchPokemon);
						userInput = false;
						switchPokemon = false;
					}

					var turnResults = battleField.ContinueBattle ();
					if (turnResults != null) {
						foreach (TurnType t in turnResults) {
							//Console.WriteLine ();
							if (t.GetType () == typeof(AttackTurn)) {
								Console.WriteLine (t.GetDescription ());
							} else if (t.GetType () == typeof(WinTurn)) {
								Console.WriteLine (t.GetDescription ());
								exitGame = true;
							} else if (t.GetType () == typeof(RequestUserInput)) {
								userInput = true;
							} else if (t.GetType () == typeof(SwitchPokemonRequest)) {
								Console.WriteLine (t.GetDescription ());
								switchPokemon = true;
							} else if (t.GetType () == typeof(HasSwitched)) {
								Console.WriteLine (t.GetDescription ());
							} else if (t.GetType () == typeof(PlayerJoiedTurn)) {
								Console.WriteLine (t.GetDescription ());
							}
						}
					}

					PrintBattleStatus ();
				} else {
					break;
				}
			}
		}

		public static void SwitchPokemon() {
			Player player = (Player)battleField.GetPlayer ();
			Console.Write("Id\tPokemon\t\tHealth\n");
			foreach( Pokemon p in player.Pokemons) {
				Console.Write("{0}\t{1}\t\t{2}\n", player.Pokemons.IndexOf(p), p.GetName(), p.Health);
			}
			int input = int.Parse (Console.ReadLine ());
			player.SetPokemon(input);
		}

		public static int PickMoveBeforeTurn(Boolean hasSwitched) {
			List<Attack> attacks;
			if (hasSwitched) {
				attacks = battleField.GetPlayer ().Pokemons[battleField.GetPlayer().pokemonIndex].PokemonMovePool.Attacks;
			} else {
				attacks = battleField.GetPlayer ().OnField.PokemonMovePool.Attacks;
			}

			Console.WriteLine("NUM\tNAME\t\tDMG\tTYPE");
			foreach (Attack a in attacks) {
				Console.WriteLine ("{0}\t{1}\t{2}\t{3}", attacks.IndexOf(a), a.Name,
					a.Damage, a.AttackType);
			}
			Console.Write("Select Move: ");

			string input = Console.ReadLine ();
			int move = int.Parse (input);
			return move;
		}

		public static void PrintBattleStatus() {
			var redHealth = battleField.Red.OnField; 
			var blueHealth = battleField.Blue.OnField; 
			Console.Write ("\n{0} {1}\n{2} {3}\n", redHealth.GenHealthBar(), redHealth.GetName() ,
				blueHealth.GenHealthBar(), blueHealth.GetName());
			Console.WriteLine ("Turn: {0}", battleField.GetTurnsPassed());
		}
	}
}