namespace Pixelakes.Wrath.Enums {
	public enum Target{
		None				= 0, //No Target
		BattleField				= 100, //Card(s) in play on the battle field
		CardOnLeft				= 101, //Card to left of card
		CardOnRight				= 102, //Card to Right of card
		Neighbors				= 103, //Cards on both sides of card
		Row				= 104, //Cards in a row
		OpposingRow				= 105, //Opponent's matching row
		Strongest				= 200, //Strongest unit card
		Weakest				= 201, //Weakest unit card
		SubType				= 202, //Targets a SubType
		Effect				= 203, //Targets Cards With (x)Effect Applied
		All				= 204, //All Cards in Target
		Random				= 205, //Random Card in Target
		Hand				= 300, //Cards in a player's hand
		Deck				= 400, //Remaining Cards in a player's Deck
		Commander				= 500, //Commnader Card
		Wonder				= 501, //Wonder Card
   }
}