using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOW.Automation.Interface.DLx.Excel.Services
{
   public class JsonServices
    {
        public void SerializarNewtonsoft<T>(List<T> dados, string nmSaida, string path)
        {

            DirectoryInfo info1 = new DirectoryInfo(path);

            if (!info1.Exists)
                info1.CreateSubdirectory(path);

            using (var streamWriter = File.CreateText(path + nmSaida))
            {
                var json = Newtonsoft.Json.JsonConvert.SerializeObject(dados, Formatting.Indented);
                streamWriter.Write(json);
            }
        }

        public void SerializarUniqueNewtonsoft<T>(T dados, string nmSaida, string path)
        {
            DirectoryInfo info1 = new DirectoryInfo(path);

            if (!info1.Exists)
                info1.CreateSubdirectory(path);



            using (var streamWriter = File.CreateText(path + nmSaida))
            {
                var json = Newtonsoft.Json.JsonConvert.SerializeObject(dados, Formatting.Indented);
                streamWriter.Write(json);
            }
        }

        public T DeserializarUniqueNewtonsoft<T>(string nmArquivo, string path)
        {
            FileInfo info = new FileInfo(path + nmArquivo);

            if (info.Exists)
            {

                var json = System.IO.File.ReadAllText(path + nmArquivo);
                return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json);
            }
            else
            {
                return default(T);
            }
        }

        public List<T> DeserializarNewtonsoft<T>(string nmArquivo, string path)
        {
            string file = path + nmArquivo;
            if (File.Exists(file))
            {

                try
                {
                    var json = System.IO.File.ReadAllText(path + nmArquivo);
                    return Newtonsoft.Json.JsonConvert.DeserializeObject<List<T>>(json);
                }
                catch { return new List<T>(); }
            }
            else
            {
                return new List<T>();
            }
        }
    }
}
