namespace Pixelakes.Wrath.JsonConverters{

    using System;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;


    public abstract class BaseVectorConverter<CollectionType> : JsonConverter {
        /// <summary>
        /// Vector type "As String Name" supported to compare against
        /// </summary>
        /// <value></value>
        protected abstract string type  {get;}    
        // Not sure what these are really needed for, but we just need to write  
        public override bool CanRead    { get=>false; }
        public override bool CanWrite   { get=>true; }

        public override bool CanConvert(Type objectType)  => objectType.Name == type;
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) => throw new NotImplementedException("Unnecessary because CanRead is false. The type will skip the converter.");

        //The write proccess after the Vector Collection "or Collection of Vector Collections" is built
        protected void Write(CollectionType d, JsonWriter writer){
            JToken t = JToken.FromObject(d);
            if (t.Type != JTokenType.Object) {
                t.WriteTo(writer);
            } else {
                JObject o = (JObject)t;
                o.WriteTo(writer);
            }
        }
    }
}