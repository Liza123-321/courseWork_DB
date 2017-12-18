using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Runtime.Serialization.Json;
using System.Security.Policy;
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
        public void ToGeo(string allGeoJson)
        {
            using (FileStream fstream = new FileStream(@"D:\3 COURSE\COURSE_PETS\geo.json", FileMode.OpenOrCreate))
            {
                string toJson = "{\"type\":\"FeatureCollection\",\"features\":\r\n    [";
                string endFail = " ]\r\n }";
                // преобразуем строку в байты
                string dellLast = allGeoJson.Remove(allGeoJson.Length-1);
                byte[] array = System.Text.Encoding.Default.GetBytes(toJson+ dellLast + endFail);
                // запись массива байтов в файл
                fstream.Write(array, 0, array.Length);
                Console.WriteLine("Текст записан в файл");
            }
        }
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