namespace Pixelakes.Wrath.Enums {
    public enum Effect{
        None        = 0,   
        Heal        = 1, 
        Damage      = 2,
        Destroy     = 3, 
        Resurrect   = 5, 
        Lock        = 6, 
        Unlock      = 7,
        Teleport    = 8,
        Reveal      = 9,
        Boost       = 10,
        Clone       = 11,
        Spawn       = 12,
        Immune      = 13,//cannot be damaged/targetted unless silenced
        Stealth     = 14,//cannot be targetted next round- also could be called hide/burrow etc
        Shuffle     = 15,
        Draw        = 16,//draw additional card
        Return      = 17,//returns unit to players hand and resets- buffs reset but could use deploy action
        Plant       = 18,//adds card to deck
        Protection  = 19,//bubble protection absorbs next damage
        Silence     = 20,//removes any status effects

    };
}