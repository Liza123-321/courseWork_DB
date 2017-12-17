using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Runtime.Serialization.Json;
using System.Text;

namespace CourseWork.JsonHelper
{
    [DataContract]
    public class GeoJson
    {
        [DataMember(Name = "type")]
        public string type { get; set; }
        [DataMember(Name = "id")]
        public string id { get; set; }
        [DataMember(Name = "geometry")]
        public Geom geometry { get; set; }
        [DataContract]
        public class Geom
        {
            [DataMember(Name = "type")]
            public string type { get; set; }
            [DataMember(Name = "coordinates")]
            public double[] coordinates { get; set; }
        }
        [DataMember(Name = "properties")]
        public Prop properties { get; set; }
        [DataContract]
        public class Prop
        {
            [DataMember(Name = "ID")]
            public string ID { get; set; }
            [DataMember(Name = "ADDRESS")]
            public string ADDRESS { get; set; }
            [DataMember(Name = "LATITUDE")]
            public string LATITUDE { get; set; }
            [DataMember(Name = "LONGITUDE")]
            public string LONGITUDE { get; set; }
        }
    }
    public class JsonHelper
    {
        public string ToJson<T>(T obj)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(obj.GetType());
            string retVal;
            using (MemoryStream ms = new MemoryStream())
            {
                serializer.WriteObject(ms, obj);
                retVal = Encoding.UTF8.GetString(ms.ToArray());
            }
            return retVal;
        }

        public T FromJson<T>(string json)
        {
            T obj = Activator.CreateInstance<T>();
            using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(json)))
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(obj.GetType());
                obj = (T)serializer.ReadObject(ms);
            }

            return obj;
        }
    }


}