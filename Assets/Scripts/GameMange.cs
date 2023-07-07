using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameMange : MonoBehaviour
{
    public static GameMange Instant;

    public new string name = "";
    public new string highScoreName;
    public int highScore;

    private void Awake()
    {
        if (Instant != null)
            return;

        Instant = this;
        DontDestroyOnLoad(gameObject);
        Load();
    }

    [System.Serializable]
    private class SaveData
    {
        public string name;
        public string highScoreName;
        public int highScore;
    }

    public void Save()
    {
        SaveData data = new SaveData();
        data.highScoreName = highScoreName;
        data.highScore = highScore;
        data.name = name;

        string path = Application.dataPath + "/savefile.json";
        string json = JsonUtility.ToJson(data);

        File.WriteAllText(path, json);
    }

    public void Load()
    {
        string path = Application.dataPath + "/savefile.json";

        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            highScoreName = data.highScoreName;
            highScore = data.highScore;
            name = data.name;
        }
    }
}
