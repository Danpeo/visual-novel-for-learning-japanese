using System;
using System.IO;
using Data;
using UnityEngine;

public static class SaveLoadController 
{
    private static string SaveFileName = "save.dat";

    public static void SaveGame(int sentence)
    {
        var jsonData = JsonUtility.ToJson(sentence);
        var filePath = Path.Combine(Application.persistentDataPath, SaveFileName);
        File.WriteAllText(filePath, jsonData);
    }

    public static int LoadGame()
    {
        var filePath = Path.Combine(Application.persistentDataPath, SaveFileName);
        if (!File.Exists(filePath)) return 0;
        
        var jsonData = File.ReadAllText(filePath);
        return JsonUtility.FromJson<int>(jsonData);
    }
}

[Serializable]
public class SaveData
{
    public DialogData DialogData;
}
