namespace Pixelakes.Wrath{
    
    using Enums;
    using System.Linq;
    using System.Collections.Generic;

    /// <summary>
    /// Simple enum string conversion helpers
    /// </summary>
    public class Helpers {
        public static string EnumToString<T>(T e)   => System.Enum.GetName(typeof(T), e);
        public static string EnumToString<T>(int e) => System.Enum.GetName(typeof(T), e);
        public static T StringToEnum<T>(string s)   => (T)System.Enum.Parse(typeof(T), s, true);
    }

    abstract public class EnumFilter<T> where T:struct{

        public static T[] EnumList =>  ( ((T[])System.Enum.GetValues(typeof(T))).ToList<T>().Where(e => (int)(object)e !=0)).ToArray<T>();

        /// <summary>
        /// Filters out unwanted values from an enum and returns an IEnumerable set of type string
        /// </summary>
        /// <param name="invalid"></param>
        /// <returns></returns>
        public static IEnumerable<string> Filtered(List<T> invalid = default(List<T>)){
            foreach (T e in EnumList){
                if(invalid!=null && invalid.Contains(e)){continue;}
                yield return Helpers.EnumToString<T>(e);
            }
        }
        /// <summary>
        /// Filters out unwanted values from an enum and returns an IEnumerable set  
        /// </summary>
        /// <param name="invalid"></param>
        /// <returns></returns>
        public static IEnumerable<T> FilteredEnum(List<T> invalid = default(List<T>)){
            foreach (T e in EnumList){
                if(invalid!=null && invalid.Contains(e)){continue;}
                yield return e;
            }
        }

        /// <summary>
        /// Filters wanted values from an enum and returns an IEnumerable set of type string
        /// </summary>
        /// <param name="invalid"></param>
        /// <returns></returns>
        public static IEnumerable<string> Only(List<T> only = default(List<T>)){ // NOTE: IS this more overhead then using its own foreach like the rest?
            var o = OnlyEnum(only).GetEnumerator();
            while(o.MoveNext()){yield return Helpers.EnumToString<T>(o.Current);}
        }
        /// <summary>
        /// Filters wanted values from an enum and returns an IEnumerable set  
        /// </summary>
        /// <param name="invalid"></param>
        /// <returns></returns>
        public static IEnumerable<T> OnlyEnum(List<T> only = default(List<T>)){
            foreach (T e in EnumList){
                if(only!=null && only.Contains(e)){yield return e;}
            }
        }
    }

    /// <summary>
    /// Entity Compatible Targets :: Returns a list of valid target names for the entity
    /// </summary>
    public class EntityTargets :EnumFilter<Target>{

        /// <summary>
        /// Valid Targets for a Player 
        /// </summary>
        /// <value></value>
        public static IEnumerable<string> Players => Only(new List<Target>{
            Target.Battlefield,
            Target.Hand,
            Target.Deck,
            Target.Commander,
            Target.Wonder,
        });
        /// <summary>
        /// Valid Targets Both Players
        /// </summary>  
        public static IEnumerable<string> All      => Players;        
        /// <summary>
        /// Valid Targets for a random Player
        /// </summary>
        public static IEnumerable<string> Random   => Players;

        // Card Being played targets
        /// <summary>
        // Valid Targets for Card being played 
        /// </summary>
        /// <value></value>
        public static IEnumerable<string> Card => Only(new List<Target>{
            Target.CardOnLeft,
            Target.CardOnRight,
            Target.Neighbors,
            Target.Row,
            Target.OpposingRow
        });

        
    }

    /// <summary>
    /// Target Compatible Targets :: Returns a list of valid target names for the target
    /// </summary>
    public class TargetTargets : EnumFilter<Target>{

        /// <summary>
        /// Battlefield Compatible Targets :: Returns a list of valid target names for the Battlefield
        /// </summary>
        /// <value></value>
        public static IEnumerable<string> Battlefield => Filtered(new List<Target>(){
            Target.Battlefield,	
            Target.CardOnLeft,	
            Target.CardOnRight,	
            Target.Neighbors,			
            Target.OpposingRow,			
            Target.Hand,		
            Target.Deck,		
            Target.Commander,	
            Target.Wonder,
        }); 
        /// <summary>
        /// Row Compatible Targets :: Returns a list of valid target names for Rows in the battlefield
        /// </summary>
        /// <value></value>
        public static IEnumerable<string> Row => Only(new List<Target>{
            Target.Strongest,	
            Target.Weakest,		
            Target.SubType,		
            Target.Effect,		
            Target.All,			
            Target.Random,		
            Target.Card,			
        });
        
        /// <summary>
        /// SubType Compatible Targets :: Returns a list of valid target names for a card SubType
        /// </summary>
        /// <value></value>
        public static IEnumerable<string> Effect => Only(new List<Target>{
            Target.Strongest,	
            Target.Weakest,		
            Target.All,			
            Target.Random,		
            Target.Card,			
        });
        /// <summary>
        /// SubType Compatible Targets :: Returns a list of valid target names for a card SubType
        /// </summary>
        /// <value></value>
        public static IEnumerable<string> SubType => Only(new List<Target>{
            Target.Strongest,	
            Target.Weakest,		
            Target.Effect,		
            Target.All,			
            Target.Random,		
            Target.Card,			
        });

        /// <summary>
        /// SubType Compatible Targets :: Returns a list of valid target names for Card(s) in Hand
        /// </summary>
        public static IEnumerable<string> Hand => Deck;
        /// <summary>
        /// SubType Compatible Targets :: Returns a list of valid target names for Card(s) in Deck
        /// </summary>
        /// <value></value>
        
        public static IEnumerable<string> Deck => Only(new List<Target>{
           Target.Strongest,	
           Target.Weakest,		
           Target.SubType,			
           Target.All,			
           Target.Random,		
           Target.Card,			
        });
    }
    
    /// <summary>
    /// Effect Compatible Targets :: Returns a list of valid effect names for the entity's target
    /// </summary>
    public class EntityEffectTargets : EnumFilter<Effect>{
        public static IEnumerable<string> HasParent => Filtered(new List<Effect>(){            						
            Effect.Reveal,			
            Effect.Shuffle,			
            Effect.Draw,			
            Effect.Return,			
        });
        public static IEnumerable<string> IsParent => Only(new List<Effect>{
            Effect.Reveal,   
            Effect.Shuffle,  
            Effect.Draw,       
        });
        
    }

    public class Effects : EnumFilter<Effect>{
        public static IEnumerable<string> TypeActivated => Filtered(new List<Effect>(){Effect.Retaliate});       
        public static IEnumerable<string> TypeTrigger   => Filtered();
        public static IEnumerable<string> Offering      => Only(new List<Effect>(){Effect.Damage, Effect.Destroy, Effect.Lock, Effect.Teleport, Effect.Silence, Effect.Return, Effect.Shuffle });
    }
    
    public class WrathEnum{

        // get array of valid targets for entity
        public static IEnumerable<string> TargetsForEntity(int entity, bool isTrigger=false){
            List<string> targets = new List<string>();
            switch (entity){
                case (int)TargetEntity.Card : targets = EntityTargets.Card.ToList<string>(); break;
                case (int)TargetEntity.Player :
                case (int)TargetEntity.Opponent :
                case (int)TargetEntity.Random :
                    targets = EntityTargets.Players.ToList<string>();
                break;
                case (int)TargetEntity.All :
                    targets = EntityTargets.All.ToList<string>();
                break;
            }
            if(isTrigger){
                if(entity==(int)TargetEntity.Card && !targets.Contains(Helpers.EnumToString<Target>(Target.None))){
                //if(!targets.Contains(Helpers.EnumToString<Target>(Target.None))){
                    targets.Insert(0,Helpers.EnumToString<Target>(Target.None));
                }
                if(!targets.Contains(Helpers.EnumToString<Target>(Target.Effect))){
                    targets.Add(Helpers.EnumToString<Target>(Target.Effect));
                }
            }else if(!targets.Contains(Helpers.EnumToString<Target>(Target.None))){
                targets.Insert(0,Helpers.EnumToString<Target>(Target.None));
            }
            return targets;
        }

        /// <summary>
        /// TargetsForTarget :: Get valid targets for a target
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public static IEnumerable<string> TargetsForTarget(Target target) => TargetsForTarget((int)target);
        /// <summary>
        /// TargetsForTarget :: Get valid targets for a target
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public static IEnumerable<string> TargetsForTarget(int target){
            List<string> targets = new List<string>();
            switch (target){
                case (int)Target.Battlefield : targets = TargetTargets.Battlefield.ToList<string>(); break;
                case (int)Target.Row         : targets = TargetTargets.Row.ToList<string>(); break;
                
                case (int)Target.Lane1         : targets = TargetTargets.Row.ToList<string>(); break;
                case (int)Target.Lane2         : targets = TargetTargets.Row.ToList<string>(); break;
                case (int)Target.Lane3         : targets = TargetTargets.Row.ToList<string>(); break;

                case (int)Target.Effect      : targets = TargetTargets.Effect.ToList<string>(); break;
                case (int)Target.SubType     : targets = TargetTargets.Row.ToList<string>(); break;
                case (int)Target.Hand        : targets = TargetTargets.Hand.ToList<string>(); break;
                case (int)Target.Deck        : targets = TargetTargets.Deck.ToList<string>(); break;
                default: break; // no valid targets 
            }

            return targets;
        }


        public static string TargetName(int i)          => Helpers.EnumToString<Target>(i);        
        public static string TargetEntityName(int i)    => Helpers.EnumToString<TargetEntity>(i);

    }
}