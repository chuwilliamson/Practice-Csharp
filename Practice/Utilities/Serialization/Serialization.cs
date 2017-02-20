using System;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization.Json;
 
namespace Utilities.Serialization
{ 
    public static class Json
    {
        public static void Save<T>(string fileName, T data) where T : new()
        {
            var serializer = new DataContractJsonSerializer(typeof(T));
            var path = Environment.CurrentDirectory + "../Saves/Json/";
            var outfile = path + fileName + ".json";
            Directory.CreateDirectory(path);    
            using(var fs = new FileStream(outfile, FileMode.Create))            
                serializer.WriteObject(fs, data);
            
     
        }

        public static T Load<T>(string fileName) where T : new()
        {
            var serializer = new DataContractJsonSerializer(typeof(T));
            var path = Environment.CurrentDirectory + "../Saves/Json/";
            var outfile = path + fileName + ".json";
            using(var fs = new FileStream(outfile, FileMode.Open))            
                return (T)serializer.ReadObject(fs);
            

        }
    }

    public static class XML
    {
        public static void Save<T>(string fileName, T data)
        {
            var serializer = new XmlSerializer(typeof(T));
            string path = Environment.CurrentDirectory + "../Saves/XML/";
                Directory.CreateDirectory(path);
            using(var writer = new StreamWriter(path + fileName + ".xml"))
                serializer.Serialize(writer, data);
        }

        public static T Load<T>(string fileName) where T : new()
        {
            var serializer = new XmlSerializer(typeof(T));
            var path = Environment.CurrentDirectory + "../Saves/XML/" + fileName + ".xml";
            using(var reader = new StreamReader(path))
                return (T)serializer.Deserialize(reader);
        }
    }
}

