using System;
using pokemon_b;

namespace Hookin
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			//var x = new BattleField (new UserInterfaceNew());
			var r = new Cscui.Region();
			r.SetChild(new Cscui.Region());
			r.Split (Cscui.Orientation.Horizontal);
			r.Render ("Test Child");
			//r.Render ("Testing");
		}
	}
}