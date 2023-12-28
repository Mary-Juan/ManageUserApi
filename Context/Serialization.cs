using ManageUserApi.Entities;
using Newtonsoft.Json;

namespace ManageUserApi.Context
{
    public static class Serialization
    {
        public static bool SerializeToJsonFile(string filePath, List<Person> people)
        {
            try
            {
                string[] allLines = new string[0];
                foreach (Person person in people)
                {
                    allLines = allLines.Append(SerializeObjectToJson(person)).ToArray(); ;
                }
                File.WriteAllLines(filePath, allLines);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static List<Person> DeserializeFromJsonFile(string filePath)
        {
            if (!File.Exists(filePath))
                File.Create(filePath).Close();

            List<Person> people = new List<Person>();
            string[] lines = File.ReadAllLines(filePath);

            foreach(string line in lines)
            {
                Person person = DeserializeToObject(line);
                people.Add(person);
            }

            return people;
        }

        public static Person DeserializeToObject(string json)
        {
            var settings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.Objects
            };

            return JsonConvert.DeserializeObject<Person>(json, settings);
        }

        public static string SerializeObjectToJson( Person person)
        {
            var settings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.Objects
            };

            return JsonConvert.SerializeObject(person, settings);
        }
    }
}
