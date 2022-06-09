namespace Pixelakes.Wrath.Enums {

    //currently abilities and modifiers should probalby use targetTypes, but anything that wants to target something should use these
    public enum Target{
        None                = 0,
        Player              = 1, // Player would not be the card but something on the player 
        Opponent            = 2, // Opponent would not be a card but somthing on the oppent
        AllPlayers          = 3,
        RandomPlayer        = 4, // chooses the play at random
        ThisCard            = 5, // The card using the ability
        PlayerCard          = 6, // any player card in play
        OpponentCard        = 7, // any Opponent card in play
        RandomPlayerCard    = 8, // random player card in play
        RandomOpponentCard  = 9, // random Opponent card in play
        RandomCard          = 10, // random card in play
        AllPlayerCards      = 11, // all of the player cards in play
        AllOpponentCards    = 12, // all of the Opponent cards in play
        AllCards            = 13, // all  cards in play
        PlayerCommander     = 14,
        OpponentCommander   = 15,
        PlayerArtifact      = 16,
        OpponentArtifact    = 17,
        CardOnLeft          = 18, //Card to left when placed
        CardOnRight         = 19, //Card to Right when Placed
        PlacedRow           = 20, //all cards in row placed into
        SelectedRow         = 21, //all cards in row selected by player
        RaceOpponent        = 22, //all cards of opponents of specific race
        RacePlayer          = 23, //all cards of players of specific race
        OppositeRow         = 24, //all cards in row opposite placed
        SubTypeOpponent     = 25, //all cards of opponents of specific subtype
        SubTypePlayer       = 26, //all cards of players of specific subtype
        StrongestOpponent   = 27, //strongest opponent unit
        WeakestOpponent     = 28, //weakest opponent unit
        StrongestPlayer     = 29, //strongest player unit
        WeakestPlayer       = 30, //weakest player unit
        Neighbors           = 31, //cards on both sides when placed
    }
}