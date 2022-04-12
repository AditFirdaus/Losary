using System.IO;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class UserData
{
    public static UserData userData { get => GameData.userData; }

    #region GlobalVariables
    public float deliveryPoint = 1000;
    public bool limitFps = true;
    public bool showFPS = false;
    public bool autoHit = false;
    public bool repeatLevel = false;
    public int musicIndex = 0;
    public PlayerData playerData = new PlayerData();

    #endregion

    #region SaveLoadSystem
    public static string userDataPath { get { return Application.persistentDataPath + "/UserData.json"; } }
    public static void Save()
    {
        string jsonContent = JsonUtility.ToJson(GameData.userData, true);
        File.WriteAllText(userDataPath, jsonContent);
    }

    public static void Load()
    {
        if (!File.Exists(userDataPath)) Save();
        string jsonContent = File.ReadAllText(userDataPath);
        GameData.userData = JsonUtility.FromJson<UserData>(jsonContent);
    }
    #endregion
}