/// <summary>
/// These classes allow for the Serializeation of Arrays holding Vector properties  
/// 
/// Basic usecase
/// [SerializeField, JsonConverter(typeof(Vector2ArrayConverter))] public Vector2[] vec2s;
/// 
/// [Serializable, JsonObject(MemberSerialization.OptIn)]
/// public class SomeClass{
///     [SerializeField, JsonProperty, JsonConverter(typeof(Vector3ArrayConverter))] public Vector3[] vec3s;
/// ...
/// 
/// supported
/// Vector2[]
/// Vector3[]
/// Vector4[]
/// </summary>

namespace Pixelakes.Wrath.JsonConverters{

    using System.Collections.Generic;
    using UnityEngine;
    using Newtonsoft.Json;

    public class Vector2ArrayConverter : BaseVectorConverter<List<Dictionary<string, float>>> {
        protected override string type {get=>"Vector2[]";}
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer){
            Vector2[] realValue = (Vector2[])value;
            List<Dictionary<string, float>> array = new List<Dictionary<string, float>>();
            foreach(var rv in realValue){
                array.Add(new Dictionary<string, float>(){
                    {"x", rv.x},
                    {"y", rv.y}
                });            
            }
            Write(array, writer);
        }
    }

    public class Vector3ArrayConverter : BaseVectorConverter<List<Dictionary<string, float>>>  {
        protected override string type {get=>"Vector3[]";}
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer){
            Vector3[] realValue = (Vector3[])value;
            List<Dictionary<string, float>> array = new List<Dictionary<string, float>>();
            foreach(var rv in realValue){
                array.Add(new Dictionary<string, float>(){
                    {"x", rv.x},
                    {"y", rv.y},
                    {"z", rv.z}
                });            
            }
            Write(array, writer);
        }
    }

    public class Vector4ArrayConverter : BaseVectorConverter<List<Dictionary<string, float>>>  {
        protected override string type {get=>"Vector4[]";}
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer){
            Vector4[] realValue = (Vector4[])value;
            List<Dictionary<string, float>> array = new List<Dictionary<string, float>>();
            foreach(var rv in realValue){
                array.Add(new Dictionary<string, float>(){
                    {"x", rv.x},
                    {"y", rv.y},
                    {"z", rv.z}
                });            
            }
            Write(array, writer);
        }
    }


}