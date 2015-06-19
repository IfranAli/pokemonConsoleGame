Battle Interaction
==================


Functions
=============
Pokemon.Attack(Pokemon pokemon);
Pokemon.Use(Item item);
Pokemon.Defend(); Like Focus ( Still affected by special moves )

Moves
=====
Pokemon has moves collection.

Types
-----
Move -> Self
Move -> Attack
Move -> Environment

*Self* Includes healing and buff moves.
*Attack* Includes damage dealing moves.
*Environment* Includes moves that change the battle environment.

Class Structure
---------------
Pokemon has access to it's stats/ivs and movepool.

Attack should contain an Apply(Pokemon p) function that takes the target pokemon
as a paramterer therefor move effects can be applied to the pokemon.
Special attacks should take in a Field Object ( Not yet created ).

Field Object
------------
Contains variables relating to the battle environment. E.g
* Weather ( Pokemon recieve weather bonuses ).
	* Additional Weather effects can be set in "Special" E.g
	* Acid Rain (non-poison types get poisoned).
	* Fog ( Both pokemon recieve bonus on dogeing attacks ) 
* Random Weather related events . E.g
	* Rock Slides.
	* Avalanches.
	* SandStorms.
	* Drought/Drizzle.
	* Arceus's Blessing. ( Huge buff to stats for a single turn )
	 
* Terrain Type ( Some pokemon can recieve Terrain bonuses, Ground types on Water terrain recieve negative bonuses ).
	* Sea
	* Ground
	* Forrest
	* Urban
	* Cave
	* Sky
	* Ruin
