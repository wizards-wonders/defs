
namespace Pixelakes.Wrath{
    
    using Enums;
    using System.Collections.Generic;

    /// <summary>
    /// Simple enum string conversion helpers
    /// </summary>
    public class Helpers {
        public static string EnumToString<T>(T e)   => System.Enum.GetName(typeof(T), e);
        public static string EnumToString<T>(int e) => System.Enum.GetName(typeof(T), e);
        public static T StringToEnum<T>(string s)   => (T)System.Enum.Parse(typeof(T), s, true);
    }


    /// <summary>
    /// Entity Compatible Targets :: Returns a list of valid target names for the entity
    /// </summary>
    public class EntityTargets{

        /// <summary>
        /// Valid Targets for a Player 
        /// </summary>
        /// <value></value>
        public static List<string> Players => new List<string>{
            Helpers.EnumToString<Target>(Target.Battlefield),
            Helpers.EnumToString<Target>(Target.Hand),
            Helpers.EnumToString<Target>(Target.Deck),
            Helpers.EnumToString<Target>(Target.Commander),
            Helpers.EnumToString<Target>(Target.Wonder),
        };
        /// <summary>
        /// Valid Targets Both Players
        /// </summary>  
        public static List<string> All      => Players;        
        /// <summary>
        /// Valid Targets for a random Player
        /// </summary>
        public static List<string> Random   => Players;

        // Card Being played targets
        /// <summary>
        // Valid Targets for Card being played 
        /// </summary>
        /// <value></value>
        public static List<string> Card => new List<string>{
            Helpers.EnumToString<Target>(Target.None),
            Helpers.EnumToString<Target>(Target.CardOnLeft),
            Helpers.EnumToString<Target>(Target.CardOnRight),
            Helpers.EnumToString<Target>(Target.Neighbors),
            Helpers.EnumToString<Target>(Target.Row),
            Helpers.EnumToString<Target>(Target.OpposingRow)
        };

        
    }

    /// <summary>
    /// Target Compatible Targets :: Returns a list of valid target names for the target
    /// </summary>
    public class TargetTargets{

        /// <summary>
        /// Battlefield Compatible Targets :: Returns a list of valid target names for the Battlefield
        /// </summary>
        /// <value></value>
        public static List<string> Battlefield => new List<string>{           	
            Helpers.EnumToString<Target>(Target.Row),
            Helpers.EnumToString<Target>(Target.Strongest),	
            Helpers.EnumToString<Target>(Target.Weakest),		
            Helpers.EnumToString<Target>(Target.SubType),		
            Helpers.EnumToString<Target>(Target.Effect),		
            Helpers.EnumToString<Target>(Target.All),			
            Helpers.EnumToString<Target>(Target.Random),		
            Helpers.EnumToString<Target>(Target.Card),		
        };
        /// <summary>
        /// Row Compatible Targets :: Returns a list of valid target names for Rows in the battlefield
        /// </summary>
        /// <value></value>
        public static List<string> Row => new List<string>{
            Helpers.EnumToString<Target>(Target.Strongest),	
            Helpers.EnumToString<Target>(Target.Weakest),		
            Helpers.EnumToString<Target>(Target.SubType),		
            Helpers.EnumToString<Target>(Target.Effect),		
            Helpers.EnumToString<Target>(Target.All),			
            Helpers.EnumToString<Target>(Target.Random),		
            Helpers.EnumToString<Target>(Target.Card),			
        };
        /// <summary>
        /// SubType Compatible Targets :: Returns a list of valid target names for a card SubType
        /// </summary>
        /// <value></value>
        public static List<string> Effect => new List<string>{
            Helpers.EnumToString<Target>(Target.Strongest),	
            Helpers.EnumToString<Target>(Target.Weakest),		
            Helpers.EnumToString<Target>(Target.All),			
            Helpers.EnumToString<Target>(Target.Random),		
            Helpers.EnumToString<Target>(Target.Card),			
        };
        /// <summary>
        /// SubType Compatible Targets :: Returns a list of valid target names for a card SubType
        /// </summary>
        /// <value></value>
        public static List<string> SubType => new List<string>{
            Helpers.EnumToString<Target>(Target.Strongest),	
            Helpers.EnumToString<Target>(Target.Weakest),		
            Helpers.EnumToString<Target>(Target.Effect),		
            Helpers.EnumToString<Target>(Target.All),			
            Helpers.EnumToString<Target>(Target.Random),		
            Helpers.EnumToString<Target>(Target.Card),			
        };

        /// <summary>
        /// SubType Compatible Targets :: Returns a list of valid target names for Card(s) in Hand
        /// </summary>
        public static List<string> Hand => Deck;
        /// <summary>
        /// SubType Compatible Targets :: Returns a list of valid target names for Card(s) in Deck
        /// </summary>
        /// <value></value>
        public static List<string> Deck => new List<string>{
            Helpers.EnumToString<Target>(Target.Strongest),	
            Helpers.EnumToString<Target>(Target.Weakest),		
            Helpers.EnumToString<Target>(Target.SubType),			
            Helpers.EnumToString<Target>(Target.All),			
            Helpers.EnumToString<Target>(Target.Random),		
            Helpers.EnumToString<Target>(Target.Card),			
        };
    }
    
    /// <summary>
    /// Effect Compatible Targets :: Returns a list of valid effect names for the entity's target
    /// </summary>
    public class EntityEffectTargets{
        public static List<string> HasParent => new List<string>{
		    Helpers.EnumToString<Effect>(Effect.Heal),
		    Helpers.EnumToString<Effect>(Effect.Immune),
		    Helpers.EnumToString<Effect>(Effect.Resurrect),
		    Helpers.EnumToString<Effect>(Effect.Reincarnation),
		    Helpers.EnumToString<Effect>(Effect.Damage),
		    Helpers.EnumToString<Effect>(Effect.Destroy),
		    Helpers.EnumToString<Effect>(Effect.Retaliate),
		    Helpers.EnumToString<Effect>(Effect.Clone),
		    Helpers.EnumToString<Effect>(Effect.Spawn),
		    Helpers.EnumToString<Effect>(Effect.Summon),
		    Helpers.EnumToString<Effect>(Effect.Lock),
		    Helpers.EnumToString<Effect>(Effect.Unlock),
		    Helpers.EnumToString<Effect>(Effect.Teleport), 
		    Helpers.EnumToString<Effect>(Effect.Protection),
		    Helpers.EnumToString<Effect>(Effect.Silence),
		    Helpers.EnumToString<Effect>(Effect.Return),	
		    Helpers.EnumToString<Effect>(Effect.Boost),
		    Helpers.EnumToString<Effect>(Effect.Stealth),
		    Helpers.EnumToString<Effect>(Effect.Consume),
		    Helpers.EnumToString<Effect>(Effect.Absorb),
		    Helpers.EnumToString<Effect>(Effect.Displace),
        };

        public static List<string> IsParent => new List<string>{
            Helpers.EnumToString<Effect>(Effect.Reveal),   
            Helpers.EnumToString<Effect>(Effect.Shuffle),  
            Helpers.EnumToString<Effect>(Effect.Draw),     
            Helpers.EnumToString<Effect>(Effect.Plant),    
        };

    }
    public class WrathEnum{

        // get array of valid targets for entity
        public static IEnumerable<string> TargetsForEntity(int entity, bool isTrigger=false){
            List<string> targets = new List<string>();
            switch (entity){
                case (int)TargetEntity.Card : targets = EntityTargets.Card; break;
                case (int)TargetEntity.Player :
                case (int)TargetEntity.Opponent :
                case (int)TargetEntity.Random :
                    targets = EntityTargets.Players;
                break;
                case (int)TargetEntity.All :
                    targets = EntityTargets.All;
                break;
            }
            if(isTrigger){
                if(!targets.Contains(Helpers.EnumToString<Target>(Target.None))){
                    targets.Insert(0,Helpers.EnumToString<Target>(Target.None));
                }
                if(!targets.Contains(Helpers.EnumToString<Target>(Target.Effect))){
                    targets.Add(Helpers.EnumToString<Target>(Target.Effect));
                }
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
                case (int)Target.Battlefield : targets = TargetTargets.Battlefield; break;
                case (int)Target.Row         : targets = TargetTargets.Row; break;
                case (int)Target.Effect      : targets = TargetTargets.Effect; break;
                case (int)Target.SubType     : targets = TargetTargets.Row; break;
                case (int)Target.Hand        : targets = TargetTargets.Hand; break;
                case (int)Target.Deck        : targets = TargetTargets.Deck; break;
                default: break; // no valid targets 
            }

            return targets;
        }


        public static string TargetName(int i)          => Helpers.EnumToString<Target>(i);        
        public static string TargetEntityName(int i)    => Helpers.EnumToString<TargetEntity>(i);

    }
}