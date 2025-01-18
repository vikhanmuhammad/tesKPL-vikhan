using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using teskpl_vikhan;

public class JsonFileService
{
    private static readonly string FilePath = "Data/students.json";

    private static void EnsureDirectoryAndFileExist()
    {
        string directory = Path.GetDirectoryName(FilePath);

        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }

        if (!File.Exists(FilePath))
        {
            File.WriteAllText(FilePath, "[]");
        }
    }

    public static List<Students> LoadData()
    {
        EnsureDirectoryAndFileExist();

        string json = File.ReadAllText(FilePath);
        return DeserializeJson(json);
    }

    public static void SaveData(List<Students> students)
    {
        string json = SerializeToJson(students);
        File.WriteAllText(FilePath, json);
    }

    private static string SerializeToJson(List<Students> students)
    {
        return JsonSerializer.Serialize(students, new JsonSerializerOptions { WriteIndented = true });
    }

    private static List<Students> DeserializeJson(string json)
    {
        return JsonSerializer.Deserialize<List<Students>>(json) ?? new List<Students>();
    }
}
