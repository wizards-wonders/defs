namespace Pixelakes.Wrath.Enums {
	public enum Trigger{
		None				= 0, //No Trigger
		OnDeploy				= 1, //The moment when the Card is played
		StartOfTurn				= 2, //At the start of the player's turn before any other action has been taken
		DuringTurn				= 3, //Any time during the player's turn
		EndOfTurn				= 4, //At the end of the player's turn after all actions have been completed
		OutOfTurn				= 5, //Any time during the opponent's turn
		OnDestroy				= 6, //When the card has been destroyed
		OnDestroyFriendly				= 7, //When any other of the player's cards has been destroyed
		NextUnit				= 8, //When the opponent plays the first unit after this card was played
		OnDamaged				= 9, //When the card has been damaged
		OnHealed				= 10, //When the card has been damaged
		Draw				= 11, //When a card is drawn from the deck durning a round
   }
}