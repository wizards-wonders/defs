namespace Pixelakes.Wrath.Enums {

    public enum Trigger {
        None        = 0,
        OnDeploy    = 1, 
        StartOfTurn = 2,
        DuringTurn  = 3,
        EndOfTurn   = 4, 
        Event       = 5, // for custom events, TODO: add event types
        OutOfTurn   = 6,
        OnDestroy   = 7,
        NextUnit    = 8,
        OnDamaged   = 9,
        OnHealed    = 10,
        Drawn       = 11,
    };

}