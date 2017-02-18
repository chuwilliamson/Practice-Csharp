using System;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Linq;
using System.Collections.Generic;
namespace Utilities.Serialization
{
    class JsonHelper
    {
        private const string INDENT_STRING = "    ";
        public static string FormatJson(string str)
        {
            var indent = 0;
            var quoted = false;
            var sb = new StringBuilder();
            for(var i = 0; i < str.Length; i++)
            {
                var ch = str[i];
                switch(ch)
                {
                    case '{':
                    case '[':
                        sb.Append(ch);
                        if(!quoted)
                        {
                            sb.AppendLine();
                            Enumerable.Range(0, ++indent).ForEach(item => sb.Append(INDENT_STRING));
                        }
                        break;
                    case '}':
                    case ']':
                        if(!quoted)
                        {
                            sb.AppendLine();
                            Enumerable.Range(0, --indent).ForEach(item => sb.Append(INDENT_STRING));
                        }
                        sb.Append(ch);
                        break;
                    case '"':
                        sb.Append(ch);
                        bool escaped = false;
                        var index = i;
                        while(index > 0 && str[--index] == '\\')
                            escaped = !escaped;
                        if(!escaped)
                            quoted = !quoted;
                        break;
                    case ',':
                        sb.Append(ch);
                        if(!quoted)
                        {
                            sb.AppendLine();
                            Enumerable.Range(0, indent).ForEach(item => sb.Append(INDENT_STRING));
                        }
                        break;
                    case ':':
                        sb.Append(ch);
                        if(!quoted)
                            sb.Append(" ");
                        break;
                    default:
                        sb.Append(ch);
                        break;
                }
            }
            return sb.ToString();
        }
    }

    static class Extensions
    {
        public static void ForEach<T>(this IEnumerable<T> ie, Action<T> action)
        {
            foreach(var i in ie)
            {
                action(i);
            }
        }
    }
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
            if(!Directory.Exists(path))
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

