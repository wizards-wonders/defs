namespace Pixelakes.Wrath.JsonConverters{
    
    using System;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using Pixelakes.Wrath.Enums;
    public class TraitArrayConverter : BaseVectorConverter<string[]>{
       
        protected override string type {get=>"Trait[]";}
       


        public override object ReadJson(JsonReader reader, System.Type objectType, object existingValue, JsonSerializer serializer){
            JToken token = JToken.Load(reader);
            if (token.Type == JTokenType.Array){
                string[] stringValues = token.ToObject<string[]>();
                return Array.ConvertAll(stringValues, s => (Trait)Enum.Parse(typeof(Trait), s, true));
            }
            return null;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer){
            Trait[] traits = value as Trait[];
            if (traits != null){
                string[] stringValues = Array.ConvertAll(traits, t => t.ToString());
                Write(stringValues, writer);
            }
        }
    }

}