/// <summary>
/// Project: wizards & wonders
/// Company: Pixelakes
/// Script:  AbilityData.cs
/// Created: 6/9/2022 11:11:00 AM
/// Author:  AaronBuffie
/// </summary>

namespace Pixelakes.Wrath{

    using Enums;
    using System;
    using UnityEngine;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.Text.RegularExpressions;
    

    [Serializable, JsonObject(MemberSerialization.OptIn)]
    public class AbilityData {        

    
    /**
    *   json data converted
    */
        [SerializeField, JsonProperty] protected string   name;
        [SerializeField, JsonProperty] protected string   description;          // readable desc for the player
        [SerializeField, JsonProperty] protected int      actionValue   = 1;    // the value applied to the action (Effect)
        [SerializeField, JsonProperty] protected int      offeringValue = 0;    // the value applied to the action (Effect)    
        [SerializeField, JsonProperty] protected int      targetCount   = 1;    // Number of targets to apply the action (Effect)        
        [SerializeField, JsonProperty] protected int      offeringCount = 1;    // Number of targets to apply the offering (Effect)
        [SerializeField, JsonProperty] protected int      uses          = 1;    // How many times ability can be invoked durning the cards life
        [SerializeField, JsonProperty] protected bool     targetsSelf   = false;// if card should be included with the target
        [SerializeField, JsonProperty] protected bool[]   lanes;                // the lane the card needs to sit for the ability to be usable
        [JsonProperty, JsonConverter(typeof(StringEnumConverter))] public Rarity rarity;
        [JsonProperty, JsonConverter(typeof(StringEnumConverter))] public AbilityType   type;                   // Triggered or User Activated
        [JsonProperty, JsonConverter(typeof(StringEnumConverter))] public Trigger       trigger;                // Trigger that invokes uses
        [JsonProperty, JsonConverter(typeof(StringEnumConverter))] public Effect        triggerEffect;          // The action (Effect) that invokes uses if Trigger is Effect    
        [JsonProperty, JsonConverter(typeof(StringEnumConverter))] public Effect        action;                 // The action (Effect) ran
        [JsonProperty, JsonConverter(typeof(StringEnumConverter))] public Effect        offering;               // The offering (Effect) ran, Sacerfice, Cost for use
        
        [JsonProperty(ItemConverterType = typeof(StringEnumConverter))] public Target[]        actionTarget;           // Target card(s) for the action (Effect) to be applied to
        [JsonProperty(ItemConverterType = typeof(StringEnumConverter))] public Target[]        offeringTarget;         // Target card(s) for the offering (Effect)  to be applied to
        [JsonProperty(ItemConverterType = typeof(StringEnumConverter))] public Target[]        triggerTarget;         // Target card(s) for the Trigger (Effect)  to be applied to
        
        [JsonProperty, JsonConverter(typeof(StringEnumConverter))] public Effect        actionEffectTarget;     // Target card(s) with Effect for the action (Effect) to be applied to
        [JsonProperty, JsonConverter(typeof(StringEnumConverter))] public Effect        offeringEffectTarget;   // Target card(s) with Effect for the offering (Effect)  to be applied to 
        [JsonProperty, JsonConverter(typeof(StringEnumConverter))] public Effect        triggerEffectTarget;   // Target card(s) with Effect for the Trigger (Effect)  to be applied to         
        
        [JsonProperty, JsonConverter(typeof(StringEnumConverter))] public SubType       actionSubTypeTarget;    // Card SubType Action Targets if any     
        [JsonProperty, JsonConverter(typeof(StringEnumConverter))] public SubType       offeringSubTypeTarget;  // Card SubType Offering Targets if any   
        [JsonProperty, JsonConverter(typeof(StringEnumConverter))] public SubType       triggerSubTypeTarget;  // Card SubType Trigger Targets if any
        
        [JsonProperty, JsonConverter(typeof(StringEnumConverter))] public TargetEntity  actionEntity;           // (Card, Player, Opponent, Random, etc) of the Target        
        [JsonProperty, JsonConverter(typeof(StringEnumConverter))] public TargetEntity  offeringEntity;         // (Card, Player, Opponent, Random, etc) of the offering Target
        [JsonProperty, JsonConverter(typeof(StringEnumConverter))] public TargetEntity  triggerEntity = TargetEntity.Card;          // (Card, Player, Opponent, Random, etc) that invokes the trigger        
        


    /**
    * Editor stuff
    */
        public string       Name                    => name;
        public string       Description             => description;
        public Rarity       Rarity                  => rarity;
        public AbilityType  Type                    => type;                    // if trigger is auto or user fired

        public Trigger      Trigger                 => trigger;                 // what triggers the action   
        public Effect       TriggerEffect           => triggerEffect;           // what effect triggers the action if trigger is effect

        public Effect       Action                  => action;                  // type of action
        public Effect       Offering                => offering;                // type of offering - i.e cost paid or sacrifice made
        
        public Target[]       ActionTarget            => actionTarget;            // who the action affects
        public Target[]       OfferingTarget          => offeringTarget;          // who the offering affects
        public Target[]       TriggerTarget           => triggerTarget;           // who/what triggers the effects
        
        public Effect       ActionEffectTarget      => actionEffectTarget;      // Effect on Cards that should be Targeted for the action (Effect) to be applied to
        public Effect       OfferingEffectTarget    => offeringEffectTarget;    // Effect on Cards that should be Targeted for the offering (Effect)  to be applied to         
        public Effect       TriggerEffectTarget     => triggerEffectTarget;    // Effect on Cards that should be Targeted for the offering (Effect)  to be applied to         
       
        public SubType      ActionSubTypeTarget     => actionSubTypeTarget;     // SubType the action affects if set
        public SubType      OfferingSubTypeTarget   => offeringSubTypeTarget;   // SubType the offering affects if set
        public SubType      TriggerSubTypeTarget    => triggerSubTypeTarget;    // SubType the offering affects if set
        
        public TargetEntity ActionEntity            => actionEntity;            // (Card, Player, Opponent, Random, etc) of the Target
        public TargetEntity OfferingEntity          => offeringEntity;          // (Card, Player, Opponent, Random, etc) of the offering Target
        public TargetEntity TriggerEntity           => triggerEntity;           // (Card, Player, Opponent, Random, etc) That invokes the trigger
        
        public int          TargetCount             => targetCount;             // point value of action
        public int          OfferingCount           => offeringCount;           // point value of offering
        public int          ActionValue             => actionValue;             // point value of action
        public int          OfferingValue           => offeringValue;           // point value of offering
        public int          Uses                    => uses;                    // how many times can be used
        public bool         TargetsSelf             => targetsSelf;             // when target is not self should the effect also be applied to this card
        public bool[]       Lanes                   => lanes;                   // which lane the ability works in        
        public bool Lane(int lane)                  => (lane<0||lane>=lanes.Length) ? false : lanes[lane];

        
        public string TriggerString          { get => EnumStringToHuman(Helpers.EnumToString<Trigger>(trigger));}
        public string ActionString           { get => EnumStringToHuman(Helpers.EnumToString<Effect>(action));}
        public string OfferingString         { get => EnumStringToHuman(Helpers.EnumToString<Effect>(offering));}
        public string ActionTargetString     { get => EnumArrayToString<Target>(actionTarget);}        
        public string OfferingTargetString   { get => EnumArrayToString<Target>(offeringTarget);}      
        public string TriggerTargetString    { get => EnumArrayToString<Target>(triggerTarget);}
// ** Array convert
        // public string ActionTargetString     { get => EnumArrayToString<Target>(actionTarget);}  
        // public string OfferingTargetString   { get => EnumArrayToString<Target>(offeringTarget);}



        /// <summary>
        /// Returns a formated string we can use in UI Text
        /// </summary>
        /// <returns></returns>
        public virtual string RichStringify(bool drawName=false){
            string triggerColor   = "#FFAD09";
            string offeringColor ="#FF6600";
            string badColor      = "#FC003F";
            string goodColor     = "#03FFC0";            
            string modColor     = "#6846BD";

            string rs = "";
            if(drawName && Name.Length>1) rs=$"\n{Name}\n";

            string actionValueString = ActionValue==0 ? ActionString : $"{ActionString} {(ActionValue>0 ? $"+{ActionValue}" : $"-{ActionValue}" )}";
            
            string actionColor = ActionValue==0 ? modColor: (ActionValue<0 ? badColor : goodColor);
            rs+= $"<b><color={triggerColor}>{TriggerString}</color></b><color={actionColor}> - {actionValueString}</color>\n";
            rs+= EnumArrayToString<Target>(ActionTarget, TargetCount);

            if(Offering != Effect.None) {
                rs += $"\n<b><color={offeringColor}>Scerifice</color></b> {OfferingString} {OfferingValue} {OfferingTargetString}";
            }rs+="\n";
            return rs.Replace("None", "");
        }

        string EnumArrayToString<E>(E[] enums, int cardCount=0) {
            string[] enumstrings = new string[enums.Length];
            for(int i=0; i< enums.Length; i++){
                string t = EnumStringToHuman(Helpers.EnumToString<E>(enums[i]));
                switch(t){
                    case "All"          : t= $"{t} Cards";  break;
                    case "Battlefield"  : t= $"On {t}";     break;
                    case "Row"          : t= $"In Lane";    break;
                    case "Card"         : t= $"{Mathf.Max(cardCount,1)} Card{(cardCount>1 ? "s" :"")}"; break;                    
                    case "Random"       : 
                    case "Strongest"    :
                    case "Weakest"      : t= $"{Mathf.Max(cardCount,1)} {t} Card{(cardCount>1 ? "s" :"")}"; break;
                }
                enumstrings[i] = t;
            }
            Array.Reverse(enumstrings);
            return String.Join(" ", enumstrings);
        }
        string EnumStringToHuman(string str) => $"{Regex.Replace(str, "([A-Z])([a-z]*)", "$1$2")}";



        public ClonedAbility Clone(){
            AbilityData clone = new AbilityData();
            clone.name                  = name;
            clone.description           = description;
            clone.actionValue           = actionValue;
            clone.offeringValue         = offeringValue;
            clone.targetCount           = targetCount;
            clone.offeringCount         = offeringCount;
            clone.uses                  = uses;
            clone.targetsSelf           = targetsSelf;
            clone.lanes                 = lanes != null ? (bool[])lanes.Clone() : null;
            clone.rarity                = rarity;
            clone.type                  = type;
            clone.trigger               = trigger;
            clone.triggerEffect         = triggerEffect;
            clone.action                = action;
            clone.offering              = offering;
            clone.actionTarget          = actionTarget != null ? (Target[])actionTarget.Clone() : null;
            clone.offeringTarget        = offeringTarget != null ? (Target[])offeringTarget.Clone() : null;
            clone.triggerTarget         = triggerTarget != null ? (Target[])triggerTarget.Clone() : null;
            clone.actionEffectTarget    = actionEffectTarget;
            clone.offeringEffectTarget  = offeringEffectTarget;
            clone.triggerEffectTarget   = triggerEffectTarget;
            clone.actionSubTypeTarget   = actionSubTypeTarget;
            clone.offeringSubTypeTarget = offeringSubTypeTarget;
            clone.triggerSubTypeTarget  = triggerSubTypeTarget;
            clone.actionEntity          = actionEntity;
            clone.offeringEntity        = offeringEntity;
            clone.triggerEntity         = triggerEntity;
            return (ClonedAbility)clone;
        }

    }

    public class ClonedAbility : AbilityData{
        public void SetActionValue(int v)   => actionValue      = v;
        public void SetOfferingValue(int v) => offeringValue    = v;
        public void SetTargetCount(int v)   => targetCount      = v;
        public void SetOfferingCount(int v) => offeringCount    = v;
        public void SetUses(int v)          => uses             = v;
    }
    
}