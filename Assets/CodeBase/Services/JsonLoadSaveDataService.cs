using Newtonsoft.Json;
using System.IO;
using System;

namespace Assets.CodeBase.Services
{
    public class JsonLoadSaveDataService : ILoadSaveDataFormat
    {
        private JsonSerializer _serializer;
        public JsonLoadSaveDataService()
        {
            _serializer = new JsonSerializer();
        }
        public T Load<T>(string path)
        {
            T data = default;
            if (File.Exists(path))
            {
                using (StreamReader file = File.OpenText(path))
                {                                        
                    data = (T)_serializer.Deserialize(file, typeof(T));
                }
            }
            else
                throw new FileNotFoundException();
            return data;
        }

        public void Save<T>(string path, T data)
        {
            using (StreamWriter file = File.CreateText(path))
            {                
                _serializer.Serialize(file, data);
            }
        }
    }
}
