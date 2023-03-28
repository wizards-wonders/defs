namespace Pixelakes.Wrath.Enums {
	public enum Target{
		None				= 0, //No Target
		Battlefield				= 100, //Card(s) in play on the battlefield
		CardOnLeft				= 101, //Card to left of card
		CardOnRight				= 102, //Card to Right of card
		Neighbors				= 103, //Cards on both sides of card
		Row				= 104, //Row in Battlefield
		OpposingRow				= 105, //Opponent's row matching card's row
		Strongest				= 200, //Strongest Card
		Weakest				= 201, //Weakest Card
		Effect				= 203, //Targets Cards With (x)Effect Applied
		SubType				= 203, //Targets a Subtype
		All				= 204, //All card(s) in target
		Random				= 205, //Random card in Target
		Card				= 206, //Player Selects Card
		Hand				= 300, //Card(s) in a player's hand
		Deck				= 400, //Card(s) in a player's deck
		Commander				= 500, //The Commnader card
		Wonder				= 501, //The Wonder Card
   }
}