/// <summary>
/// Project: wizards & wonders
/// Company: Pixelakes
/// Script:  CardData.cs
/// Created: 6/9/2022 11:11:00 AM
/// Author:  AaronBuffie
/// </summary>

namespace Pixelakes.Wrath{
    using Enums;
    using System;
    using UnityEngine;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Type = Enums.Type;
    
    [Serializable]
    public class CardData{
        
        [SerializeField, JsonProperty] string name;                // the name for the card
        [SerializeField, JsonProperty] string quote;                  // if this card has a quote or some lore
        [SerializeField, JsonProperty, JsonConverter(typeof(StringEnumConverter))] Type     type;
        [SerializeField, JsonProperty, JsonConverter(typeof(StringEnumConverter))] Faction  faction;
        [SerializeField, JsonProperty, JsonConverter(typeof(StringEnumConverter))] SubType  subType;
        [SerializeField, JsonProperty, JsonConverter(typeof(StringEnumConverter))] Race     race;
        [SerializeField, JsonProperty, JsonConverter(typeof(StringEnumConverter))] Rarity   rarity;
        [SerializeField, JsonProperty] SeriesData series;

        [SerializeField,Range(0,20), JsonProperty] int pointValue;    // base point value
        [SerializeField, JsonProperty] int health;                    // ??
        [SerializeField, JsonProperty] int shield;                    // ??
        [SerializeField, JsonProperty] int summonCost;                // ??        
        [SerializeField, JsonProperty] int provisions;                // ??        
        [SerializeField, JsonProperty] AbilityData[] abilities;


        public string       Name        => name;
        public string       Quote       => quote;         
        public int          PointValue  => pointValue;
        public Type         Type        => type;
        public Faction      Faction     => faction;
        public SubType      SubType     => subType;
        public Race         Race        => race;
        public Rarity       Rarity      => rarity;
        public SeriesData   Series      => series;

    }
}
