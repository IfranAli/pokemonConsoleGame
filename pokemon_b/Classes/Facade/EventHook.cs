using System;

namespace pokemon_b
{
	public interface EventHook
	{
		void TurnPassed(int turns);

		void JoinedBattle(Trainer trainer);

		TurnType PlayerPerformTurn (Trainer player, Trainer opponent);

		// Pre-Turn
		void OnPerformTurn(int turnsPassed, Trainer player, Trainer opponent);

		// Post-Battle
		void HasWon(Trainer trainer);

		void HasMessage(String message);
	}
}