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
    using JsonConverters;
    
    [Serializable, JsonObject(MemberSerialization.OptIn)]
    public class CardData{
        
        [SerializeField, JsonProperty] string name;                // the name for the card
        [SerializeField, JsonProperty] string quote;               // if this card has a quote or some lore
        [SerializeField, JsonProperty, JsonConverter(typeof(StringEnumConverter))] Type     type;
        [SerializeField, JsonProperty, JsonConverter(typeof(StringEnumConverter))] Faction  faction;
        [SerializeField, JsonProperty, JsonConverter(typeof(StringEnumConverter))] SubType  subType;
        [SerializeField, JsonProperty, JsonConverter(typeof(StringEnumConverter))] Rarity   rarity;
        [SerializeField, JsonProperty] SeriesData series;

        [SerializeField, JsonProperty] string artTexture;
        [SerializeField, JsonProperty] string frameTexture;
        [SerializeField, JsonProperty] string backTexture0;
        [SerializeField, JsonProperty] string backTexture1;

        [SerializeField,Range(0,20), JsonProperty] int pointValue;    // base point value       
        [SerializeField, JsonProperty] int provisions;                // ??        
        [SerializeField, JsonProperty] AbilityData[] abilities;

        [SerializeField, JsonProperty] public string    faceArtTexture;
        [SerializeField, JsonProperty] public string    faceFrameTexture;
        [SerializeField, JsonProperty] public float[]   faceDepths;
        [SerializeField, JsonProperty, JsonConverter(typeof(Vector3ArrayConverter))] public Vector3[] faceTiling;
        [SerializeField, JsonProperty, JsonConverter(typeof(Vector2ArrayConverter))] public Vector2[] faceOffset;
                
        [SerializeField, JsonProperty] public string[]  backLayers;
        [SerializeField, JsonProperty] public float[]   backDepths;
        [SerializeField, JsonProperty, JsonConverter(typeof(Vector3ArrayConverter))] public Vector3[] backTiling;
        [SerializeField, JsonProperty, JsonConverter(typeof(Vector2ArrayConverter))] public Vector2[] backOffset;


        public string       Name        => name;
        public string       Quote       => quote;         
        public int          PointValue  => pointValue;
        public Type         Type        => type;
        public Faction      Faction     => faction;
        public SubType      SubType     => subType;
        public Rarity       Rarity      => rarity;
        public SeriesData   Series      => series;
        public AbilityData[] Abilities  => abilities;

        public string    FaceArtTexture     => faceArtTexture;
        public string    FaceFrameTexture   => faceFrameTexture;
        public float[]   FaceDepths         => faceDepths;
        public Vector3[] FaceTiling         => faceTiling;
        public Vector2[] FaceOffset         => faceOffset;
        
        public string[]  BackLayers         => backLayers;
        public float[]   BackDepths         => backDepths;
        public Vector3[] BackTiling         => backTiling;
        public Vector2[] BackOffset         => backOffset;

    }
}
