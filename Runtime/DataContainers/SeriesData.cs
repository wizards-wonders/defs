/// <summary>
/// Project: wizards & wonders
/// Company: Pixelakes
/// Script:  SeriesData.cs
/// Created: 6/9/2022 11:11:00 AM
/// Author:  AaronBuffie
/// </summary>

namespace Pixelakes.Wrath{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using Enums;

    [JsonObject(MemberSerialization.OptIn)]
    public class SeriesData {

        [SerializeField, JsonProperty] string seriesName;        
        [SerializeField, JsonProperty] string mint;
    }
}