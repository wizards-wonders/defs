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
        
        [SerializeField, JsonProperty] protected string name;                // the name for the card
        [SerializeField, JsonProperty] protected string quote;               // if this card has a quote or some lore        
        [SerializeField, JsonProperty] protected string hash;                // cards identifier - also
        [SerializeField, JsonProperty, JsonConverter(typeof(StringEnumConverter))] protected Type     type;
        [SerializeField, JsonProperty, JsonConverter(typeof(StringEnumConverter))] protected Faction  faction;
        [SerializeField, JsonProperty, JsonConverter(typeof(StringEnumConverter))] protected SubType  subType;
        [SerializeField, JsonProperty, JsonConverter(typeof(StringEnumConverter))] protected Rarity   rarity;
        [SerializeField, JsonProperty] protected SeriesData series;

        [SerializeField,Range(0,20), JsonProperty]  protected int pointValue;           // base point value       
        [SerializeField, JsonProperty]              protected int provisions;           // ??        
        [SerializeField, JsonProperty]              protected AbilityData[] abilities;

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
        public string       Hash        => hash;         
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
