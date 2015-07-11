using System;

namespace pokemon_b
{
	public interface IPokemon
	{
		String GetName();
        String _Name { get; }
	}
}