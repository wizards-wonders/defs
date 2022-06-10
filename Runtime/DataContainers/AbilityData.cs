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
    

    [Serializable, JsonObject(MemberSerialization.OptIn)]
    public class AbilityData {
        

    /**
    *   json data converted
    */
        [SerializeField, JsonProperty] string   name;
        [SerializeField, JsonProperty] string   description;
        [SerializeField, JsonProperty] int      actionValue; 
        [SerializeField, JsonProperty] int      offeringValue;
        [SerializeField, JsonProperty] int      uses;        
        [SerializeField, JsonProperty] bool[]   lanes;
        [JsonProperty, JsonConverter(typeof(StringEnumConverter))] public AbilityType   type;            
        [JsonProperty, JsonConverter(typeof(StringEnumConverter))] public Trigger       trigger;         
        [JsonProperty, JsonConverter(typeof(StringEnumConverter))] public Effect        action;          
        [JsonProperty, JsonConverter(typeof(StringEnumConverter))] public Effect        offering;       
        [JsonProperty, JsonConverter(typeof(StringEnumConverter))] public Target        actionTarget;    
        [JsonProperty, JsonConverter(typeof(StringEnumConverter))] public Target        offeringTarget;  
        


    /**
    * Editor stuff
    */
        public string       Name            => name;
        public string       Description     => description;
        public AbilityType  Type            => type;            // what triggers the action
        public Trigger      Trigger         => trigger;         // what triggers the action
        public Effect       Action          => action;          // type of action
        public Effect       Offering        => offering;        // type of offering - i.e cost paid or sacrifice made
        public Target       ActionTarget    => actionTarget;    // who the action affects
        public Target       OfferingTarget  => offeringTarget;  // who the offering affects
        public int          ActionValue     => actionValue;     // point value of action
        public int          OfferingValue   => offeringValue;   // point value of offering
        public int          Uses            => uses;            // how many times can be used
        public bool[]       Lanes           => lanes;           // which lane the ability works in        
        public bool Lane(int lane)          => (lane<0||lane>=lanes.Length) ? false : lanes[lane];

        
        public string TriggerString          { get => $"{Helpers.EnumToString<Trigger>(trigger)}";}
        public string ActionString           { get => $"{Helpers.EnumToString<Effect>(action)}";}
        public string OfferingString         { get => $"{Helpers.EnumToString<Effect>(offering)}";}
        public string ActionTargetString     { get => $"{Helpers.EnumToString<Target>(actionTarget)}";}
        public string OfferingTargetString   { get => $"{Helpers.EnumToString<Target>(offeringTarget)}";}


        /// <summary>
        /// Returns a formated string we can use in UI Text
        /// </summary>
        /// <returns></returns>
        public string RichStringify(){
            string actionColor = "#FFAD09";
            string offeringColor ="#6A0909";
            string rs = $"{Name}\n <b><color='{actionColor}'>{TriggerString}</color></b> - {ActionString} {ActionValue} TO {ActionTargetString}";
            if(offering != Enums.Effect.None) {
                rs += $"\n <b><color='{offeringColor}'>Scerifice</color></b> {OfferingString} {OfferingValue} TO {OfferingTargetString}";
            }
            return rs;
        }
    

    }
}
