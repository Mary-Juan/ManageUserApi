using ManageUserApi.Entities;
using Newtonsoft.Json;

namespace ManageUserApi.Context
{
    public static class Serialization
    {
        public static bool SerializeToJsonFile(string filePath, List<User> users)
        {
            try
            {
                string[] allLines = new string[0];
                foreach (User User in users)
                {
                    allLines = allLines.Append(SerializeObjectToJson(User)).ToArray(); ;
                }
                File.WriteAllLines(filePath, allLines);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static List<User> DeserializeFromJsonFile(string filePath)
        {
            if (!File.Exists(filePath))
                File.Create(filePath).Close();

            List<User> users = new List<User>();
            string[] lines = File.ReadAllLines(filePath);

            foreach(string line in lines)
            {
                User User = DeserializeToObject(line);
                users.Add(User);
            }

            return users;
        }

        public static User DeserializeToObject(string json)
        {
            var settings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.Objects
            };

            return JsonConvert.DeserializeObject<User>(json, settings);
        }

        public static string SerializeObjectToJson( User User)
        {
            var settings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.Objects
            };

            return JsonConvert.SerializeObject(User, settings);
        }
    }
}
