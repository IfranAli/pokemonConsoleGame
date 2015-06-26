using System;
using pokemon_b;

namespace Hookin
{
	public class UserInterface : EventHook
	{
		public UserInterface ()
		{
			
		}

		#region EventHook implementation

		public void TurnPassed (int turns) {
			Console.WriteLine ("Turn {0}", turns);
		}
			
		#endregion
	}
}

