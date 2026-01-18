using System.IO;
using Newtonsoft.Json;

public class SaveLoadService
{
    private const string SaveFilePath = "script_data.json";

    public static void SaveData(object data)
    {
        File.WriteAllText(SaveFilePath, JsonConvert.SerializeObject(data));
    }

    public static T LoadData<T>()
    {
        if (!File.Exists(SaveFilePath)) return default;
        return JsonConvert.DeserializeObject<T>(File.ReadAllText(SaveFilePath));
    }
}
