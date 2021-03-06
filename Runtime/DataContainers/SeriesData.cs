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

        [SerializeField, JsonProperty] string seriesName;        
        [SerializeField, JsonProperty] string mint;
    }
}