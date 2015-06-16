using System;

namespace pokemon_b
{
	public class player : Trainer
	{
		public player (String playerName)
			:base(playerName) {

		}

		public override void PerformTurn(Trainer opponent) {
			Console.WriteLine ("Hey Hey Hey!!");
		}
	}
}

