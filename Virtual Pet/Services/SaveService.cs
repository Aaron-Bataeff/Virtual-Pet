using System.Text.Json;
using VirtualPet.Models;

namespace VirtualPet.Services
{
    public static class SaveService
    {
        private const string SaveFile = "pet.json";

        public static void Save(Pet pet)
        {
            string json = JsonSerializer.Serialize(
                pet,
                new JsonSerializerOptions
                {
                    WriteIndented = true
                });

            File.WriteAllText(SaveFile, json);
        }

        public static Pet? Load()
        {
            if (!File.Exists(SaveFile))
            {
                return null;
            }

            string json = File.ReadAllText(SaveFile);

            return JsonSerializer.Deserialize<Pet>(json);
        }
    }
}