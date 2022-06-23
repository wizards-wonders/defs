namespace Pixelakes.Wrath.Enums {
	public enum Trigger{
		None				= 0, //No Trigger
		OnDeploy				= 1, //The moment when the Card is played
		StartOfTurn				= 2, //At the start of the player's turn before any other action has been taken
		DuringTurn				= 3, //Any time during the player's turn
		EndOfTurn				= 4, //At the end of the player's turn after all actions have been completed
		Event				= 5, //for custom events, TODO: add event types
		OutOfTurn				= 6, //Any time during the opponent's turn
		OnDestroy				= 7, //When the card has been destroyed
		NextUnit				= 8, //?
		OnDamaged				= 9, //When the card has been damaged
		OnHealed				= 10, //When the card has been damaged
		Drawn				= 11, //?
   }
}