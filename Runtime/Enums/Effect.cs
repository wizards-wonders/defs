namespace Pixelakes.Wrath.Enums {
	public enum Effect{
		None				= 0, //No Effect
		Heal				= 100, //Give Power Points to card
		Immune				= 101, //Cannot be damaged or targetted
		Resurrect				= 102, //Move card back to (hand or deck) from graveyard
		Reincarnation				= 103, //Come back to life on death with init state
		Damage				= 200, //Take Power Points from a card
		Destroy				= 201, //Send card to the graveyard
		Retaliate				= 202, //Damages the attacker by the same amount, if the attacker is not a unit, player may select the target
		Clone				= 300, //Copies card in play and depolys it immediately skipping OnDeploy triggers
		Spawn				= 301, //spwans weak generic card
		Summon				= 302, //Deploys all cards in hand matching the calling card
		Lock				= 400, //Renders card usless and removes its points from the count
		Unlock				= 401, //Removes the lock on a locked card
		Teleport				= 402, //Moves card to a new row
		Protection				= 403, //Bubble protection absorbs next damage
		Silence				= 404, //Removes any status effects
		Reveal				= 500, //Shows Card to other player
		Shuffle				= 501, //Shuffle the deck
		Draw				= 502, //Draw additional card
		Return				= 503, //Returns unit to players hand and resets- buffs reset but could use deploy action
		Boost				= 600, //Gives Power points to card
		Stealth				= 601, //Cannot be targetted
		Consume				= 700, //Consumes power from other cards destroying them
		Absorb				= 701, //Absorbs damage on other cards up current power destroying self
		Displace				= 702, //Destributes its power as damage to foes or power to friends and destroys self
   }
}