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
        [SerializeField, JsonProperty] protected string   description;
        [SerializeField, JsonProperty] protected int      actionValue; 
        [SerializeField, JsonProperty] protected int      offeringValue;
        [SerializeField, JsonProperty] protected int      uses;
        [SerializeField, JsonProperty] protected bool     targetsSelf;     
        [SerializeField, JsonProperty] protected bool[]   lanes;
        [JsonProperty, JsonConverter(typeof(StringEnumConverter))] public AbilityType   type;            
        [JsonProperty, JsonConverter(typeof(StringEnumConverter))] public Trigger       trigger;         
        [JsonProperty, JsonConverter(typeof(StringEnumConverter))] public Effect        action;          
        [JsonProperty, JsonConverter(typeof(StringEnumConverter))] public Effect        offering;       
        [JsonProperty, JsonConverter(typeof(StringEnumConverter))] public Target        actionTarget;    
        [JsonProperty, JsonConverter(typeof(StringEnumConverter))] public Target        offeringTarget;            
        [JsonProperty, JsonConverter(typeof(StringEnumConverter))] public SubType       actionSubTarget;         
        [JsonProperty, JsonConverter(typeof(StringEnumConverter))] public SubType       offeringSubTarget; 
        


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
        public bool         TargetsSelf     => targetsSelf;     // when target is not self should the effect also be applied to this card
        public bool[]       Lanes           => lanes;           // which lane the ability works in        
        public bool Lane(int lane)          => (lane<0||lane>=lanes.Length) ? false : lanes[lane];

        
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
