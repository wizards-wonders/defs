namespace Pixelakes.Wrath.Enums {
	public enum Trigger{
		None				= 0, //No Trigger
		OnDeploy				= 1, //The moment when the Card is played
		StartOfTurn				= 2, //At the start of the player's turn before any other action has been taken
		DuringTurn				= 3, //Any time during the player's turn
		EndOfTurn				= 4, //At the end of the player's turn after all actions have been completed
		OutOfTurn				= 5, //Any time during the opponent's turn
		NextUnit				= 8, //When the opponent plays the first unit after this card was played
		Draw				= 11, //When a card is drawn from the deck durning a round
		Effect				= 12, //If the Trigger is on Effect, then use the TriggerEffect set
   }
}