/// <summary>
/// These classes allow for the Serializeation of Single Vector properties  
/// 
/// Basic usecase
/// [SerializeField, JsonConverter(typeof(Vector2Converter))] public Vector2 vec2;
/// 
/// [Serializable, JsonObject(MemberSerialization.OptIn)]
/// public class SomeClass{
///     [SerializeField, JsonProperty, JsonConverter(typeof(Vector3Converter))] public Vector3 vec3;
/// ...
/// 
/// supported
/// Vector2
/// Vector3
/// Vector4
/// </summary>

namespace Pixelakes.Wrath.JsonConverters{

    using System.Collections.Generic;
    using UnityEngine;
    using Newtonsoft.Json;

    public class Vector2Converter : BaseVectorConverter<Dictionary<string, float>> {    
        protected override string type {get=>"Vector2";}
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer){
            Vector2 realValue = (Vector2)value;
            Dictionary<string, float> d = new Dictionary<string, float>();
            d.Add("x", realValue.x);
            d.Add("y", realValue.y);
            Write(d, writer);
        }
    }

    public class Vector3Converter : BaseVectorConverter<Dictionary<string, float>> {
        protected override string type {get=>"Vector3";}
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer){
            Vector3 realValue = (Vector3)value;
            Dictionary<string, float> d = new Dictionary<string, float>();
            d.Add("x", realValue.x);
            d.Add("y", realValue.y);
            d.Add("z", realValue.z);
            Write(d, writer);
        }
    }

    public class Vector4Converter : BaseVectorConverter<Dictionary<string, float>> {
        protected override string type {get=>"Vector3";}
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer){
            Vector4 realValue = (Vector4)value;
            Dictionary<string, float> d = new Dictionary<string, float>();
            d.Add("x", realValue.x);
            d.Add("y", realValue.y);
            d.Add("z", realValue.z);
            d.Add("w", realValue.w);
            Write(d, writer);
        }
    }

}