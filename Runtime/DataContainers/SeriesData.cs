/// <summary>
/// Project: wizards & wonders
/// Company: Pixelakes
/// Script:  SeriesData.cs
/// Created: 6/9/2022 11:11:00 AM
/// Author:  AaronBuffie
/// </summary>

namespace Pixelakes.Wrath{
    
    using System;
    using UnityEngine;
    using Newtonsoft.Json;
    
    [Serializable, JsonObject(MemberSerialization.OptIn)]
    public class SeriesData {

        [SerializeField, JsonProperty] protected string seriesName;        
        [SerializeField, JsonProperty] protected string sourceBundle;
        
        public string SeriesName    => seriesName;
        public string SourceBundle  => $"{seriesName.Replace(" ", "-").ToLower()}-{sourceBundle}";

    }
}