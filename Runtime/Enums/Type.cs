namespace Pixelakes.Wrath.Enums {
	public enum Type{
		None				= 0, //There are no cards with out a Type.
		Commander				= 1, //This is the Leader of your deck and one, only one is required to do battle.
		Wonder				= 2, //Each commander is allowed to bring one Wonder with them into battle if the choose.
		ActionCard				= 3, //Spells, Smells and other Trickery. Action cards give an immediate effect.
		Unit				= 4, //Warriors on the battle field, all units possess the power to achive victory.
   }
}