using System;

namespace pokemon_b
{
	public interface EventHook
	{
		void TurnPassed(int turns);

		void JoinedBattle(Trainer trainer);

		void PlayerPerformTurn (Trainer player, Trainer opponent);
	}
}

