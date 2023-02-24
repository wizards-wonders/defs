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
        [JsonProperty, JsonConverter(typeof(StringEnumConverter))] public AbilityType   type;                   // Triggered or User Activated
        [JsonProperty, JsonConverter(typeof(StringEnumConverter))] public Trigger       trigger;                // Trigger that invokes uses
        [JsonProperty, JsonConverter(typeof(StringEnumConverter))] public Effect        triggerEffect;          // The action (Effect) that invokes uses if Trigger is Effect    
        [JsonProperty, JsonConverter(typeof(StringEnumConverter))] public Effect        action;                 // The action (Effect) ran
        [JsonProperty, JsonConverter(typeof(StringEnumConverter))] public Effect        offering;               // The offering (Effect) ran, Sacerfice, Cost for use
        [JsonProperty, JsonConverter(typeof(StringEnumConverter))] public Target        actionTarget;           // Target card(s) for the action (Effect) to be applied to
        [JsonProperty, JsonConverter(typeof(StringEnumConverter))] public Target        offeringTarget;         // Target card(s) for the offering (Effect)  to be applied to
        [JsonProperty, JsonConverter(typeof(StringEnumConverter))] public Effect        actionEffectTarget;     // Target card(s) with Effect for the action (Effect) to be applied to
        [JsonProperty, JsonConverter(typeof(StringEnumConverter))] public Effect        offeringEffectTarget;   // Target card(s) with Effect for the offering (Effect)  to be applied to         
        [JsonProperty, JsonConverter(typeof(StringEnumConverter))] public SubType       actionSubTypeTarget;    // Card SubType Action Targets if any     
        [JsonProperty, JsonConverter(typeof(StringEnumConverter))] public SubType       offeringSubTypeTarget;  // Card SubType Offering Targets if any
        [JsonProperty, JsonConverter(typeof(StringEnumConverter))] public TargetEntity  targetEntity;           // (Card, Player, Opponent, Random, etc) of the Target        
        [JsonProperty, JsonConverter(typeof(StringEnumConverter))] public TargetEntity  offeringEntity;         // (Card, Player, Opponent, Random, etc) of the offering Target
        [JsonProperty, JsonConverter(typeof(StringEnumConverter))] public TargetEntity  triggerEntity;          // (Card, Player, Opponent, Random, etc) that invokes the trigger        
        


    /**
    * Editor stuff
    */
        public string       Name                    => name;
        public string       Description             => description;
        public AbilityType  Type                    => type;                    // if trigger is auto or user fired
        public Trigger      Trigger                 => trigger;                 // what triggers the action        
        public Effect       TriggerEffect           => triggerEffect;           // what effect triggers the action if trigger is effect
        public Effect       Action                  => action;                  // type of action
        public Effect       Offering                => offering;                // type of offering - i.e cost paid or sacrifice made
        public Target       ActionTarget            => actionTarget;            // who the action affects
        public Target       OfferingTarget          => offeringTarget;          // who the offering affects
        public Effect       ActionEffectTarget      => actionEffectTarget;      // Effect on Cards that should be Targeted for the action (Effect) to be applied to
        public Effect       OfferingEffectTarget    => offeringEffectTarget;    // Effect on Cards that should be Targeted for the offering (Effect)  to be applied to         
       
        public SubType      ActionSubTypeTarget     => actionSubTypeTarget;     // SubType the action affects if set
        public SubType      OfferingSubTypeTarget   => offeringSubTypeTarget;   // SubType the offering affects if set
        public TargetEntity TargetEntity            => targetEntity;            // (Card, Player, Opponent, Random, etc) of the Target
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

        
        public string TriggerString          { get => $"{Regex.Replace(Helpers.EnumToString<Trigger>(trigger), "([A-Z])([a-z]*)", " $1$2") }";}
        public string ActionString           { get => $"{Regex.Replace(Helpers.EnumToString<Effect>(action), "([A-Z])([a-z]*)", " $1$2")}";}
        public string OfferingString         { get => $"{Regex.Replace(Helpers.EnumToString<Effect>(offering), "([A-Z])([a-z]*)", " $1$2")}";}
        public string ActionTargetString     { get => $"{Regex.Replace(Helpers.EnumToString<Target>(actionTarget), "([A-Z])([a-z]*)", " $1$2")}";}
        public string OfferingTargetString   { get => $"{Regex.Replace(Helpers.EnumToString<Target>(offeringTarget), "([A-Z])([a-z]*)", " $1$2")}";}



        /// <summary>
        /// Returns a formated string we can use in UI Text
        /// </summary>
        /// <returns></returns>
         public string RichStringify(){
            string actionColor = "#FFAD09";
            string offeringColor ="#6A0909";
            string rs = "";
            if(Name.Length>1) rs=$"{Name}\n";
            rs+=$"<b><color={actionColor}>{TriggerString}</color></b> - {ActionString} {ActionValue} {ActionTargetString}";
            if(offering != Enums.Effect.None) {
                rs += $"\n<b><color={offeringColor}>Scerifice</color></b> {OfferingString} {OfferingValue} {OfferingTargetString}";
            }
            return rs.Replace("None", "");
        }
    

    }
}
